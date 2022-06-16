using System;
using Xunit;

namespace TowerOfHanoi.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TowerOfHanoi_OneDisc_ShouldReturnFromAtoB()
        {
            int n = 1;
            char firstRod = 'A';
            char secondRod = 'B';
            char thirdRod = 'C';

            string expectedResult = "From " + firstRod + " to " + secondRod + "\n";

            Assert.Equal(expectedResult, Program.TowerOfHanoi(n, firstRod, secondRod, thirdRod));
        }

        [Fact]
        public void TowerOfHanoi_OneDisc_ShouldReturnFromAtoCfromAtoBfromCtoB()
        {
            int n = 2;
            char firstRod = 'A';
            char secondRod = 'B';
            char thirdRod = 'C';

            string expectedResult = "From " + firstRod + " to " + thirdRod + "\n" + "From " + firstRod + " to " + secondRod + "\n" + "From " + thirdRod + " to " + secondRod + "\n";

            Assert.Equal(expectedResult, Program.TowerOfHanoi(n, firstRod, secondRod, thirdRod));
        }

        [Fact]
        public void TowerOfHanoi_NoDiscs_ShouldReturnEmptyString()
        {
            int n = 0;
            char firstRod = 'A';
            char secondRod = 'B';
            char thirdRod = 'C';

            string expectedResult = string.Empty;

            Assert.Equal(expectedResult, Program.TowerOfHanoi(n, firstRod, secondRod, thirdRod));
        }
    }
}
