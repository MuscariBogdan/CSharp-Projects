using System;
using System.Collections.Generic;

namespace DominoTiles
{
    public struct Tile
    {
        public int A;
        public int B;

        public Tile(int a, int b)
        {
            this.A = a;
            this.B = b;
        }
    }

    public class Program
    {
        static readonly int[] P = new int[100];
        static readonly int[] X = new int[100];

        public static List<string> PrintResult(Tile[] listOfTiles, int listLength, int numberOfTilesPerLine)
        {
            List<string> result = new List<string>();

            result = Backtracking(result, listLength, numberOfTilesPerLine, listOfTiles);

            if (result.Count < 1)
            {
                string output = "N/A";
                result.Add(output);
            }

            return result;
        }

        static Tile[] ReadTiles(int numberOfPairs)
        {
            Tile[] result = new Tile[numberOfPairs];
            for (int i = 0; i < numberOfPairs; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                result[i] = new Tile(Convert.ToInt32(input[0]), Convert.ToInt32(input[1]));
            }

            return result;
        }

        static List<string> Backtracking(List<string> result, int listLength, int numberOfTilesPerLine, Tile[] listOfTiles, int k = 1)
        {
            for (int i = 0; i < listLength; i++)
            {
                if (P[i] == 0)
                {
                    X[k] = i;
                    P[i] = 1;
                    if (k == 1 || listOfTiles[X[k - 1]].B == listOfTiles[X[k]].A)
                    {
                        result = AddTilesToResult(result, listLength, numberOfTilesPerLine, listOfTiles, k);
                    }
                }

                P[i] = 0;
            }

            return result;
        }

        static List<string> AddTilesToResult(List<string> result, int listLength, int numberOfTilesPerLine, Tile[] listOfTiles, int k = 1)
        {
            if (k == numberOfTilesPerLine)
            {
                string output = string.Empty;
                for (int i = 1; i <= numberOfTilesPerLine; i++)
                {
                    output += listOfTiles[X[i]].A + " " + listOfTiles[X[i]].B + " ";
                }

                result.Add(output.Trim(' '));
            }
            else
            {
                Backtracking(result, listLength, numberOfTilesPerLine, listOfTiles, k + 1);
            }

            return result;
        }

        static void Main()
        {
            int totalTiles = int.Parse(Console.ReadLine());
            Tile[] listOfTiles = ReadTiles(totalTiles);
            int numberOfTilesPerLine = int.Parse(Console.ReadLine());

            List<string> result = PrintResult(listOfTiles, listOfTiles.Length, numberOfTilesPerLine);

            foreach (string str in result)
            {
                Console.WriteLine(str);
            }
        }
    }
}