using System;
using System.IO;
using System.Reflection;
using Nancy;
using Nancy.Conventions;
using NUnit.Framework;

namespace OpenQA.Selenite.Tests.Shared.Hosting
{
    [TestFixture]
    public abstract class HostTestFixture
    {
        private IHost _host;

        protected HostTestFixture() : this("http://localhost:8888/nancy/")
        {
        }

        protected HostTestFixture(string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        [OneTimeSetUp]
        public virtual void Init()
        {
            _host = new Host(new Uri(BaseUrl));
            _host.Start();
        }

        [OneTimeTearDown]
        public virtual void Dispose()
        {
            _host.Stop();
        }

        protected string GetUrl(string page)
        {
            return string.Format("{0}{1}{2}", BaseUrl, "content/", page);
        }

        protected string Url(string page)
        {
            return $"{BaseUrl}content/{page}";
        }

        protected string BaseUrl { get; private set; }
    }

    

}