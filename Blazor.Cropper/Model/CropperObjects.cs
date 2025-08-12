using System.Text.Json.Serialization;

namespace Json_exe.Blazor.Cropper.Model;

/// <summary>
/// Represents the cropping data of an image, including position, size, rotation, and scaling factors.
/// </summary>
public record CropData
{
    /// <summary>
    /// The horizontal position of the cropping area on the source image.
    /// </summary>
    public double X { get; init; }

    /// <summary>
    /// The vertical position of the cropping area on the source image.
    /// </summary>
    public double Y { get; init; }

    /// <summary>
    /// The width dimension of the object, typically used to define size or scale in rendering or cropping contexts.
    /// </summary>
    public double Width { get; init; }

    /// <summary>
    /// The destination height of the output canvas.
    /// </summary>
    public double Height { get; init; }

    /// <summary>
    /// The rotation angle of the cropped image, in degrees.
    /// </summary>
    public double Rotate { get; init; }

    /// <summary>
    /// The horizontal scaling factor applied to the image during cropping.
    /// </summary>
    public double ScaleX { get; init; }

    /// <summary>
    /// The vertical scaling factor applied to the image during cropping.
    /// </summary>
    public double ScaleY { get; init; }
}

/// <summary>
/// Represents configurable options for customizing the output canvas of a cropped image,
/// including canvas dimensions, color settings, and image smoothing properties.
/// Read more at: https://github.com/fengyuanchen/cropperjs/blob/v1/README.md#getcroppedcanvasoptions
/// </summary>
public sealed class CropCanvasOptions
{
    /// <summary>
    /// The destination width of the output canvas.
    /// </summary>
    public double Width { get; set; }

    /// <summary>
    /// The destination height of the output canvas.
    /// </summary>
    public double Height { get; set; }

    /// <summary>
    /// The minimum destination width of the output canvas.
    /// </summary>
    public double MinWidth { get; set; } = 0;

    /// <summary>
    /// The minimum destination height of the output canvas.
    /// </summary>
    public double MinHeight { get; set; } = 0;

    /// <summary>
    /// The maximum destination width of the output canvas.
    /// </summary>
    [JsonNumberHandling(JsonNumberHandling.AllowNamedFloatingPointLiterals)]
    public double MaxWidth { get; set; } = double.PositiveInfinity;

    /// <summary>
    /// The maximum destination height of the output canvas.
    /// </summary>
    [JsonNumberHandling(JsonNumberHandling.AllowNamedFloatingPointLiterals)]
    public double MaxHeight { get; set; } = double.PositiveInfinity;

    /// <summary>
    /// A color to fill any alpha values in the output canvas.
    /// </summary>
    public string FillColor { get; set; } = "transparent";

    /// <summary>
    /// Set to change if images are smoothed or not.
    /// </summary>
    public bool ImageSmoothingEnabled { get; set; } = true;

    /// <summary>
    /// Set the quality of image smoothing.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ImageSmoothingQuality ImageSmoothingQuality { get; set; } = ImageSmoothingQuality.low;

    /// <summary>
    /// Set to true to use rounded values.
    /// </summary>
    public bool Rounded { get; set; } = false;
}

/// <summary>
/// Defines the quality levels for image smoothing when rendering a cropped image on a canvas.
/// </summary>
public enum ImageSmoothingQuality
{
    low,
    medium,
    high
}