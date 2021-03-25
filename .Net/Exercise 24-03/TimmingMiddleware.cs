using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CustomMiddleware.Middleware
{
    public class TimmingMiddleware
    {
        private readonly RequestDelegate _next;
        public TimmingMiddleware(RequestDelegate next) => _next = next;
        public async Task Invoke(HttpContext context)
        {
            var sw = new Stopwatch();
            sw.Start();

            Console.WriteLine($"URL: {context.Request.Scheme}://{context.Request.Host}{context.Request.Path}{context.Request.QueryString}");
            Console.WriteLine($"Took: {sw.ElapsedMilliseconds.ToString()}");
            await _next(context);
        }
    }
}