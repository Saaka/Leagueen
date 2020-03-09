using Hangfire.Annotations;
using Hangfire.Dashboard;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Leagueen.Infrastructure.Providers.IdentityIssuer;

namespace Leagueen.WebAPI.Configuration.HangfireConfig
{
    public class HangrireDashboardAuthFilter : IDashboardAuthorizationFilter
    {
        private const string BasicAuthScheme = "Basic";

        public bool Authorize([NotNull] DashboardContext context)
        {
            var httpContext = context.GetHttpContext();

            var header = httpContext.Request.Headers["Authorization"];

            if (string.IsNullOrWhiteSpace(header))
            {
                SetChallengeResponse(httpContext);
                return false;
            }
            var authValues = System.Net.Http.Headers.AuthenticationHeaderValue.Parse(header);

            if (!BasicAuthScheme.Equals(authValues.Scheme, StringComparison.InvariantCultureIgnoreCase))
            {
                SetChallengeResponse(httpContext);
                return false;
            }

            var parameter = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(authValues.Parameter));
            var parts = parameter.Split(':');

            if (parts.Length < 2)
            {
                SetChallengeResponse(httpContext);
                return false;
            }

            var email = parts[0];
            var password = parts[1];

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                SetChallengeResponse(httpContext);
                return false;
            }

            if (ValidateUser(email, password, httpContext))
            {
                return true;
            }

            SetChallengeResponse(httpContext);
            return false;
        }

        private bool ValidateUser(string email, string password, HttpContext httpContext)
        {
            var identityIssuer = httpContext.RequestServices.GetService<IIdentityIssuer>();

            try
            {
                var user = identityIssuer.AuthUserByCredentials(email, password).Result;
                return user != null && user.IsAdmin;
            }
            catch
            {
                return false;
            }
        }

        private void SetChallengeResponse(HttpContext httpContext)
        {
            httpContext.Response.StatusCode = 401;
            httpContext.Response.Headers.Append("WWW-Authenticate", "Basic realm=\"Hangfire Dashboard\"");
            httpContext.Response.WriteAsync("Authentication is required.");
        }
    }
}
