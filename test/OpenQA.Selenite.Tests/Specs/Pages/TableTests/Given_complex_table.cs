#region [R# naming]
// ReSharper disable ArrangeTypeModifiers
// ReSharper disable UnusedMember.Local
// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable InconsistentNaming
#endregion
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenite.Extensions;
using OpenQA.Selenite.Setup;
using OpenQA.Selenite.Setup.Environments;
using OpenQA.Selenite.Tests.Shared.Hosting;
using OpenQA.Selenite.Tests.Shared.Pages.Implementation;

namespace OpenQA.Selenite.Tests.Specs.Pages.TableTests
{
    [TestFixture(Ignore = true)]
    public class Given_complex_table : Spec_hosted
    {
        void before_each()
        {
            NavigateTo<ComplexTablePage>(Url("ComplexTable.html"));
        }

        
        [TestCase("Water", false)]
        [TestCase("Beer", false)]
        [TestCase("Wine", true)]
        public void Should_go_to_radio_button_page_when_radio_link_is_clicked(string text, bool expected)
        {
            Threaded<Session>
                .CurrentBlock<ComplexTablePage>()
                .Table
                .RowsAs<ComplexTableRow>().First()
                .RadioButtonPageLink.Click()
                .VerifyThat(p =>
                    p.Beverages.Options.WithText(text).Single().Selected
                        .Should().Be(expected)
                );
        }

        [Test]
        public void Should_contain_two_columns()
        {
            Threaded<Session>
                .CurrentBlock<ComplexTablePage>()
                .Table
                .VerifyThat(x => x.Headers
                    .Count()
                    .Should()
                    .Be(2));
        }

        [Test]
        public void Should_contain_two_rows()
        {
            Threaded<Session>
                .CurrentBlock<ComplexTablePage>()
                .Table
                .VerifyThat(x => x.Rows
                    .Count()
                    .Should()
                    .Be(2));
        }

        [Test]
        public void Should_go_to_table_page_when_table_link_is_clicked()
        {
            Threaded<Session>
                .CurrentBlock<ComplexTablePage>()
                .Table
                .RowsAs<ComplexTableRow>().First()
                .TablePageLink.Click()
                .Table
                .VerifyThat(x => x.Rows
                    .Count()
                    .Should()
                    .Be(3));
        }
    }
}