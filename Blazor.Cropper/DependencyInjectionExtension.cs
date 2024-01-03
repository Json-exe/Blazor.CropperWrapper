using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Cropper;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddCropper(this IServiceCollection services)
    {
        services.AddScoped<CropperJsInterop>();
        return services;
    }
}