using Microsoft.VisualStudio.TestTools.UnitTesting;
using OzowGameOfLife;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLifeTests
{
    [TestClass]
    public class LifeTest
    {
        [TestMethod]
        public void NoLifeTest()
        {
            Grid testGrid = new Grid(5, 5, false);

            Assert.AreEqual(testGrid.LifeExists(), false);
        }

        [TestMethod]
        public void IsLifeSeededTest()
        {
            Grid testGrid = new Grid(5, 5, true);

            Assert.AreEqual(testGrid.LifeExists(), true);
        }

        [TestMethod]
        public void ExpectedChangeTest()
        {
            //Configuration has cells that when updated have life, death and no change
            List<Cell> testCellSeed = new List<Cell>();
            testCellSeed.Add(new Cell(0, 0, true));
            testCellSeed.Add(new Cell(0, 1, false));
            testCellSeed.Add(new Cell(0, 2, false));

            testCellSeed.Add(new Cell(1, 0, true));
            testCellSeed.Add(new Cell(1, 1, true));
            testCellSeed.Add(new Cell(1, 2, true));

            testCellSeed.Add(new Cell(2, 0, false));
            testCellSeed.Add(new Cell(2, 1, false));
            testCellSeed.Add(new Cell(2, 2, false));

            Grid testGrid = new Grid(testCellSeed);

            testGrid.UpdateGrid();

            bool isExpectedOutput = 
            testGrid.GetCell(0, 0).IsAlive == true &&
            testGrid.GetCell(0, 1).IsAlive == false &&
            testGrid.GetCell(0, 2).IsAlive == false &&
            testGrid.GetCell(1, 0).IsAlive == true &&
            testGrid.GetCell(1, 1).IsAlive == true &&
            testGrid.GetCell(1, 2).IsAlive == false &&
            testGrid.GetCell(2, 0).IsAlive == false &&
            testGrid.GetCell(2, 1).IsAlive == true &&
            testGrid.GetCell(2, 2).IsAlive == false;

            Assert.AreEqual(isExpectedOutput, true);
        }
    }
}
