namespace Json_exe.Blazor.Cropper.Model;

public sealed class CropperException : Exception
{
    public CropperException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}