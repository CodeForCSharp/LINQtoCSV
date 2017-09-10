using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LINQtoCSV.Tests
{
// Because the fields in this type are used only indirectly, the compiler
// will warn they are unused or unassigned. Disable those warnings.
#pragma warning disable 0169, 0414, 0649

    internal class ProductDataSpecificFieldIndex : IAssertable<ProductDataSpecificFieldIndex>
    {
        public void AssertEqual(ProductDataSpecificFieldIndex other)
        {
            Assert.AreNotEqual(other, null);

            Assert.AreEqual(other.name, name, "name");
            Assert.AreEqual(other.startDate, startDate, "startDate");
            Assert.AreEqual(other.weight, weight, "weight");
        }

        [CsvColumn(FieldIndex = 1)] public string name;

        // OutputFormat uses the same codes as the standard ToString method (search MSDN).
        [CsvColumn(FieldIndex = 4, OutputFormat = "MM/dd/yy")] public DateTime startDate;

        // Can use both fields and properties
        [CsvColumn(FieldIndex = 3, CanBeNull = false)]
        public double weight { get; set; }

    }

    internal class ProductDataCharLength : IAssertable<ProductDataCharLength>
    {
        [CsvColumn(FieldIndex = 1, CharLength = 8)] public string name;

        [CsvColumn(FieldIndex = 3, OutputFormat = "MM/dd/yy", CharLength = 8)] public DateTime startDate;

        // Can use both fields and properties
        [CsvColumn(FieldIndex = 2, CanBeNull = false, CharLength = 6)]
        public double weight { get; set; }

        public void AssertEqual(ProductDataCharLength other)
        {
            Assert.AreNotEqual(other, null);

            Assert.AreEqual(other.name, name, "name");
            Assert.AreEqual(other.startDate, startDate, "startDate");
            Assert.AreEqual(other.weight, weight, "weight");
        }

        // OutputFormat uses the same codes as the standard ToString method (search MSDN).
    }

    internal class ProductDataParsingOutputFormat : IAssertable<ProductDataParsingOutputFormat>
    {
        public void AssertEqual(ProductDataParsingOutputFormat other)
        {
            Assert.AreNotEqual(other, null);

            Assert.AreEqual(other.name, name, "name");
            Assert.AreEqual(other.startDate, startDate, "startDate");
        }

        [CsvColumn(FieldIndex = 1)] public string name;

        // OutputFormat uses the same codes as the standard ToString method (search MSDN).
        [CsvColumn(FieldIndex = 2, OutputFormat = "MMddyy")] public DateTime startDate;
    }
}