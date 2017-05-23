using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Narato.ExecutionTimingMiddleware.Middleware
{
    public class AddExecutionTimingMiddleware
    {
        public const string EXECUTION_TIMING_HEADER_NAME = "Nar-Processing-Time-Milliseconds";

        private readonly RequestDelegate _next;

        public AddExecutionTimingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var sw = new Stopwatch();
            sw.Start();

            context.Response.OnStarting(() =>
            {
                sw.Stop();
                context.Response.Headers.Add(EXECUTION_TIMING_HEADER_NAME, sw.ElapsedMilliseconds.ToString());
                return Task.CompletedTask;
            });

            await _next(context);
        }
    }
}
