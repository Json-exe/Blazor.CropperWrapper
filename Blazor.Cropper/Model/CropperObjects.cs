using System.Text.Json.Serialization;

namespace Json_exe.Blazor.Cropper.Model;

public record CropData
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double Rotate { get; set; }
    public double ScaleX { get; set; }
    public double ScaleY { get; set; }
}

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

public enum ImageSmoothingQuality
{
    low,
    medium,
    high
}