using System.Collections.Generic;
using OpenQA.Selenite.Implementation;

namespace OpenQA.Selenite.Interfaces
{
    public interface ITable
    {
        IEnumerable<string> Headers { get; }
        IEnumerable<ITableRow> Rows { get; }
        IEnumerable<string> Footers { get; }
        T HeaderAs<T>() where T : Element;
        IEnumerable<T> RowsAs<T>() where T : Element;
        T FooterAs<T>() where T : Element;
    }
}