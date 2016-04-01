using System;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenite.Tests.Shared.Hosting;
using OpenQA.Selenite.Tests.Shared.Pages.Implementation;
using OpenQA.Selenite.Extensions;
using OpenQA.Selenite.Setup;
using OpenQA.Selenite.Setup.Environments;

namespace OpenQA.Selenite.Tests.Implementation
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    public class Given_date_field : HostThreadedSessionFixture
    {
        public override void Before()
        {
            Threaded<Session>
                .With<PhantomJS>()
                .NavigateTo<DateFieldPage>(Url("DateField.html"));
        }

        [Test]
        public void When_entering_date_Then_text_and_value_work()
        {
            Threaded<Session>
                .CurrentBlock<DateFieldPage>()
                .Date.EnterDate(DateTime.Today)
                .VerifyThat(x => x.Date.Value
                    .Should().Be(DateTime.Today))
                .VerifyThat(x => x.Date.Text
                    .Should().Be(DateTime.Today.ToString("yyyy-MM-dd")));
        }
    }
}