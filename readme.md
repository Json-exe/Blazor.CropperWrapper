# Json_exe.Blazor.CropperWrapper <!-- omit from toc -->

Enhance your .NET Blazor applications with seamless image cropping functionality using Json_exe.Blazor.CropperWrapper, a comprehensive .NET Blazor wrapper for the Cropper.js library. This package lets you effortlessly integrate a customizable Cropper UI, leveraging the robust features of Cropper.js.

## Table of Contents
- [Table of Contents](#table-of-contents)
- [Introduction](#introduction)
- [Getting Started](#getting-started)
- [Preview](#preview)
- [Examples](#examples)
  - [MudBlazor Application](#mudblazor-application)
  - [How to add a GoBack function](#how-to-add-a-goback-function)
- [Usage](#usage)
  - [Interactive Methods](#interactive-methods)
  - [Parameters](#parameters)
  - [Options](#options)
  - [CropCanvasOptions](#cropcanvasoptions)
  - [Events](#events)
- [Important](#important)
- [Roadmap](#roadmap)
- [Built With](#built-with)
- [Authors](#authors)
- [License](#license)
- [Closing Words](#closing-words)

## Introduction
[Json_exe.Blazor.CropperWrapper](#json_exeblazorcropperwrapper) is a powerful and flexible .NET Blazor wrapper designed for the popular Cropper.js library. It simplifies the process of adding image cropping features to your Blazor applications.

## Getting Started

To start using Json_exe.Blazor.CropperWrapper:
1. Install the package via NuGet.
2. Include `@using Json_exe.Blazor.Cropper` in your `_Imports.razor`.
3. Add `builder.Services.AddCropper()` in your `Program.cs` or `Startup.cs`.
4. Use `<CropperWrapper @ref="@CropperRef" ImageSrc="<Your-Image-Src>"/>` in any page.
5. Create your user interface with buttons and other controls to interact with the cropper methods enabled by the Ref. ``CropperRef.Method()``
6. Refer to [Usage](#usage) for detailed information on methods and options.

## Preview

![chrome_TuCntoczjB](https://github.com/Json-exe/Blazor.CropperWrapper/assets/96955704/ed1b7f16-b346-4b35-b2d2-dd82fb220868)

## Examples 
### MudBlazor Application
```CSharp
@using Json_exe.Blazor.Cropper.Model
<CropperWrapper Options="new CropperOptions { AspectRatio = 1, ViewMode = 1 }" ImageSrc="@ImageData" @ref="@CropperRef" Alt="Example-Alt"/>
<MudDivider FlexItem Class="my-2"/>
<MudStack Row Spacing="5">
    <MudButton Variant="Variant.Filled" OnClick="@Crop">Crop!</MudButton>
</MudStack>

@code {
    private CropperWrapper CropperRef { get; set; } = null!;

    private async Task Crop()
    {
        await using var streamRef = await CropperRef.GetCroppedAreaStream(new CropCanvasOptions());
        await using var stream = await streamRef.OpenReadStreamAsync(maxAllowedSize: 10_000_000);
        // e.g. copy to MemoryStream, upload, or convert to base64
    }
}
```

### How to add a GoBack function
```CSharp
@using Json_exe.Blazor.Cropper.Model
<CropperWrapper @ref="@CropperWrapperRef" ImageSrc="@_imageSrc"/>

@code 
{
  private readonly List<string> _changes = new();
  private CropperWrapper CropperWrapperRef { get; set; } = null!;
  private string _imageSrc = "<Your-Image-Src>";

  private async Task GoBack()
  {
    if (_changes.Count > 0)
    {
        _imageSrc = _changes.Last();
        await CropperWrapperRef.Replace(_imageSrc);
        _changes.RemoveAt(_changes.Count - 1);
    }
  }

  private async Task Crop()
  {
    _changes.Add(_imageSrc);
    var data = await CropperWrapperRef.GetCroppedAreaBlobUri();
    _imageSrc = data.ToString();
  }
}
```

## Usage

### Interactive Methods
The following methods are available to use atm.
- **GetCroppedAreaBase64(CropCanvasOptions options)** / **GetCroppedAreaBase64()**:
  - Returns the cropped area as a base64 data URL (`image/jpeg`).
  - options: `CropCanvasOptions` (width, height, fill color, image smoothing, ...). The parameterless overload uses default options.
- **GetCroppedAreaBlobUri(CropCanvasOptions options)**:
  - Returns the cropped area as a blob `Uri` (object URL). Call `DestroyBlobs()` when the URIs are no longer needed; they are also revoked on dispose.
  - options: `CropCanvasOptions` for the cropped canvas.
- **GetCroppedAreaStream(CropCanvasOptions options)**:
  - Returns the cropped area as an `IJSStreamReference` (JPEG blob). Preferred for large images because it avoids base64 SignalR limits and the extra blob-URI `HttpClient` roundtrip.
  - options: `CropCanvasOptions` for the cropped canvas.
  - Example: `await using var s = await CropperRef.GetCroppedAreaStream(new CropCanvasOptions()); await using var stream = await s.OpenReadStreamAsync(10_000_000);`
- **DestroyBlobs()**:
  - Revokes all object URLs created by `GetCroppedAreaBlobUri()`.
- **GetImage()**:
  - Returns the Base64 string inside the ImageSrc Property. This represents the image currently shown inside the Crop Canvas.
- **RotateLeft(int degree = 45)**:
  - Rotates the image to the left. 
  - degree (optional): The amount of degrees you want to rotate the image
- **RotateRight(int degree = 45)**:
  - Rotates the image to the right. 
  - degree (optional): The amount of degrees you want to rotate the image
- **ScaleVertical()**:
  - Flips the image Vertically
- **ScaleHorizontal()**:
  - Flips the image Horizontally
- **Move(int x, int y)**:
  - Moves the image inside the Canvas
  - x: The amount of pixels you want to move the image on the x axis
  - y: The amount of pixels you want to move the image on the y axis
- **Reset()**: 
  - Resets the image to the original state.
- **Clear()**:
  - Clears the image inside the Canvas.
- **Replace(string imageSrc)**:
  - Replaces the image inside the Canvas with the given imageSrc.
  - imageSrc: The Base64 string of the image you want to replace the current image with.
- **Enable()**: 
  - Enables the Cropper.
- **Disable()**: 
  - Disables the Cropper.
- **Zoom(double ratio)**:
  - Zooms the image inside the Canvas.
  - ratio: The amount of zoom you want to apply to the image.
- **RotateTo(double degree)**:
  - Rotates the image to the given degree.
  - degree: The degree you want to rotate the image to.
- **GetData(bool rounded = false)**:
  - Returns the data of the Cropper.
  - rounded (optional): If true, the data will be rounded.

### Parameters
- **ImageSrc** (required): The image src to crop.
- **Alt**: Alt text for the image.
- **Options**: A `CropperOptions` instance (see below).
- **Class**: Additional CSS classes for the image container.
- **Style**: Additional inline styles for the image container.
- **OnReady / OnZoom / OnCrop**: Event callbacks (see Events).

### Options
---
The following options are available to use atm. To read more about them consider using the official [Cropper.js documentation](https://github.com/fengyuanchen/cropperjs/blob/main/README.md#options)
- **ViewMode**:
  - Type: int
  - Default: 0
- **DragMode**:
  - Type: DragMode enum (`crop`, `move`, `none`)
  - Default: crop
- **InitialAspectRatio**:
  - Type: double
  - Default: double.NaN
- **AspectRatio**:
  - Type: double
  - Default: double.NaN
- **Preview**:
  - Type: string
  - Default: ""
- **Responsive**:
  - Type: bool
  - Default: true
- **Restore**:
  - Type: bool
  - Default: true
- **CheckCrossOrigin**:
  - Type: bool
  - Default: true
- **CheckOrientation**:
  - Type: bool
  - Default: true
- **Modal**:
  - Type: bool
  - Default: true
- **Guides**:
  - Type: bool
  - Default: true
- **Center**:
  - Type: bool
  - Default: true
- **Highlight**:
  - Type: bool
  - Default: true
- **Background**:
  - Type: bool
  - Default: true
- **AutoCrop**:
  - Type: bool
  - Default: true
- **AutoCropArea**:
  - Type: double
  - Default: 0.8
- **Movable**:
  - Type: bool
  - Default: true
- **Rotatable**:
  - Type: bool
  - Default: true
- **Scalable**:
  - Type: bool
  - Default: true
- **Zoomable**:
  - Type: bool
  - Default: true
- **ZoomOnTouch**:
  - Type: bool
  - Default: true
- **ZoomOnWheel**:
  - Type: bool
  - Default: true
- **WheelZoomRatio**:
  - Type: double
  - Default: 0.1
- **CropBoxMovable**:
  - Type: bool
  - Default: true
- **CropBoxResizable**:
  - Type: bool
  - Default: true
- **ToggleDragModeOnDblclick**:
  - Type: bool
  - Default: true
- **MinContainerWidth**:
  - Type: double
  - Default: 200
- **MinContainerHeight**:
  - Type: double
  - Default: 100
- **MinCanvasWidth**:
  - Type: double
  - Default: 0
- **MinCanvasHeight**:
  - Type: double
  - Default: 0
- **MinCropBoxWidth**:
  - Type: double
  - Default: 0
- **MinCropBoxHeight**:
  - Type: double
  - Default: 0

### CropCanvasOptions
---
Options for `GetCroppedAreaBase64(options)`, `GetCroppedAreaBlobUri(options)` and `GetCroppedAreaStream(options)`. See the [Cropper.js getCroppedCanvas options](https://github.com/fengyuanchen/cropperjs/blob/v1/README.md#getcroppedcanvasoptions).
- **Width / Height**: Destination size of the output canvas.
- **MinWidth / MinHeight / MaxWidth / MaxHeight**: Size limits (defaults: 0 / Infinity).
- **FillColor**: Fill for alpha values (default: `"transparent"`).
- **ImageSmoothingEnabled** (default: true) / **ImageSmoothingQuality** (`low`, `medium`, `high`; default: `low`).
- **Rounded** (default: false): Use rounded values.

### Events
---
The following events are available to use atm. To read more about them consider using the official [Cropper.js documentation](https://github.com/fengyuanchen/cropperjs/blob/main/README.md#events)

- **Ready**:
  - This event fires when the target image has been loaded and the cropper instance is ready for operating.
- **OnZoom**:
  - This event fires when the cropper instance starts to zoom in or zoom out its canvas (image wrapper).
- **OnCrop**:
  - This event fires when the canvas (image wrapper) or the crop box changes.

## Important (When using the Base64 methods) - Its recommended to use the Stream method to avoid this.
Because Cropper returns an base64 string of the cropped image, the data can get very large for the SignalR connection.
To prevent this, either use `GetCroppedAreaStream(new CropCanvasOptions())` with `OpenReadStreamAsync()`, or increase the max size of the SignalR connection in your Startup.cs.
```CSharp
services.AddSignalR(options =>
{
    options.MaximumReceiveMessageSize =  // 10MB for example 
});
```

## Roadmap

- [x] Add Cropper.js
- [ ] Add more Methods
- [X] Add last Options
  - [X] Preview
  - [X] CropBox and Canvas height, width
- [X] Add Events
- [ ] Add more Examples
  - [ ] Add ready to use MudBlazor component
  - [ ] Add ready to use html component

## Built With

* [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) - The web framework used
* [CSharp](https://docs.microsoft.com/en-us/dotnet/csharp/) - The programming language used
* [Dotnet](https://dotnet.microsoft.com/) - The framework used
* [Cropper.js](https://fengyuanchen.github.io/cropperjs/) - JavaScript image cropper

## Authors

* **Json-exe** - *Initial work* - [Json-exe](https://github.com/Json-exe)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Closing Words
Feel free to use this project. As this is my first Nuget project I would appreciate feedback in the form of feature requests or bugs.
