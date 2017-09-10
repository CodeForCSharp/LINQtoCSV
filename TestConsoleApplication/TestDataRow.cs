using System.Collections.Generic;
using System.Text;
using LINQtoCSV;

namespace TestConsoleApplication
{
    internal class TestDataRow : List<DataRowItem>, IDataRow
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < Count; i++)
            {
                sb.AppendLine(string.Format("{0}) line: {1}, value: {2}", i, this[i].LineNbr, this[i].Value));
                sb.AppendLine("--------------");
            }

            return sb.ToString();
        }
    }
}