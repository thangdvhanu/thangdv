using Microsoft.AspNetCore.Builder;

namespace CustomMiddleware.Middleware
{
    public static class Extensions
    {
        public static IApplicationBuilder UseTimming(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimmingMiddleware>();
        }
    }
}