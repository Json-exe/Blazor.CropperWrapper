using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.Cropper;

// This class provides an example of how JavaScript functionality can be wrapped
// in a .NET class for easy consumption. The associated JavaScript module is
// loaded on demand when first needed.
//
// This class can be registered as scoped DI service and then injected into Blazor
// components for use.

public class CropperJsInterop : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;
    private IJSObjectReference _cropModule = null!;

    public CropperJsInterop(IJSRuntime jsRuntime)
    {
        _moduleTask = new Lazy<Task<IJSObjectReference>>(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/Json_exe.Blazor.Cropper/cropperWrapper.js").AsTask());
    }

    public async ValueTask InitializeCropper(ElementReference reference, object o)
    {
        var module = await _moduleTask.Value;
        _cropModule = await module.InvokeAsync<IJSObjectReference>("initializeCropper", reference, o);
    }

    public async ValueTask<string> GetCroppedCanvas()
    {
        var module = await _moduleTask.Value;
        try
        {
            var imageData = await module.InvokeAsync<string>("getCroppedCanvas", _cropModule);
            return imageData;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
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

    public async ValueTask DisposeAsync()
    {
        if (_moduleTask.IsValueCreated)
        {
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }
    
    public async ValueTask GoBack(string data)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("replace", _cropModule, data);
    }
}