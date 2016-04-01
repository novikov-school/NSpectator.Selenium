using System.Linq;
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
    public class RadioButtonTests : HostThreadedSessionFixture
    {
        public override void Before()
        {
            Threaded<Session>
                .With<PhantomJS>()
                .NavigateTo<RadioButtonsPage>(Url("RadioButtons.html"));
        }

        [Test]
        public void Given_option_does_not_exist_When_selecting_by_text_Then_should_not_find_any()
        {
            Threaded<Session>
                .CurrentBlock<RadioButtonsPage>()
                .VerifyThat(p => p.Beverages
                    .Options.WithText("Test")
                    .Any()
                    .Should().BeFalse());
        }

        [TestCase("Water", false)]
        [TestCase("Beer", false)]
        [TestCase("Wine", true)]
        public void Given_option_exists_by_text_When_checking_if_selected_Then_returns_expected(string text,
            bool expected)
        {
            Threaded<Session>
                .CurrentBlock<RadioButtonsPage>()
                .VerifyThat(p => p.Beverages
                    .Options.WithText(text)
                    .First()
                    .Selected
                    .Should().Be(expected));
        }
    }
}