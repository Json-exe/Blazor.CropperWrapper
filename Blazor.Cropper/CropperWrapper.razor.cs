using System.Text.Json;
using System.Text.Json.Serialization;
using Blazor.Cropper.Model;
using Microsoft.AspNetCore.Components;

namespace Blazor.Cropper;

public partial class CropperWrapper
{
    /// <summary>
    /// The image src to crop.
    /// </summary>
    [Parameter] public string ImageSrc { get; set; } = string.Empty;
    
    /// <summary>
    /// The alt text for the image.
    /// </summary>
    [Parameter] public string Alt { get; set; } = string.Empty;
    
    /// <summary>
    /// The options for the cropper.
    /// </summary>
    [Parameter] public CropperOptions Options { get; set; } = new();
    
    private readonly List<string> _changeList = new();
    
    private ElementReference ElementRef { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await CropperJsInterop.InitializeCropper(ElementRef, Options);
        }
    }

    /// <summary>
    /// Crops the image and sets the ImageSrc to the cropped image.
    /// The image is saved in the changeList, so you can go back to the last image.
    /// </summary>
    public async Task GetCroppedArea()
    {
        _changeList.Add(ImageSrc);
        var imageData = await CropperJsInterop.GetCroppedCanvas();
        ImageSrc = imageData;
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
    /// Goes back to the last image.
    /// </summary>
    public async Task GoBack()
    {
        if (_changeList.Count <= 0) return;
        ImageSrc = _changeList[^1];
        await CropperJsInterop.GoBack(ImageSrc);
        _changeList.RemoveAt(_changeList.Count - 1);
    }
}