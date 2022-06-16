using System;

namespace TowerOfHanoi
{
    public class Program
    {
        public static string TowerOfHanoi(int n, char firstRod, char secondRod, char thirdRod)
        {
            var result = string.Empty;
            if (n == 0)
            {
                return string.Empty;
            }

            result += TowerOfHanoi(n - 1, firstRod, thirdRod, secondRod);
            result += "From " + firstRod + " to " + secondRod + "\n";
            result += TowerOfHanoi(n - 1, thirdRod, secondRod, firstRod);

            return result;
        }

        static void Main()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(TowerOfHanoi(n, 'A', 'B', 'C'));
        }
    }
}
