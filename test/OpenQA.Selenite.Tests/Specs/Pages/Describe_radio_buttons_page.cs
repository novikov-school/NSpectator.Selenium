#region [R# naming]
// ReSharper disable ArrangeTypeModifiers
// ReSharper disable UnusedMember.Local
// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable InconsistentNaming
#endregion
using FluentAssertions;
using OpenQA.Selenite.Tests.Shared.Pages.Implementation;
using OpenQA.Selenite.Extensions;

namespace OpenQA.Selenite.Tests.Specs.Pages
{
    class Describe_radio_buttons_page : Spec_hosted
    {
        void before_each()
        {
            NavigateTo<RadioButtonsPage>("RadioButtons.html");
        }

        void Given_test_option_does_not_exist()
        {
            context["When selecting by text"] = () =>
            {
                it["should not find any"] = () =>
                {
                    element<RadioButtonsPage>()
                        .VerifyThat(p => p.Beverages
                            .Options.WithText("Test")
                            .Should().BeEmpty());
                };
            };
            
        }
    }
}