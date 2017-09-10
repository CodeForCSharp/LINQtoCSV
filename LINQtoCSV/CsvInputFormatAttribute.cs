using System;
using System.Globalization;

namespace LINQtoCSV
{
    /// <summary>
    ///     Summary description for CsvInputFormat
    /// </summary>
    [AttributeUsage(AttributeTargets.Field |
                    AttributeTargets.Property)
    ]
    public class CsvInputFormatAttribute : Attribute
    {
        public CsvInputFormatAttribute(NumberStyles numberStyle)
        {
            NumberStyle = numberStyle;
        }

        public NumberStyles NumberStyle { get; set; }
    }
}