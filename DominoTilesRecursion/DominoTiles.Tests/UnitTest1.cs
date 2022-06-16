using System;
using Xunit;
using System.Collections.Generic;

namespace DominoTiles.Tests
{
    public class UnitTest1
    {

        [Fact]
        public void Backtracking_ThreeTiles_ShouldReturnTwoLines()
        {
            Tile[] listOfTiles = new Tile[3];
            listOfTiles[0] = new Tile(4, 5);
            listOfTiles[1] = new Tile(5, 3);
            listOfTiles[2] = new Tile(3, 2);

            int numberOfTilePerLine = 2;

            List<string> actualResult = Program.PrintResult(listOfTiles, listOfTiles.Length, numberOfTilePerLine);

            List<string> expectedResult = new List<string>();
            string[] output = { "4 5 5 3", "5 3 3 2" };
            expectedResult.AddRange(output);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Backtracking_NoMatchingTiles_ShouldReturnNA()
        {
            Tile[] listOfTiles = new Tile[3];
            listOfTiles[0] = new Tile(4, 5);
            listOfTiles[1] = new Tile(3, 1);
            listOfTiles[2] = new Tile(6, 7);

            int numberOfTilePerLine = 2;

            List<string> actualResult = Program.PrintResult(listOfTiles, listOfTiles.Length, numberOfTilePerLine);

            List<string> expectedResult = new List<string>();
            string[] output = { "N/A" };
            expectedResult.AddRange(output);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Backtracking_OneTileInput_ShouldreturnTile()
        {
            Tile[] listOfTiles = new Tile[1];
            listOfTiles[0] = new Tile(4, 5);

            int numberOfTilePerLine = 1;

            List<string> actualResult = Program.PrintResult(listOfTiles, listOfTiles.Length, numberOfTilePerLine);

            List<string> expectedResult = new List<string>();
            string[] output = { "4 5" };
            expectedResult.AddRange(output);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
