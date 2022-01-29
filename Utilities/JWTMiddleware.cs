using DAW.Services;
using DAW.Utilities.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Utilities
{
    public class JWTMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JWTMiddleware(IOptions<AppSettings> appSettings, RequestDelegate next)
        {
            _appSettings = appSettings.Value;
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IClientService clientService, IJWT jWT)
        {
            var token = httpContext.Request.Headers["Autorization"].FirstOrDefault()?.Split(' ').Last();

            var userId = jWT.ValidateJWTToken(token);

            if (userId != Guid.Empty)
            {
                httpContext.Items["User"] = clientService.FindById(userId);
            }

            await _next(httpContext);
        }
    }
}
