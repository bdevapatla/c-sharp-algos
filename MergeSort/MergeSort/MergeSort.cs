using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divide.And.Conquer.Algorithms
{
    /// <summary>
    /// This is Prof. Sedgewick's mergesort algorithm 
    /// originally available in java at https://algs4.cs.princeton.edu/22mergesort/Merge.java.html
    /// Ported to C# here by Bhanuprakash Devapatla 
    /// The time complexity of this algorithm is BIG-OH-OF-NlogN
    /// Space complexity if BIG-OH-OF-N 
    /// This is not in-place sorting as in-palce sorts use additional space less then ClogN 
    /// This is ABSTRACT-IN-PLACE algorithm
    /// and also top-down 
    /// </summary>
    public class MergeSort
    {
        private static int CUTOFF = 7;

        public static void Merge(int[] a, int[] aux, int lo, int mid, int hi)
        {

            //the underlying idea behind this merging is swapping 
            for (int k=lo; k <= hi; k++)
            {
                aux[k] = a[k];
            }

            int i = lo, j = mid + 1;
            for(int k=lo; k <= hi; k++)
            {
                if (i > mid) a[k] = aux[j++];
                else if (j > hi) a[k] = aux[i++];
                else if (aux[j] < aux[i]) a[k] = aux[j++]; //In-place sort 
                else a[k] = aux[i++];
            }
        }

        public static void Insertion(int[] a, int lo, int hi)
        {
          
            for (int i= lo; i <= hi; i++) //hi is index not length. it should be less than or equal to. Otherwise it results in one-off error 
            {
           
                for (int j=i; j > lo && a[j] < a[j-1]; j--)
                {
                    int temp = a[j];
                    a[j] = a[j-1];
                    a[j-1] = temp;
                }
               
            }
           
        }

        public static void Sort(int[] a, int[] aux, int lo, int hi)
        {
            if (hi <= lo+CUTOFF-1)
            {
                Insertion(a, lo, hi);
                return;
            }
            int mid = lo + (hi - lo) / 2;
            Sort(a, aux, lo, mid);
            Sort(a, aux, mid + 1, hi);
            //Think about it... we have two sorted arrays...if the first element of 2nd array is higher than the last element of 1st array then 
            //every element in the second array is higher than last element in the first array...they are already merged.
            if (a[mid + 1] >= a[mid]) return; //Improvement
            Merge(a, aux, lo, mid, hi);
        }

        public static void Sort(int[] a)
        {
            int[] aux = new int[a.Length];
            Sort(a, aux, 0, a.Length-1);
        }


        public static void Main(string[] args)
        {
            int[] arr = { 7, 2, 1, 78, 66, 3, 2, 1, 90, 0, 15, 4, 2, 1 };
            Sort(arr);
            arr.ToList().ForEach(i => Console.Write(i + "\t"));
            Console.ReadKey();
        }
    }
}
