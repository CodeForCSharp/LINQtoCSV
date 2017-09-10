using System;
using System.Globalization;

namespace LINQtoCSV
{
    /// <summary>
    ///     Summary description for CsvColumnAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)
    ]
    public class CsvColumnAttribute : Attribute
    {
        internal const int mc_DefaultFieldIndex = int.MaxValue;

        public CsvColumnAttribute()
        {
            Name = "";
            FieldIndex = mc_DefaultFieldIndex;
            CanBeNull = true;
            NumberStyle = NumberStyles.Any;
            OutputFormat = "G";
        }

        public CsvColumnAttribute(
            string name,
            int fieldIndex,
            bool canBeNull,
            string outputFormat,
            NumberStyles numberStyle,
            int charLength)
        {
            Name = name;
            FieldIndex = fieldIndex;
            CanBeNull = canBeNull;
            NumberStyle = numberStyle;
            OutputFormat = outputFormat;

            CharLength = charLength;
        }

        public string Name { get; set; }
        public bool CanBeNull { get; set; }
        public int FieldIndex { get; set; }
        public NumberStyles NumberStyle { get; set; }
        public string OutputFormat { get; set; }
        public int CharLength { get; set; }
    }
}