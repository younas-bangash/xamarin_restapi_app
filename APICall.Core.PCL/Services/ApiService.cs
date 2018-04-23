using System;
using System.Net.Http;
using Fusillade;
using ModernHttpClient;
using Refit;

namespace RefitXFSample.Services
{
    public class ApiService<T> : IApiService<T>
    {
        Func<HttpMessageHandler, T> createClient;

        public ApiService(string apiBaseAddress)
        {

            // Create new HttpClient with the priprity which is specified

            createClient = messageHandler =>
            {
                var client = new HttpClient(messageHandler)
                {
                    BaseAddress = new Uri(apiBaseAddress)
                };

                return RestService.For<T>(client);
            };
        }

        // Lazy initialization of an object means that its creation is deferred until it is first used.
        private T Background
        {
            get
            {
                return new Lazy<T>(() => createClient( new RateLimitedHttpMessageHandler(new NativeMessageHandler(),Priority.Background))).Value;
            }
        }

        private T UserInitiated
        {
            get
            {
                return new Lazy<T>(() => createClient(new RateLimitedHttpMessageHandler(new NativeMessageHandler(),
                    Priority.UserInitiated))).Value;
            }
        }

        private T Speculative
        {
            get
            {
                return new Lazy<T>(() => createClient(new RateLimitedHttpMessageHandler(new NativeMessageHandler(),
                    Priority.Speculative))).Value;
            }
        }


        // Funtion implementation of the interface
        public T GetApi(Priority priority)
        {
            switch (priority)
            {
                case Priority.Background:
                    return Background;
                case Priority.UserInitiated:
                    return UserInitiated;
                case Priority.Speculative:
                    return Speculative;
                default:
                    return UserInitiated;
            }
        }

    }
}

