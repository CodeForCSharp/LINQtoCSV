namespace LINQtoCSV
{
    public class DataRowItem
    {
        public DataRowItem(string value, int lineNbr)
        {
            Value = value;
            LineNbr = lineNbr;
        }

        public int LineNbr { get; }

        public string Value { get; }
    }
}