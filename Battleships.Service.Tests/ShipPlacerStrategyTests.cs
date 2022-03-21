using Battleships.Common;
using Battleships.Common.Ships;
using Battleships.Service.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Tests
{
    [TestClass]
    public class ShipPlacerStrategyTests
    {
        [TestMethod]
        public void VerticalPlaceShip_ReturnsSuccessfulResult_WhenNoShipOnTile()
        {
            // Arrange
            var strategy = new VerticalShipPlacerStrategy();
            var ship = new Battleship(OrientationEnum.Vertical);

            // Act
            var result = strategy.PlaceShip(TestData.GetVerticallyFilledBoard(), 0, 0, ship);

            // Assert
            Assert.AreEqual(true, result.IsSuccessful);
        }

        [TestMethod]
        public void VerticalPlaceShip_ReturnsFailedResult_WhenShipOnTile()
        {
            // Arrange
            var strategy = new VerticalShipPlacerStrategy();
            var ship = new Battleship(OrientationEnum.Vertical);

            // Act
            var result = strategy.PlaceShip(TestData.GetBoardWithBattleshipOn(), 0, 0, ship);

            // Assert
            Assert.AreEqual(false, result.IsSuccessful);
            Assert.AreEqual("Battleship already on the requested cell", result.ResultMessage);
        }

        [TestMethod]
        public void HorizontalPlaceShip_ReturnsSuccessfulResult_WhenNoShipOnTile()
        {
            // Arrange
            var strategy = new HorizontalShipPlacerStrategy();
            var ship = new Battleship(OrientationEnum.Horizontal);

            // Act
            var result = strategy.PlaceShip(TestData.GetHorizontallyFilledBoard(), 0, 0, ship);

            // Assert
            Assert.AreEqual(true, result.IsSuccessful);
        }

        [TestMethod]
        public void HorizontalPlaceShip_ReturnsFailedResult_WhenShipOnTile()
        {
            // Arrange
            var strategy = new HorizontalShipPlacerStrategy();
            var ship = new Battleship(OrientationEnum.Horizontal);

            // Act
            var result = strategy.PlaceShip(TestData.GetBoardWithBattleshipOn(), 0, 0, ship);

            // Assert
            Assert.AreEqual(false, result.IsSuccessful);
            Assert.AreEqual("Battleship already on the requested cell", result.ResultMessage);
        }
    }
}
