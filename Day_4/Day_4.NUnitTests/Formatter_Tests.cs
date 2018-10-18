using System;
using NUnit.Framework;

namespace Day_4.NUnitTests
{
    [TestFixture]
    public class Formatter_Tests
    {
        [Test]
        public void TransformToWords_Test()
        {
            string[] actual = Formatter.TransformToWords(new double[] { -2.123, 56.41, -1.349 });
            string[] expected = new string[] { "minus two point one two three", "five six point four one", "minus one point three four nine" };
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TransformToWords_NullTest()
        {
            Assert.Throws<ArgumentNullException>(() => Formatter.TransformToWords(null));
        }
    }
}