using Battleships.Service.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Battleships.Tests
{
    [TestClass]
    public class BoardBuilderTests
    {
        [DataRow(10, 10)]
        [DataRow(20, 20)]
        [DataRow(9, 5)]
        [DataTestMethod]
        public void BuildBoard_GeneratesMatrix_ProducesTheCorrectAmountOfRows(int xAmount, int yAmount)
        {
            // Arrange
            var boardBuilder = new BoardBuilder();
            var cellCount = xAmount * yAmount;
            // Act
            var board = boardBuilder.BuildBoard(xAmount, yAmount);
            var rows = board.Count();

            // Assert
            Assert.AreEqual(xAmount, rows);
        }

        [DataRow(10, 10)]
        [DataRow(20, 20)]
        [DataRow(9, 5)]
        [DataTestMethod]
        public void BuildBoard_GeneratesMatrix_ProducesTheCorrectAmountOfColumns(int xAmount, int yAmount)
        {
            // Arrange
            var boardBuilder = new BoardBuilder();
            var cellCount = xAmount * yAmount;
            // Act
            var board = boardBuilder.BuildBoard(xAmount, yAmount);
            var columns = board.First().Count();

            // Assert
            Assert.AreEqual(yAmount, columns);
        }

        [DataRow(10, 10)]
        [DataRow(20, 20)]
        [DataRow(9, 5)]
        [DataTestMethod]
        public void BuildBoard_GeneratesMatrix_ProducesTheCorrectAmountOfCells(int xAmount, int yAmount)
        {
            // Arrange
            var boardBuilder = new BoardBuilder();
            var cellCount = xAmount * yAmount;
            // Act
            var board = boardBuilder.BuildBoard(xAmount, yAmount);
            var count = board.SelectMany(list => list).Count();

            // Assert
            Assert.AreEqual(cellCount, count);
        }
    }
}
