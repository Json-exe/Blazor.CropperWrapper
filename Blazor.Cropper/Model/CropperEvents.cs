namespace Json_exe.Blazor.Cropper.Model;

/// <summary>
/// Represents an event triggered during the zooming process in the cropper tool.
/// This class provides information about the current and previous zoom ratios.
/// </summary>
public sealed class ZoomEvent
{
    /// <summary>
    /// The new (next) ratio of the canvas
    /// </summary>
    public double Ratio { get; set; }
    /// <summary>
    /// The old (current) ratio of the canvas
    /// </summary>
    public double OldRatio { get; set; }
}

/// <summary>
/// Represents an event that occurs during the cropping process within the cropper tool.
/// This class extends CropData to include positional and dimension details of the crop.
/// </summary>
public sealed record CropEvent : CropData;