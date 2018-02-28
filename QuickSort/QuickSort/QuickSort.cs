using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divide.And.Conquer.Algorithms
{

    //This is Professor. Sedgewick's quicksort algorithm 
    //Original java implementation is avialable at https://algs4.cs.princeton.edu/23quicksort/Quick.java.html
    //Quicksort is inplace since it doesn't use any aux 
    //In worst case quicksort (BIG-OH-OG-N-SQUARE) is worse than mergesort (BIG-OH-OF-N-LOG-N) 
    //Which is why randomization of input is required 
    public class QuickSort
    {

        static int Partition(int[] a, int lo, int hi)
        {
            int i = lo; //Future you would think this should be lo+1
                        //But this is correct because we are going to use 
                        //before incremenet shorthand notation 
                        //lo is your pivot to begin with 
            int j = hi + 1; //Same as above but in reverse direction 

            while (true)
            {
                while (a[++i] < a[lo])
                {
                    if (i == hi) break;
                }
                while (a[lo] < a[--j])
                {
                    if (j == lo) break;
                }

                if (i >= j) break;

                int temp = a[i];
                a[i] = a[j];
                a[j] = temp;
            }

            int temp1 = a[j];
            a[j] = a[lo];
            a[lo] = temp1;

            return j;
        }

        static void Sort(int[] a)
        {
            Sort(a, 0, a.Length - 1);
        }

        static void Sort(int[] a, int lo, int hi)
        {
            if (hi <= lo) return;
            int j = Partition(a, lo, hi);
            Sort(a, lo, j - 1);
            Sort(a, j + 1, hi);
        }

        //Find kth largest element 
        //Finding kth largest element is linear time algorithm 
        //This is linear time algorithm 
        static int Select(int[] a, int k)
        {
            int lo = 0;
            int hi = a.Length - 1;
            while (hi > lo)
            {
                int j = Partition(a, lo, hi);
                if (j > k) hi = j - 1; //any element less than j could be k 
                else if (j < k) lo = j + 1; //any element greater than j could be k 
                else return a[k];
            }
            return a[k];

        }

        static void Main(string[] args)
        {
            int[] a = { 2, 5, 6, 1, 4, 3, 7, 9, 8 };
            new Random().Shuffle<int>(a);
            Sort(a);
            a.ToList<int>().ForEach(i => Console.Write(i + "\t"));
            Array.Sort
        }
    }
}
