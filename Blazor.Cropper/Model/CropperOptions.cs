using System.Text.Json.Serialization;

namespace Json_exe.Blazor.Cropper.Model;

/// <summary>
/// Represents the configuration options for a cropper instance. Read more at https://github.com/fengyuanchen/cropperjs/blob/v1/README.md#options
/// </summary>
public class CropperOptions
{
    /// <summary>
    /// Defines how the canvas (image wrapper) can exceed the container.
    /// 0: no restrictions, 1: crop box within canvas, 2: canvas within container, 3: canvas fills container.
    /// </summary>
    [JsonPropertyName("viewMode")] public int ViewMode { get; set; } = 0;

    /// <summary>
    /// Defines the default drag mode for user interaction.
    /// </summary>
    [JsonPropertyName("dragMode")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public DragMode DragMode { get; set; } = DragMode.crop;

    /// <summary>
    /// The initial aspect ratio of the crop box on load.
    /// </summary>
    [JsonPropertyName("initialAspectRatio")]
    [JsonNumberHandling(JsonNumberHandling.AllowNamedFloatingPointLiterals)]
    public double? InitialAspectRatio { get; set; } = double.NaN;

    /// <summary>
    /// The fixed aspect ratio of the crop box. Free ratio when not set.
    /// </summary>
    [JsonPropertyName("aspectRatio")]
    [JsonNumberHandling(JsonNumberHandling.AllowNamedFloatingPointLiterals)]
    public double? AspectRatio { get; set; } = double.NaN;

    /// <summary>
    /// CSS selector for live preview containers.
    /// </summary>
    [JsonPropertyName("preview")] public string Preview { get; set; } = string.Empty;
    /// <summary>
    /// Re-renders the cropper when the window is resized.
    /// </summary>
    [JsonPropertyName("responsive")] public bool Responsive { get; set; } = true;
    /// <summary>
    /// Restores the cropped area after resizing/orientation changes.
    /// </summary>
    [JsonPropertyName("restore")] public bool Restore { get; set; } = true;
    /// <summary>
    /// Checks image cross-origin headers when loading.
    /// </summary>
    [JsonPropertyName("checkCrossOrigin")] public bool CheckCrossOrigin { get; set; } = true;
    /// <summary>
    /// Checks image EXIF orientation information.
    /// </summary>
    [JsonPropertyName("checkOrientation")] public bool CheckOrientation { get; set; } = true;
    /// <summary>
    /// Shows the dark modal overlay above the image.
    /// </summary>
    [JsonPropertyName("modal")] public bool Modal { get; set; } = true;
    /// <summary>
    /// Shows the dashed guides above the crop box.
    /// </summary>
    [JsonPropertyName("guides")] public bool Guides { get; set; } = true;
    /// <summary>
    /// Shows the center indicator above the crop box.
    /// </summary>
    [JsonPropertyName("center")] public bool Center { get; set; } = true;
    /// <summary>
    /// Shows the white highlight area above the crop box.
    /// </summary>
    [JsonPropertyName("highlight")] public bool Highlight { get; set; } = true;
    /// <summary>
    /// Shows the grid background of the container.
    /// </summary>
    [JsonPropertyName("background")] public bool Background { get; set; } = true;
    /// <summary>
    /// Automatically crops the image on initialization.
    /// </summary>
    [JsonPropertyName("autoCrop")] public bool AutoCrop { get; set; } = true;
    /// <summary>
    /// The initial coverage (0-1) of the crop box when <see cref="AutoCrop"/> is enabled.
    /// </summary>
    [JsonPropertyName("autoCropArea")] public double? AutoCropArea { get; set; } = 0.8;
    /// <summary>
    /// Allows moving the image.
    /// </summary>
    [JsonPropertyName("movable")] public bool Movable { get; set; } = true;
    /// <summary>
    /// Allows rotating the image.
    /// </summary>
    [JsonPropertyName("rotatable")] public bool Rotatable { get; set; } = true;
    /// <summary>
    /// Allows scaling the image.
    /// </summary>
    [JsonPropertyName("scalable")] public bool Scalable { get; set; } = true;
    /// <summary>
    /// Allows zooming the image.
    /// </summary>
    [JsonPropertyName("zoomable")] public bool Zoomable { get; set; } = true;
    /// <summary>
    /// Allows zooming the image by touch.
    /// </summary>
    [JsonPropertyName("zoomOnTouch")] public bool ZoomOnTouch { get; set; } = true;
    /// <summary>
    /// Allows zooming the image by mouse wheel.
    /// </summary>
    [JsonPropertyName("zoomOnWheel")] public bool ZoomOnWheel { get; set; } = true;
    /// <summary>
    /// The zoom step ratio applied on wheel zoom.
    /// </summary>
    [JsonPropertyName("wheelZoomRatio")] public double WheelZoomRatio { get; set; } = 0.1;
    /// <summary>
    /// Allows moving the crop box.
    /// </summary>
    [JsonPropertyName("cropBoxMovable")] public bool CropBoxMovable { get; set; } = true;
    /// <summary>
    /// Allows resizing the crop box.
    /// </summary>
    [JsonPropertyName("cropBoxResizable")] public bool CropBoxResizable { get; set; } = true;

    /// <summary>
    /// Toggles between drag modes on double click.
    /// </summary>
    [JsonPropertyName("toggleDragModeOnDblclick")]
    public bool ToggleDragModeOnDblclick { get; set; } = true;

    /// <summary>
    /// The minimum width of the container.
    /// </summary>
    [JsonPropertyName("minContainerWidth")]
    public double MinContainerWidth { get; set; } = 200;

    /// <summary>
    /// The minimum height of the container.
    /// </summary>
    [JsonPropertyName("minContainerHeight")]
    public double MinContainerHeight { get; set; } = 100;

    /// <summary>
    /// The minimum width of the canvas (image wrapper).
    /// </summary>
    [JsonPropertyName("minCanvasWidth")] public double MinCanvasWidth { get; set; } = 0;
    /// <summary>
    /// The minimum height of the canvas (image wrapper).
    /// </summary>
    [JsonPropertyName("minCanvasHeight")] public double MinCanvasHeight { get; set; } = 0;
    /// <summary>
    /// The minimum width of the crop box.
    /// </summary>
    [JsonPropertyName("minCropBoxWidth")] public double MinCropBoxWidth { get; set; } = 0;
    /// <summary>
    /// The minimum height of the crop box.
    /// </summary>
    [JsonPropertyName("minCropBoxHeight")] public double MinCropBoxHeight { get; set; } = 0;
}

/// <summary>
/// Specifies the drag mode for a cropper instance, determining how the crop box or canvas can be manipulated by user interactions.
/// </summary>
public enum DragMode
{
    /// <summary>
    /// Creates a new crop box on drag.
    /// </summary>
    crop,
    /// <summary>
    /// Moves the canvas on drag.
    /// </summary>
    move,
    /// <summary>
    /// No drag action.
    /// </summary>
    none
}
