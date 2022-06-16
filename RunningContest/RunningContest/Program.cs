using System;

namespace RunningContest
{
    public struct Contestant
    {
        public string Name;
        public string Country;
        public double Time;

        public Contestant(string name, string country, double time)
        {
            this.Name = name;
            this.Country = country;
            this.Time = time;
        }
    }

    public struct ContestRanking
    {
        public Contestant[] Contestants;
    }

    public struct Contest
    {
        public ContestRanking[] Series;
        public ContestRanking GeneralRanking;
    }

    public class Program
    {
        public static void GenerateGeneralRanking(ref Contest contest)
        {
            contest = MergeArrays(contest);
            Sort(contest, 0, contest.GeneralRanking.Contestants.Length - 1);
            Array.Reverse(contest.GeneralRanking.Contestants);
        }

        static void Swap(Contest tempContest, int pivot, int secondIndex)
        {
            Contest temp = new Contest
            {
                GeneralRanking = new ContestRanking()
            };
            temp.GeneralRanking.Contestants = new Contestant[tempContest.GeneralRanking.Contestants.Length];
            temp.GeneralRanking.Contestants[0] = tempContest.GeneralRanking.Contestants[secondIndex];
            tempContest.GeneralRanking.Contestants[secondIndex] = tempContest.GeneralRanking.Contestants[pivot];
            tempContest.GeneralRanking.Contestants[pivot] = temp.GeneralRanking.Contestants[0];
        }

        static void Sort(Contest contest, int start, int end)
        {
            var pivot = contest.GeneralRanking.Contestants[(start + end) / 2].Time;
            int i = start;
            int j = end;

            while (i <= j)
            {
                while (contest.GeneralRanking.Contestants[i].Time > pivot)
                {
                    i++;
                }

                while (contest.GeneralRanking.Contestants[j].Time < pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    Swap(contest, i, j);
                    i++;
                    j--;
                }
            }

            if (start < j)
            {
                Sort(contest, start, j);
            }

            if (i >= end)
            {
                return;
            }

            Sort(contest, i, end);
        }

        static Contest ReadContestSeries()
        {
            Contest contest = default;

            int seriesNumber = Convert.ToInt32(Console.ReadLine());
            int contestantsPerSeries = Convert.ToInt32(Console.ReadLine());

            contest.Series = new ContestRanking[seriesNumber];

            for (int i = 0; i < seriesNumber; i++)
            {
                contest.Series[i].Contestants = new Contestant[contestantsPerSeries];
                for (int j = 0; j < contestantsPerSeries; j++)
                {
                    string contestantLine = string.Empty;

                    while (contestantLine == string.Empty)
                    {
                        contestantLine = Console.ReadLine();
                    }

                    contest.Series[i].Contestants[j] = CreateContestant(contestantLine.Split('-'));
                }
            }

            return contest;
        }

        private static Contestant CreateContestant(string[] contestantData)
        {
            const int nameIndex = 0;
            const int countryIndex = 1;
            const int timeIndex = 2;

            return new Contestant(
                contestantData[nameIndex].Trim(),
                contestantData[countryIndex].Trim(),
                Convert.ToDouble(contestantData[timeIndex]));
        }

        static void Main()
        {
            Contest contest = ReadContestSeries();
            GenerateGeneralRanking(ref contest);

            Print(contest);
            Console.Read();
        }

        private static void Print(Contest contestRanking)
        {
            for (int i = 0; i < contestRanking.GeneralRanking.Contestants.Length; i++)
            {
                Contestant contestant = contestRanking.GeneralRanking.Contestants[i];
                const string line = "{0} - {1} - {2:F3}";
                Console.WriteLine(string.Format(line, contestant.Name, contestant.Country, contestant.Time));
            }
        }

        static Contest MergeArrays(Contest contest)
        {
            int tempINdex = 0;
            Contest tempArr = new Contest
            {
                GeneralRanking = new ContestRanking
                {
                    Contestants = new Contestant[contest.Series[0].Contestants.Length * contest.Series.Length],
                },
            };

            for (int j = 0; j < contest.Series.Length; j++)
            {
                int i = 0;
                while (i < contest.Series[j].Contestants.Length)
                {
                    foreach (var cont in contest.Series[j].Contestants)
                    {
                        tempArr.GeneralRanking.Contestants[tempINdex] = cont;
                        i++;
                        tempINdex++;
                    }
                }
            }

            return tempArr;
        }
    }
}
