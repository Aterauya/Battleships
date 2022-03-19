using Battleships.Service.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Service.Tests
{
    [TestClass]
    public class BoardBuilderTests
    {
        [DataRow(10, 10)]
        [DataRow(20, 20)]
        [DataRow(9, 5)]
        [DataTestMethod]
        public void BuildBoard_GeneratesMatrixAtCorrectSize(int xAmount, int yAmount)
        {
            // Arrange
            var boardBuilder = new BoardBuilder();
            var cellCount = xAmount * yAmount;
            // Act
            var board = boardBuilder.BuildBoard(xAmount, yAmount);
            var rows = board.Count();
            var columns = board.First().Count();
            var count = board.SelectMany(list => list).Count();

            // Assert
            Assert.AreEqual(rows, xAmount);
            Assert.AreEqual(columns, yAmount);
            Assert.AreEqual(count, cellCount);
        }
    }
}
