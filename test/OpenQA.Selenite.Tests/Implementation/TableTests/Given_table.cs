using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenite.Tests.Shared.Hosting;
using OpenQA.Selenite.Tests.Shared.Pages.Implementation;
using OpenQA.Selenite.Extensions;
using OpenQA.Selenite.Setup;
using OpenQA.Selenite.Setup.Environments;

namespace OpenQA.Selenite.Tests.Implementation.TableTests
{
    public class TableRow
    {
        public string Item { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }

    // ReSharper disable InconsistentNaming

    [TestFixture]
    public class Given_table : HostThreadedSessionFixture
    {
        public override void Before()
        {
            Threaded<Session>
                .With<PhantomJS>()
                .NavigateTo<TablePage>(Url("Table.html"));
        }
        
        [Test]
        public void Should_contain_first_row_with_first_column_of_wine()
        {
            Threaded<Session>
                .CurrentBlock<TablePage>()
                .Table
                .VerifyThat(x => x.Rows
                    .First()[0]
                    .Should()
                    .Be("Wine"));
        }

        [Test]
        public void Should_contain_first_row_with_item_of_wine()
        {
            Threaded<Session>
                .CurrentBlock<TablePage>()
                .Table
                .VerifyThat(x => x.Rows
                    .First()["Item"]
                    .Should()
                    .Be("Wine"));
        }

        [Test]
        public void Should_contain_first_row_with_price_of_65()
        {
            Threaded<Session>
                .CurrentBlock<TablePage>()
                .Table
                .VerifyThat(x => x.Rows
                    .First()["Price"]
                    .Should()
                    .Be("65.00"));
        }

        [Test]
        public void Should_contain_first_row_with_quantity_of_four()
        {
            Threaded<Session>
                .CurrentBlock<TablePage>()
                .Table
                .VerifyThat(x => x.Rows
                    .First()["Quantity"]
                    .Should()
                    .Be("4"));
        }

        [Test]
        public void Should_contain_first_row_with_second_column_of_four()
        {
            Threaded<Session>
                .CurrentBlock<TablePage>()
                .Table
                .VerifyThat(x => x.Rows
                    .First()[1]
                    .Should()
                    .Be("4"));
        }

        [Test]
        public void Should_contain_first_row_with_third_column_of_65()
        {
            Threaded<Session>
                .CurrentBlock<TablePage>()
                .Table
                .VerifyThat(x => x.Rows
                    .First()[2]
                    .Should()
                    .Be("65.00"));
        }

        [Test]
        public void Should_contain_three_columns()
        {
            Threaded<Session>
                .CurrentBlock<TablePage>()
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
                .CurrentBlock<TablePage>()
                .Table
                .VerifyThat(x => x.Rows
                    .Count()
                    .Should()
                    .Be(3));
        }
    }
}