namespace Json_exe.Blazor.Cropper.Model;

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

public sealed record CropEvent : CropData;