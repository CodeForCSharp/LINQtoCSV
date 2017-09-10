using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LINQtoCSV.Tests
{
    public abstract class Test
    {
        /// <summary>
        ///     Takes a string and converts it into a StreamReader.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        protected StreamReader StreamReaderFromString(string s)
        {
            var stringAsByteArray = Encoding.UTF8.GetBytes(s);
            Stream stream = new MemoryStream(stringAsByteArray);

            var streamReader = new StreamReader(stream, Encoding.UTF8);
            return streamReader;
        }

        protected void AssertCollectionsEqual<T>(IEnumerable<T> actual, IEnumerable<T> expected)
            where T : IAssertable<T>
        {
            var count = actual.Count();
            Assert.AreEqual(count, expected.Count(), "counts");

            for (var i = 0; i < count; i++)
                actual.ElementAt(i).AssertEqual(expected.ElementAt(i));
        }

        /// <summary>
        ///     Used to test the Read method.
        /// </summary>
        /// <typeparam name="T">
        ///     Type of the output elements.
        /// </typeparam>
        /// <param name="testInput">
        ///     String representing the contents of the file or StreamReader. This string is fed to the Read method
        ///     as though it came from a file or StreamReader.
        /// </param>
        /// <param name="fileDescription">
        ///     Passed to Read.
        /// </param>
        /// <returns>
        ///     Output of Read.
        /// </returns>
        public IEnumerable<T> TestRead<T>(string testInput, CsvFileDescription fileDescription) where T : class, new()
        {
            var cc = new CsvContext();
            return cc.Read<T>(StreamReaderFromString(testInput), fileDescription);
        }

        /// <summary>
        ///     Executes a Read and tests whether it outputs the expected records.
        /// </summary>
        /// <typeparam name="T">
        ///     Type of the output elements.
        /// </typeparam>
        /// <param name="testInput">
        ///     String representing the contents of the file or StreamReader. This string is fed to the Read method
        ///     as though it came from a file or StreamReader.
        /// </param>
        /// <param name="fileDescription">
        ///     Passed to Read.
        /// </param>
        /// <param name="expected">
        ///     Expected output.
        /// </param>
        public void AssertRead<T>(string testInput, CsvFileDescription fileDescription, IEnumerable<T> expected)
            where T : class, IAssertable<T>, new()
        {
            var actual = TestRead<T>(testInput, fileDescription);
            AssertCollectionsEqual(actual, expected);
        }

        /// <summary>
        ///     Used to test the Write method
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the input elements.
        /// </typeparam>
        /// <param name="values">
        ///     The collection of input elements.
        /// </param>
        /// <param name="fileDescription">
        ///     Passed directly to write.
        /// </param>
        /// <returns>
        ///     Returns a string with the content that the Write method writes to a file or TextWriter.
        /// </returns>
        public string TestWrite<T>(IEnumerable<T> values, CsvFileDescription fileDescription) where T : class
        {
            TextWriter stream = new StringWriter();
            var cc = new CsvContext();
            cc.Write(values, stream, fileDescription);
            return stream.ToString();
        }

        /// <summary>
        ///     Executes a Write and tests whether it outputs the expected records.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the input elements.
        /// </typeparam>
        /// <param name="values">
        ///     The collection of input elements.
        /// </param>
        /// <param name="fileDescription">
        ///     Passed directly to write.
        /// </param>
        /// <param name="expected">
        ///     Expected output.
        /// </param>
        public void AssertWrite<T>(IEnumerable<T> values, CsvFileDescription fileDescription, string expected)
            where T : class
        {
            var actual = TestWrite(values, fileDescription);
            Assert.AreEqual(Utils.NormalizeString(actual), Utils.NormalizeString(expected));
        }
    }
}