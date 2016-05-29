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
    // ReSharper disable InconsistentNaming

    [TestFixture, Ignore("Broken page")]
    public class Given_generic_table : HostThreadedSessionFixture
    {
        public override void Before()
        {
            Threaded<Session>
                .With<PhantomJS>()
                .NavigateTo<GenericTablePage>(Url("Table.html"));
        }
        
        [Test]
        public void Should_contain_first_row_with_item_of_wine()
        {
            Threaded<Session>
                .CurrentBlock<GenericTablePage>()
                .Table
                .VerifyThat(x => x.RowsAs<GenericTableRow>()
                    .First()
                    .Item
                    .Should()
                    .Be("Wine"));
        }

        [Test]
        public void Should_contain_first_row_with_price_of_65()
        {
            Threaded<Session>
                .CurrentBlock<GenericTablePage>()
                .Table
                .VerifyThat(x => x.RowsAs<GenericTableRow>()
                    .First()
                    .Price
                    .Should()
                    .Be(65.00m));
        }

        [Test]
        public void Should_contain_first_row_with_quantity_of_four()
        {
            Threaded<Session>
                .CurrentBlock<GenericTablePage>()
                .Table
                .VerifyThat(x => x.RowsAs<GenericTableRow>()
                    .First()
                    .Quantity
                    .Should()
                    .Be(4));
        }

        [Test]
        public void Should_contain_three_columns()
        {
            Threaded<Session>
                .CurrentBlock<GenericTablePage>()
                .Table
                .VerifyThat(x => x.Headers
                    .Count()
                    .Should()
                    .Be(3));
        }

        [Test]
        public void Should_contain_three_rows()
        {
            Threaded<Session>
                .CurrentBlock<GenericTablePage>()
                .Table
                .VerifyThat(x => x.Rows
                    .Count()
                    .Should()
                    .Be(3));
        }
    }
}