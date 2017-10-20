﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Saule.Http;

namespace Saule.AspNetCore.Tests.Helpers
{
    public class JsonApiServer : IDisposable
    {
        private readonly TestServer _server;

        public JsonApiServer()
            : this(new JsonApiConfiguration())
        {
        }

        internal JsonApiServer(JsonApiConfiguration config)
        {
            _server = new TestServer(new WebHostBuilder()
                .ConfigureServices(s => s
                    .AddSingleton(config))
                .UseStartup<Startup>());
        }

        public HttpClient GetClient()
        {
            var client = _server.CreateClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.MediaType));

            return client;
        }

        public void Dispose()
        {
            _server.Dispose();
        }

        public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddJsonApi();
            }

            public void Configure(IApplicationBuilder app,
                IHostingEnvironment env,
                ILoggerFactory loggerFactory)
            {
                app.UseMvcWithDefaultRoute();
            }
        }
    }
}