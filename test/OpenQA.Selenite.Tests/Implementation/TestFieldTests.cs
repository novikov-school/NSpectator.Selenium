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
    public class Given_text_field : HostThreadedSessionFixture
    {
        public override void Before()
        {
            Threaded<Session>
                .With<PhantomJS>()
                .NavigateTo<DateFieldPage>(Url("TextField.html"));
        }
        
        [Test]
        public void When_entering_text_Then_text_should_work()
        {
            const string expectedText = "This is the text.";

            Threaded<Session>
                .CurrentBlock<TextFieldPage>()
                .Text.EnterText(expectedText)
                .VerifyThat(x => x.Text.Text.Should().Be(expectedText));
        }
    }
}