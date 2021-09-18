using System;
using System.Collections.Generic;

namespace Cinema_Seat_Allocation_OR_Flight_Seat_Allocation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            var reservedSeats = new int[6][] { new int[] { 1, 2 }, new int[] { 1, 3 }, 
                                new int[] { 1, 8 }, new int[] { 2, 6 }, new int[] { 3, 1}, new int[] { 3, 10 } };
            Console.WriteLine(MaxNumberOfFamilies(n, reservedSeats));
        }

        static int MaxNumberOfFamilies(int n, int[][] reservedSeats)
        {
            Dictionary<int, HashSet<int>> rowToSeats = new Dictionary<int, HashSet<int>>();
            foreach(var seat in reservedSeats)
            {
                int row = seat[0];
                int column = seat[1];
                if (!rowToSeats.ContainsKey(row))
                    rowToSeats.Add(row, new HashSet<int>());
                rowToSeats[row].Add(column);
            }

            // These rows do not contain any reservations
            // for example, n = 4 and input 2d array does not contain any seat booking details for 4th row, which means in 4th row 2 families can be acoomodated.
            // (4 - 3)* 2 note - 3 is from the dictionary as it will contains seat details for only three rows
            int count = (n - rowToSeats.Count) * 2;

            foreach (var kvp in rowToSeats.Values)
            {
                bool flag = false;

                // Check first possibility
                if (!kvp.Contains(2) && !kvp.Contains(3) && !kvp.Contains(4) && !kvp.Contains(5))
                {
                    count++;
                    flag = true;
                }

                // Check second possibility
                if (!kvp.Contains(6) && !kvp.Contains(7) && !kvp.Contains(8) && !kvp.Contains(9))
                {
                    count++;
                    flag = true;
                }
                // Check middle possibility one when both the asile possibilities are not possible
                if (!flag && (!kvp.Contains(4) && !kvp.Contains(5) && !kvp.Contains(6) && !kvp.Contains(7)))
                {
                    count++;
                }

            }

            return count;
        }
    }
}
