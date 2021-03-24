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

            string name = context.Request.Query["name"];
            string time = Convert.ToString(DateTime.Now);

            if (!string.IsNullOrWhiteSpace(name))
            {
                context.Request.Headers.Add("name", name);
                context.Request.Headers.Add("time", time);
            }

            await context.Response.WriteAsync($"<h1>Name: {name}</h1><h1>Registed at: {time}</h1><h1>Took: {sw.ElapsedMilliseconds}</h1>");
            await _next(context);
        }
    }
}