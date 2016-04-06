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

namespace OpenQA.Selenite.Tests.Specs.Setup
{
    class Describe_page_with_jQuery : Spec_hosted
    {
        void Given_page_has_jquery()
        {
            before = () => Browse<PageWithJQuery>("PageWithJQuery.html");

            it["should have jQuery variable"] = () =>
            {
                // element<PageWithJQuery>().Session.HasJQuery().should_be_true();
                Block<PageWithJQuery>().Session.HasJQuery().Should().Be(true, "because there is jQuery included on page");
            };
        }
    }
}