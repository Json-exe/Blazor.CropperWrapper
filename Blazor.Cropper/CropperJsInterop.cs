using Json_exe.Blazor.Cropper.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Json_exe.Blazor.Cropper;

internal sealed class CropperJsInterop : IAsyncDisposable
{
    private readonly Lazy<ValueTask<IJSObjectReference>> _moduleTask;
    private IJSObjectReference _cropModule = null!;
    private DotNetObjectReference<CropperJsInterop>? _dotNetObjectReference;
    private CropperWrapper _cropperWrapper = null!;

    public CropperJsInterop(IJSRuntime jsRuntime)
    {
        _moduleTask = new Lazy<ValueTask<IJSObjectReference>>(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/Json_exe.Blazor.Cropper/cropperWrapper.js"));
    }

    public async ValueTask InitializeCropper(ElementReference reference, CropperOptions options,
        CropperWrapper dotNetObjectReference)
    {
        var module = await _moduleTask.Value;
        _dotNetObjectReference = DotNetObjectReference.Create(this);
        _cropperWrapper = dotNetObjectReference;
        _cropModule = await module.InvokeAsync<IJSObjectReference>("initializeCropper", reference, options,
            _dotNetObjectReference);
    }

    [JSInvokable]
    public async Task ReadyEvent() => await _cropperWrapper.OnReady.InvokeAsync();

    [JSInvokable]
    public async Task ZoomEvent(ZoomEvent zoomEvent) => await _cropperWrapper.OnZoom.InvokeAsync(zoomEvent);

    [JSInvokable]
    public async Task CropEvent(CropEvent cropEvent) => await _cropperWrapper.OnCrop.InvokeAsync(cropEvent);

    public async ValueTask<string> GetCroppedCanvasAsBase64(CropCanvasOptions options)
    {
        var module = await _moduleTask.Value;
        var imageData = await module.InvokeAsync<string>("getCroppedCanvas", options, _cropModule);
        return imageData;
    }

    public async ValueTask<Uri> GetCroppedCanvasAsUri(CropCanvasOptions options)
    {
        var module = await _moduleTask.Value;
        var uri = await module.InvokeAsync<Uri?>("getCroppedCanvasUri", options, _cropModule);
        if (uri is null)
        {
            throw new CropperException("Failed to get cropped canvas uri", null);
        }

        return uri;
    }

    public async ValueTask RotateLeft(int degrees = -45)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("rotateLeft", degrees, _cropModule);
    }

    public async ValueTask RotateRight(int degrees = 45)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("rotateRight", degrees, _cropModule);
    }

    public async ValueTask ScaleVertical()
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("scaleVertically", _cropModule);
    }

    public async ValueTask Move(int x, int y)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("move", x, y, _cropModule);
    }

    public async ValueTask ScaleHorizontal()
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("scaleHorizontally", _cropModule);
    }


    public async ValueTask Reset()
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("reset", _cropModule);
    }

    public async ValueTask Clear()
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("clear", _cropModule);
    }

    public async ValueTask Replace(string data)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("replace", data, _cropModule);
    }

    public async ValueTask Enable()
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("enable", _cropModule);
    }

    public async ValueTask Disable()
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("disable", _cropModule);
    }

    public async ValueTask Zoom(double ratio)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("zoom", ratio, _cropModule);
    }

    public async ValueTask RotateTo(double degrees)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("rotateTo", degrees, _cropModule);
    }

    public async ValueTask<CropData> GetData(bool rounded = false)
    {
        var module = await _moduleTask.Value;
        var data = await module.InvokeAsync<CropData>("getData", rounded, _cropModule);
        return data;
    }

    public async ValueTask DestroyBlobs()
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("destroyBlobs");
    }

    public async ValueTask DisposeAsync()
    {
        if (_moduleTask.IsValueCreated)
        {
            var module = await _moduleTask.Value;
            try
            {
                await module.InvokeVoidAsync("dispose");
            }
            catch (JSDisconnectedException)
            {
                // Ignore
            }

            await module.DisposeAsync();
            _dotNetObjectReference?.Dispose();
        }
    }
}