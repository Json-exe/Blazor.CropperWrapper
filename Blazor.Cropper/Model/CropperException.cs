namespace Json_exe.Blazor.Cropper.Model;

/// <summary>
/// Represents an exception that occurs in the Cropper functionality within the Blazor component.
/// </summary>
/// <remarks>
/// This exception is thrown when an error specific to CropperJS operations happens. It can encapsulate
/// a custom error message and an optional inner exception to provide more detailed error context.
/// </remarks>
public sealed class CropperException : Exception
{
    /// <summary>
    /// Represents an exception that occurs specifically within the Cropper functionality in Blazor.
    /// </summary>
    /// <remarks>
    /// This exception is used to capture and handle errors that arise from operations performed
    /// by the Cropper functionality, such as invoking JS interops or working with cropper-specific
    /// data. It supports providing a detailed error message and an optional inner exception for
    /// further context.
    /// </remarks>
    public CropperException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}