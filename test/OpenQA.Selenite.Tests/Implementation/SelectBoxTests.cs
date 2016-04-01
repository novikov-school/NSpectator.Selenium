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
    public class Given_select_box_with_ability_to_select_multiple_values : HostThreadedSessionFixture
    {
        public override void Before()
        {
            Threaded<Session>
                .With<PhantomJS>()
                .NavigateTo<MultiSelectPage>(Url("MultiSelect.html"));
        }
        
        [Test]
        public void When_selecting_and_deselecting_a_value_Then_nothing_is_selected()
        {
            Threaded<Session>
                .CurrentBlock<MultiSelectPage>()
                .Toppings.Options.First().Click()
                .VerifyThat(p => p.Toppings.Options
                    .Count(x => x.Selected)
                    .Should().Be(1))
                .Toppings.Options.First().Click()
                .VerifyThat(p => p.Toppings.Options
                    .Count(x => x.Selected)
                    .Should().Be(0));
        }

        [Test]
        public void When_selecting_multiple_values_Then_selection_occurs()
        {
            Threaded<Session>
                .CurrentBlock<MultiSelectPage>()
                .Toppings.Options.First().Click()
                .Toppings.Options.Last().Click()
                .VerifyThat(p => p.Toppings.Options
                    .Count(x => x.Selected)
                    .Should().Be(2))
                .VerifyThat(p => p.Toppings.Options
                    .First().Selected
                    .Should().BeTrue())
                .VerifyThat(p => p.Toppings.Options
                    .Last().Selected
                    .Should().BeTrue());
        }
    }
}