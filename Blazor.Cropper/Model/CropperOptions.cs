using System.Text.Json.Serialization;

namespace Json_exe.Blazor.Cropper.Model;

public class CropperOptions
{
    [JsonPropertyName("viewMode")] public int ViewMode { get; set; } = 0;

    [JsonPropertyName("dragMode")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public DragMode DragMode { get; set; } = DragMode.crop;

    [JsonPropertyName("initialAspectRatio")]
    [JsonNumberHandling(JsonNumberHandling.AllowNamedFloatingPointLiterals)]
    public double? InitialAspectRatio { get; set; } = double.NaN;

    [JsonPropertyName("aspectRatio")]
    [JsonNumberHandling(JsonNumberHandling.AllowNamedFloatingPointLiterals)]
    public double? AspectRatio { get; set; } = double.NaN;

    [JsonPropertyName("preview")] public string Preview { get; set; } = string.Empty;
    [JsonPropertyName("responsive")] public bool Responsive { get; set; } = true;
    [JsonPropertyName("restore")] public bool Restore { get; set; } = true;
    [JsonPropertyName("checkCrossOrigin")] public bool CheckCrossOrigin { get; set; } = true;
    [JsonPropertyName("checkOrientation")] public bool CheckOrientation { get; set; } = true;
    [JsonPropertyName("modal")] public bool Modal { get; set; } = true;
    [JsonPropertyName("guides")] public bool Guides { get; set; } = true;
    [JsonPropertyName("center")] public bool Center { get; set; } = true;
    [JsonPropertyName("highlight")] public bool Highlight { get; set; } = true;
    [JsonPropertyName("background")] public bool Background { get; set; } = true;
    [JsonPropertyName("autoCrop")] public bool AutoCrop { get; set; } = true;
    [JsonPropertyName("autoCropArea")] public double? AutoCropArea { get; set; } = 0.8;
    [JsonPropertyName("movable")] public bool Movable { get; set; } = true;
    [JsonPropertyName("rotatable")] public bool Rotatable { get; set; } = true;
    [JsonPropertyName("scalable")] public bool Scalable { get; set; } = true;
    [JsonPropertyName("zoomable")] public bool Zoomable { get; set; } = true;
    [JsonPropertyName("zoomOnTouch")] public bool ZoomOnTouch { get; set; } = true;
    [JsonPropertyName("zoomOnWheel")] public bool ZoomOnWheel { get; set; } = true;
    [JsonPropertyName("wheelZoomRatio")] public double WheelZoomRatio { get; set; } = 0.1;

    [JsonPropertyName("toggleDragModeOnDblclick")]
    public bool ToggleDragModeOnDblclick { get; set; } = true;
}

public enum DragMode
{
    crop, 
    move,
    none
}