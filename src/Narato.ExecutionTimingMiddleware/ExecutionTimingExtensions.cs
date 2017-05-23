using Microsoft.AspNetCore.Builder;
using Narato.ExecutionTimingMiddleware.Middleware;
using System;

namespace Narato.ExecutionTimingMiddleware
{
    public static class ExecutionTimingExtensions
    {
        public static IApplicationBuilder UseExecutionTiming(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            return app.UseMiddleware<AddExecutionTimingMiddleware>();
        }
    }
}
