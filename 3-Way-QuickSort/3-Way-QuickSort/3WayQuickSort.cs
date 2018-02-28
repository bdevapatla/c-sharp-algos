using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divide.And.Conquer.Algorithms
{
    //E. W. Dijkstra's 3 way partioning algorithm 
    //This is origianlly implemented in java by Prof. Sedgewick at https://algs4.cs.princeton.edu/23quicksort/Quick3way.java.html
    //This algorithm is also called Dutch Solution to National Flag problem 
    public class _3_WayQuickSort
    {

        static void Sort(int[] arr, int lo, int hi)
        {
            if (hi <= lo) return;
            int lt = lo;
            int i = lo + 1;
            int gt = hi;
            while (i <= gt)
            {
                if(arr[i] < arr[lt])
                {
                    int temp1 = arr[i];
                    arr[i] = arr[lt];
                    arr[lt] = temp1;
                    i++;
                    lt++;
                }
                else if(arr[i] > arr[lt])
                {
                    int temp1 = arr[i];
                    arr[i] = arr[gt];
                    arr[gt] = temp1;
                    gt--;
                }
                else
                {
                    i++;
                }               
            }
            Sort(arr, lo, lt - 1);
            Sort(arr, gt + 1, hi);
        }

        static void Sort(int[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
        }

        static void Main(string[] args)
        {
            int[] arr = {10,44,56,78,1,23,4,56,6,7,8,9,10 };
            new Random().Shuffle<int>(arr);
            Sort(arr);
            arr.ToList().ForEach(i => Console.Write(i + "\t"));
            Console.ReadKey();
        }
    }
}
