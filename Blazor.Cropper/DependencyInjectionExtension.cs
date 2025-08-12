using Microsoft.Extensions.DependencyInjection;

namespace Json_exe.Blazor.Cropper;

/// <summary>
/// Provides extension methods for dependency injection related to the Cropper component.
/// </summary>
public static class DependencyInjectionExtension
{
    /// <summary>
    /// Registers the required services for the CropperWrapper in the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection in which to register the services.</param>
    /// <returns>The IServiceCollection instance for chaining further configuration.</returns>
    public static IServiceCollection AddCropper(this IServiceCollection services)
    {
        services.AddScoped<CropperJsInterop>();
        return services;
    }
}