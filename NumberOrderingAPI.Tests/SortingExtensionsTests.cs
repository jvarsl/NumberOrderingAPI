using System;
using Xunit;
using NumberOrderingAPI.Methods;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;

namespace NumberOrderingAPI.Tests
{
    public class SortingExtensionsTests
    {
        [Fact]
        public void Sort_SqouldSortCorrectly()
        {
            // Arrange
            var random = new Random();
            var unsortedList = Enumerable.Range(0, random.Next(10, 100))
                .Select(x => (BigInteger)random.Next(int.MinValue, int.MaxValue))
                .ToList();
            var copyOfUnsortedList = new List<BigInteger>(unsortedList);
            var expectedList = unsortedList.OrderBy(x => x);

            // Act
            var actualBubble = SortingExtensions.BubbleSort(unsortedList);
            var actualSelection = SortingExtensions.SelectionSort(unsortedList);

            // Assert
            Assert.Equal(expectedList, actualBubble);
            Assert.Equal(expectedList, actualSelection);
            Assert.NotEqual(copyOfUnsortedList, actualSelection);
        }

        [Fact]
        public void Sort_SqouldSortLowCount()
        {
            // Arrange
            var emptyList = new List<BigInteger>();
            var oneElementList = new List<BigInteger>() { 0 };

            // Act
            var actualBubbleEmpty = SortingExtensions.BubbleSort(emptyList);
            var actualSelectionEmpty = SortingExtensions.SelectionSort(emptyList);

            var actualBubbleOneElement = SortingExtensions.BubbleSort(oneElementList);
            var actualSelectionOneElement = SortingExtensions.SelectionSort(oneElementList);

            // Assert
            Assert.Empty(actualBubbleEmpty);
            Assert.Empty(actualSelectionEmpty);

            Assert.Equal(actualBubbleOneElement, actualSelectionOneElement);
            Assert.Equal(actualSelectionOneElement, actualSelectionOneElement);
        }

        [Fact]
        public void Sort_SqouldSortBigNumbers()
        {
            // Arrange
            var unsorted = new List<BigInteger>() { 151356151313, -515, -15515150025156, 9651356, BigInteger.Parse("888881111118888888888888"), 0 };
            var expected = new List<BigInteger>() { -15515150025156, -515, 0, 9651356, 151356151313, BigInteger.Parse("888881111118888888888888") };

            // Act
            var actualBubble = SortingExtensions.BubbleSort(unsorted);
            var actualSelection = SortingExtensions.SelectionSort(unsorted);

            // Assert
            Assert.Equal(expected, actualBubble);
            Assert.Equal(expected, actualSelection);
        }

    }
}
