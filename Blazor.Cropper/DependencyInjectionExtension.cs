using Microsoft.Extensions.DependencyInjection;

namespace Json_exe.Blazor.Cropper;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddCropper(this IServiceCollection services)
    {
        services.AddScoped<CropperJsInterop>();
        return services;
    }
}