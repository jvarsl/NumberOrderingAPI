using System;
using Xunit;
using NumberOrderingAPI.Methods;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;

namespace NumberOrderingAPI.Tests
{
    public class ETLToolsTests
    {
        [Fact]
        public void Conversion_ShouldThrowErrorOnBadData()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => ETLTools.StringToBigIntArray(null));
            Assert.Throws<ArgumentException>(() => ETLTools.StringToBigIntArray("5 25 251 a52 a"));
        }

        [Fact]
        public void Conversion_ShouldReturnProperArray()
        {
            // Arrange
            var expected = new List<BigInteger>() { 5, 2, 8, 10, 1 };

            // Act
            var actual = ETLTools.StringToBigIntArray("5 2 8 10 1");
            var actualWithFormattingIssues = ETLTools.StringToBigIntArray("    5 2 8   10 1");

            // Assert
            Assert.Equal(expected, actual);
            Assert.Equal(expected, actualWithFormattingIssues);
        }

        [Fact]
        public void File_ShouldWriteIntoAndRead()
        {
            // Arrange
            var expected = "-5 2 6 9\n00:00:00.0000031";

            // Act
            ETLTools.WriteIntoFile(new List<BigInteger>() { -5, 2, 6, 9 });
            ETLTools.WriteIntoFile("00:00:00.0000031");
            var actual = ETLTools.ReturnFileContent();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
