using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenite.Tests.Shared.Hosting;
using OpenQA.Selenite.Tests.Shared.Pages.Implementation;
using OpenQA.Selenite.Extensions;
using OpenQA.Selenite.Setup;
using OpenQA.Selenite.Setup.Environments;

// ReSharper disable InconsistentNaming

namespace OpenQA.Selenite.Tests.Setup.SessionTests
{
    [TestFixture]
    public class Given_page_without_jQuery : HostThreadedSessionFixture
    {
        public override void Before()
        {
            Threaded<Session>
                .With<PhantomJS>()
                .NavigateTo<PageWithJQuery>(Url("Checkbox.html"));
        }

        [Test]
        public void Given_page_should_not_have_jQuery()
        {
            Threaded<Session>
                .CurrentBlock<PageWithJQuery>()
                .Session.HasJQuery()
                .Should().BeFalse();
        }
    }
}