using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear.Sorting.Algorithms
{
    class Insertion
    {

        //This is Prof. Sedgewick's insertion sort algortihm.
        //Origianlly available in java at https://algs4.cs.princeton.edu/21elementary/Insertion.java.html
        //Ported to C# by Bhanuprakash Devapatla
        //Worst case BIG-OH-OF-N-SQUARE
        //Average case also BIG-THETA-OF-N-SQUARE 
        //Best case of BIG-OMEGA-N 
        static void Sort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                //Three important things to notice in below condition are 
                //1) j starts at i
                //2) if j is less than j-1 then swap. Because of this j should be greater than 0 
                //3) the very first time j is not less than j-1 then it breaks out of the loop. This is very important for efficient implemenation of insertion sort 
                for (int j = i; j > 0 && arr[j] < arr[j - 1]; j--) 
                {

                    int temp = arr[j];
                    arr[j] = arr[j - 1];
                    arr[j-1]= temp;

                }
            }
        }

        static void Main(string[] args)
        {
            int[] arr = { 7, 2, 4, 1, 5, 3 };
            Sort(arr);
            foreach (int i in arr)
            {
                Console.Write(i + "\t");
            }
            Console.ReadKey();
        }
    }
}
