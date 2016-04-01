using System;
using Nancy.Hosting.Self;

namespace OpenQA.Selenite.Tests.Shared.Hosting
{
    public class Host : IHost
    {
        private readonly NancyHost _host;

        public Host(Uri baseUri)
        {
            var hostConfiguration = new HostConfiguration
            {
                UrlReservations = new UrlReservations
                {
                    CreateAutomatically = true
                }
            };
            _host = new NancyHost(hostConfiguration, baseUri);
        }

        public void Start()
        {
            _host.Start();
        }

        public void Stop()
        {
            _host.Stop();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        ~Host()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose managed resources

                _host.Stop();

                _host.Dispose();
            }

            // dispose native resources
        }
    }
}