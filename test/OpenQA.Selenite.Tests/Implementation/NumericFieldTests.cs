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
    public class Given_numeric_field : HostThreadedSessionFixture
    {
        public override void Before()
        {
            Threaded<Session>
                .With<PhantomJS>()
                .NavigateTo<NumericFieldPage>(Url("NumericField.html"));
        }
        
        [Test]
        public void When_entering_number_Then_text_and_value_work()
        {
            Threaded<Session>
                .CurrentBlock<NumericFieldPage>()
                .Number.EnterNumber(5)
                .VerifyThat(x => x.Number.Value.Should().Be(5))
                .VerifyThat(x => x.Number.Text.Should().Be("5"));
        }
    }
}