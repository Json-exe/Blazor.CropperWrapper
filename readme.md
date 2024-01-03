# Json_exe.Blazor.CropperWrapper <!-- omit from toc -->

Enhance your .NET Blazor applications with seamless image cropping functionality using Json_exe.Blazor.CropperWrapper, a comprehensive .NET Blazor wrapper for the Cropper.js library. This package lets you effortlessly integrate a customizable Cropper UI, leveraging the robust features of Cropper.js.

## Table of Contents
- [Table of Contents](#table-of-contents)
- [Introduction](#introduction)
- [Getting Started](#getting-started)
- [Preview](#preview)
- [Example in a MudBlazor Application](#example-in-a-mudblazor-application)
- [Usage](#usage)
  - [Interactive Methods](#interactive-methods)
  - [Options](#options)
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
5. Create your UI with buttons and other controls to interact with the Cropper methods.
6. Refer to [Usage and Features](#usage-and-features) for detailed information on methods and options.

## Preview

## Example in a MudBlazor Application
```CSharp
<CropperWrapper Options="new CropperOptions { AspectRatio = 1, ViewMode = 1 }" ImageSrc="@ImageData" @ref="@CropperRef" Alt="Example-Alt"/>
<MudDivider FlexItem Class="my-2"/>
<MudStack Row Spacing="5">
    <MudButton Variant="Variant.Filled" OnClick="@(() => GetCroppedArea())">Crop!</MudButton>
</MudStack>
```
In this example the Button calls the Method GetCroppedArea() which crops the image inside the Cropper Canva and replaces it witht the cropped version.

## Usage

### Interactive Methods
The following methods are available to use atm.
- **GetCroppedArea()**: 
  - Crops the image with the selected Area and places the cropped image in the Canvas. The image before will be stored in a list to go back to that state.
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
- **GoBack()**:
  - Goes back to the previous state of the image inside the changes list.

### Options
---
The following options are available to use atm. To read more about them consider using the official [Cropper.js documentation](https://github.com/fengyuanchen/cropperjs/blob/main/README.md#options)
- **ViewMode**:
  - Type: int
  - Default: 0
- **DragMode**:
  - Type: string
  - Default: "crop"
- **InitialAspectRatio**:
  - Type: double
  - Default: double.NaN
- **AspectRatio**:
  - Type: double
  - Default: double.NaN
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
- **Moveable**:
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
- **ToggleDragModeOnDblclick**:
  - Type: bool
  - Default: true

## Roadmap

- [x] Add Cropper.js
- [ ] Add more Methods
- [ ] Add last Options
  - [ ] Preview
  - [ ] CropBox and Canvas height, width
- [ ] Add Events
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