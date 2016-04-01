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

        public delegate void Establish();

        protected Establish start_host;
        protected Establish stop_host;
        protected Establish close_session;

        protected static Func<Session> phantomJs = () => Threaded<Session>.With<PhantomJS>();

        protected static TBlock NavigateTo<TBlock>(string path) where TBlock : IBlock
        {
            return phantomJs().NavigateTo<TBlock>(Url(path));
        }

        protected static TBlock element<TBlock>() where TBlock : IBlock
        {
            return Threaded<Session>.CurrentBlock<TBlock>();
        }

        void before_all()
        {
            start_host();
        }

        void after_all()
        {
            stop_host();
        }

        void after_each()
        {
            close_session();
        }

        public Spec_hosted() : this("http://localhost:8888/nancy/")
        {
            
        }

        public static Action when(params Establish[] actions)
        {
            return () =>
            {
                foreach (var action in actions)
                {
                    action();
                }
            };
        }

        public Spec_hosted(string baseUrl)
        {
            BaseUrl = baseUrl;

            start_host = () =>
            {
                _host = new Host(new Uri(BaseUrl));
                _host.Start();
            };

            stop_host = () =>
            {
                _host.Stop();
            };

            close_session = Threaded<Session>.End;
        }

        protected static string Url(string page)
        {
            return $"{BaseUrl}content/{page}";
        }

        private static string BaseUrl { get; set; }
    }
}