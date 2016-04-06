#region [R# naming]
// ReSharper disable ArrangeTypeModifiers
// ReSharper disable UnusedMember.Local
// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable InconsistentNaming
#endregion
using System;
using NSpectator;
using OpenQA.Selenite.Tests.Shared.Hosting;
using OpenQA.Selenite.Interfaces;
using OpenQA.Selenite.Setup;
using OpenQA.Selenite.Setup.Environments;

namespace OpenQA.Selenite.Tests.Specs
{
    public class Spec_hosted : Spec
    {
        private IHost _host;

        protected Action StartHost => () =>
        {
            _host = new Host(new Uri(BaseUrl));
            _host.Start();
        };

        protected Action StopHost => () =>
        {
            _host.Stop();
        };

        protected Action CloseSession => Threaded<Session>.End;


        protected static Func<Session> StartPhantomJs = () => Threaded<Session>.With<PhantomJS>();

        protected static TBlock Browse<TBlock>(string path) where TBlock : IBlock
        {
            return StartPhantomJs().NavigateTo<TBlock>(Url(path));
        }

        protected static TBlock Block<TBlock>() where TBlock : IBlock
        {
            return Threaded<Session>.CurrentBlock<TBlock>();
        }

        void before_all()
        {
            StartHost();
        }

        void after_all()
        {
            StopHost();
        }

        void after_each()
        {
            CloseSession();
        }

        public Spec_hosted() : this("http://localhost:8888/nancy/")
        {
            
        }

        public Spec_hosted(string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        protected static string Url(string page)
        {
            return $"{BaseUrl}content/{page}";
        }

        private static string BaseUrl { get; set; }
    }
}