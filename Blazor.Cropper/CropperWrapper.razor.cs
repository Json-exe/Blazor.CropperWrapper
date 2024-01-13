using Json_exe.Blazor.Cropper.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Json_exe.Blazor.Cropper;

public partial class CropperWrapper
{
    /// <summary>
    /// The image src to crop.
    /// </summary>
    [Parameter, EditorRequired]
    public string ImageSrc { get; set; } = string.Empty;

    /// <summary>
    /// The alt text for the image.
    /// </summary>
    [Parameter]
    public string Alt { get; set; } = string.Empty;

    /// <summary>
    /// The options for the cropper.
    /// </summary>
    [Parameter]
    public CropperOptions Options { get; set; } = new();

    /// <summary>
    /// This event fires when the target image has been loaded and the
    /// cropper instance is ready for operating.
    /// </summary>
    [Parameter]
    public EventCallback OnReady { get; set; }
    /// <summary>
    /// This event fires when a cropper instance starts to zoom in or zoom out its canvas (image wrapper).
    /// </summary>
    [Parameter]
    public EventCallback<ZoomEvent> OnZoom { get; set; }
    /// <summary>
    /// This event fires when the canvas (image wrapper) or the crop box changes.
    /// </summary>
    [Parameter]
    public EventCallback<CropEvent> OnCrop { get; set; }
    
    private ElementReference ElementRef { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await CropperJsInterop.InitializeCropper(ElementRef, Options,
                this);
        }
    }

    /// <summary>
    /// Returns the cropped area of the image as a base64 string with the given options.
    /// </summary>
    /// <param name="options">
    /// The options for the cropped area.
    /// </param>
    /// <returns>
    /// The cropped image as a base64 string.
    /// </returns>
    public async Task<string> GetCroppedArea(CropCanvasOptions options)
    {
        var imageData = await CropperJsInterop.GetCroppedCanvas(options);
        return imageData;
    }
    
    /// <summary>
    /// Returns the cropped area of the image as a base64 string with default options.
    /// </summary>
    /// <returns>
    /// The cropped image as a base64 string.
    /// </returns>
    public async Task<string> GetCroppedArea()
    {
        var imageData = await CropperJsInterop.GetCroppedCanvas(new CropCanvasOptions());
        return imageData;
    }

    /// <summary>
    /// Returns the image inside the cropper as a base64 string.
    /// </summary>
    /// <returns>
    /// The image as a base64 string.
    /// </returns>
    public string GetImage()
    {
        return ImageSrc;
    }

    /// <summary>
    /// Rotates the image to the left.
    /// </summary>
    /// <param name="degree">
    /// The degree to rotate the image.
    /// </param>
    public async Task RotateLeft(int degree = 45)
    {
        degree = -degree;
        await CropperJsInterop.RotateLeft(degree);
    }

    /// <summary>
    /// Rotates the image to the right.
    /// </summary>
    /// <param name="degree">
    /// The degree to rotate the image.
    /// </param>
    public async Task RotateRight(int degree = 45)
    {
        await CropperJsInterop.RotateRight(degree);
    }

    /// <summary>
    /// Scales the image vertically.
    /// </summary>
    public async Task ScaleVertical()
    {
        await CropperJsInterop.ScaleVertical();
    }

    /// <summary>
    /// Scales the image horizontally.
    /// </summary>
    public async Task ScaleHorizontal()
    {
        await CropperJsInterop.ScaleHorizontal();
    }

    /// <summary>
    /// Moves the image.
    /// </summary>
    /// <param name="x">
    /// The x coordinate to move the image.
    /// </param>
    /// <param name="y">
    /// The y coordinate to move the image.
    /// </param>
    public async Task Move(int x, int y)
    {
        await CropperJsInterop.Move(x, y);
    }

    /// <summary>
    /// Reset the image and crop box to its initial states.
    /// </summary>
    public async Task Reset()
    {
        await CropperJsInterop.Reset();
    }

    /// <summary>
    /// Clear the crop box.
    /// </summary>
    public async Task Clear()
    {
        await CropperJsInterop.Clear();
    }

    /// <summary>
    /// Replace the image's src and rebuild the cropper.
    /// </summary>
    /// <param name="data">
    /// The new image src.
    /// </param>
    public async Task Replace(string data)
    {
        await CropperJsInterop.Replace(data);
    }

    /// <summary>
    /// Enable (unfreeze) the cropper.
    /// </summary>
    public async Task Enable()
    {
        await CropperJsInterop.Enable();
    }

    /// <summary>
    /// Disable (freeze) the cropper.
    /// </summary>
    public async Task Disable()
    {
        await CropperJsInterop.Disable();
    }

    /// <summary>
    /// Zoom the canvas with a relative ratio.
    /// </summary>
    /// <param name="ratio">
    /// The ratio to zoom the image.
    /// Zoom in: > 0
    /// Zoom out: <![CDATA[<]]> 0
    /// </param>
    public async Task Zoom(double ratio)
    {
        await CropperJsInterop.Zoom(ratio);
    }

    /// <summary>
    /// Rotate the image to an absolute degree.
    /// </summary>
    /// <param name="degree">
    /// The degree to rotate the image.
    /// </param>
    public async Task RotateTo(double degree)
    {
        await CropperJsInterop.RotateTo(degree);
    }
    
    /// <summary>
    /// Output the final cropped area position and size data (based on the natural size of the original image).
    /// </summary>
    /// <param name="rounded">
    /// Set to true to get rounded values.
    /// </param>
    /// <returns>
    /// A CropData object containing the position and size data.
    /// </returns>
    public async Task<CropData> GetData(bool rounded = false)
    {
        return await CropperJsInterop.GetData(rounded);
    }
}