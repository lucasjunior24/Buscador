
using Buscador.Utils.ApiClient;

using System.Net;
using System.Net.Http;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;
using Refit;
using System;
using System.Diagnostics;

namespace Buscador.Extensions
{
    public static class ApiClientExtensions
    {
        public static void AddApiClients(this IServiceCollection services, IConfiguration configuration)
        {
            var serviceProvider = services.BuildServiceProvider();
            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
            var httpContext = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            var logger = loggerFactory.CreateLogger("ApiClient");

            services.AddRefitClient<IViaCepClient>()
                .AddPolicyHandler(ObterPolicy(logger))
                .ConfigureHttpClient(
                    c =>
                    {
                        c.BaseAddress = new Uri(configuration["UrlViaCep"]);
                    });
        }

        [DebuggerStepThrough]
        private static AsyncRetryPolicy<HttpResponseMessage> ObterPolicy(ILogger logger)
        {
            return Policy
                .HandleResult<HttpResponseMessage>(
                    r => r.StatusCode == HttpStatusCode.GatewayTimeout ||
                    r.StatusCode == HttpStatusCode.RequestTimeout ||
                    r.StatusCode == HttpStatusCode.InternalServerError)
                .RetryAsync(3, onRetry: async (message, retryCount) =>
                {
                    logger.LogError(message.Exception, $"Falha ao consumir {message.Result.RequestMessage.RequestUri} ({message.Result.ReasonPhrase}) - {await message.Result.Content.ReadAsStringAsync()}. Fazendo outra tentativa ({retryCount}).");
                });
        }
    }
}
