using Battleships.Common;
using Battleships.Common.Ships;
using Battleships.Service.Interfaces;
using Battleships.Service.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Tests
{
    [TestClass]
    public class ShipPlacerTests
    {
        private Mock<IVerticalShipPlacerStrategy> _verticalShipPlacer;
        private Mock<IHorizontalShipPlacerStrategy> _horizontalShipPlacer;

        [TestInitialize]
        public void Setup()
        {
            // Runs
            _verticalShipPlacer = new Mock<IVerticalShipPlacerStrategy>();
            _verticalShipPlacer.Setup(i => i.PlaceShip(It.IsAny<List<List<BoardCell>>>(), It.IsAny<int>(),
                It.IsAny<int>(), It.IsAny<ShipBase>())).Returns(new BattleshipResult { IsSuccessful = true});
            _horizontalShipPlacer =  new Mock<IHorizontalShipPlacerStrategy>();
            _horizontalShipPlacer.Setup(i => i.PlaceShip(It.IsAny<List<List<BoardCell>>>(), It.IsAny<int>(),
                It.IsAny<int>(), It.IsAny<ShipBase>())).Returns(new BattleshipResult { IsSuccessful = true });
        }

        [TestMethod]
        public void PlaceShip_ReturnsTrue_WhenPlacedShipSuccessfully()
        {
            // Arrange
            var shipPlacer = new ShipPlacer(_verticalShipPlacer.Object, _horizontalShipPlacer.Object);
            var shipToPlace = new Battleship(OrientationEnum.Vertical);

            // Act
            var result = shipPlacer.PlaceShip(TestData.GetVerticallyFilledBoard(), 0, 0, shipToPlace);

            // Assert
            Assert.AreEqual(true, result.IsSuccessful);
        }

        [TestMethod]
        public void PlaceShip_ReturnsFalse_WhenShipWontFitWherePlaced()
        {
            // Arrange

            var shipPlacer = new ShipPlacer(_verticalShipPlacer.Object, _horizontalShipPlacer.Object);
            var shipToPlace = new Battleship(OrientationEnum.Vertical);

            // Act
            var result = shipPlacer.PlaceShip(TestData.GetBoardWithSingleCell(), 0, 0, shipToPlace);

            // Assert
            Assert.AreEqual(false, result.IsSuccessful);
        }
    }
}
