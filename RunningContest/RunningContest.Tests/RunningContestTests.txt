using System;
using Xunit;

namespace RunningContest.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void GenerateGeneralRanking_OneSerriesAsInput_ShouldReturnSortedRanking()
        {
            Contest input = new Contest();
            input.Series = new ContestRanking[1];
            input.Series[0].Contestants = new Contestant[3];

            Contestant input1 = new Contestant ( "Ion", "Romania", 9.500 );
            Contestant input2 = new Contestant("Alex", "Romania", 9.300);
            Contestant input3 = new Contestant("Dan", "Romania", 9.200);

            input.Series[0].Contestants[0] = input1;
            input.Series[0].Contestants[1] = input2;
            input.Series[0].Contestants[2] = input3;

            Contest expectedRanking = new Contest();
            expectedRanking.GeneralRanking.Contestants = new Contestant[3];

            expectedRanking.GeneralRanking.Contestants[0] = input3;
            expectedRanking.GeneralRanking.Contestants[1] = input2;
            expectedRanking.GeneralRanking.Contestants[2] = input1;

            Program.GenerateGeneralRanking(ref input);
            Assert.Equal(input.GeneralRanking.Contestants, expectedRanking.GeneralRanking.Contestants);

        }

        [Fact]
        public void GenerateGeneralRanking_MultipleSerriesAsInput_ShouldReturnSortedRanking()
        {
            Contest input = new Contest();
            input.Series = new ContestRanking[2];
            input.Series[0].Contestants = new Contestant[3];
            input.Series[1].Contestants = new Contestant[3];

            Contestant input1 = new Contestant("Ion", "Romania", 9.500);
            Contestant input2 = new Contestant("Alex", "Romania", 9.300);
            Contestant input3 = new Contestant("Dan", "Romania", 9.200);

            Contestant input4 = new Contestant("Mihai", "Romania", 8.500);
            Contestant input5 = new Contestant("Andrei", "Romania", 8.300);
            Contestant input6 = new Contestant("Daniel", "Romania", 8.200);

            input.Series[0].Contestants[0] = input1;
            input.Series[0].Contestants[1] = input2;
            input.Series[0].Contestants[2] = input3;

            input.Series[1].Contestants[0] = input4;
            input.Series[1].Contestants[1] = input5;
            input.Series[1].Contestants[2] = input6;

            Contest expectedRanking = new Contest();
            expectedRanking.GeneralRanking.Contestants = new Contestant[6];

            expectedRanking.GeneralRanking.Contestants[0] = input6;
            expectedRanking.GeneralRanking.Contestants[1] = input5;
            expectedRanking.GeneralRanking.Contestants[2] = input4;
            expectedRanking.GeneralRanking.Contestants[3] = input3;
            expectedRanking.GeneralRanking.Contestants[4] = input2;
            expectedRanking.GeneralRanking.Contestants[5] = input1;

            Program.GenerateGeneralRanking(ref input);
            Assert.Equal(input.GeneralRanking.Contestants, expectedRanking.GeneralRanking.Contestants);

        }
    }
}
