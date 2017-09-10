using System;

namespace LINQtoCSV
{
    /// <summary>
    ///     Summary description for FieldFormat
    /// </summary>
    [AttributeUsage(AttributeTargets.Field |
                    AttributeTargets.Property)
    ]
    public class CsvOutputFormatAttribute : Attribute
    {
        public CsvOutputFormatAttribute(string format)
        {
            Format = format;
        }

        public string Format { get; set; }
    }
}