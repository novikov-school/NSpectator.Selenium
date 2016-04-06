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
    class Describe_numeric_field : Spec_hosted
    {
        void before_each()
        {
            Browse<NumericFieldPage>("NumericField.html");
        }

        void Given_page_should_have_working_field()
        {
            context["When entering number then"] = () =>
            {
                it["should contains entered text and number"] = () =>
                {
                    Block<NumericFieldPage>()
                        .Number.EnterNumber(5)
                        .VerifyThat(x => x.Number.Value.Should().Be(5))
                        .VerifyThat(x => x.Number.Text.Should().Be("5"));
                };
            };
        }
    }
}