using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divide.And.Conquer.Algorithms
{
    public class BottomUpMergeSort
    {

        public static void Merge(int[] a, int[] aux, int lo, int mid, int hi)
        {

            //the underlying idea behind this merging is swapping 
            for (int k = lo; k <= hi; k++)
            {
                aux[k] = a[k];
            }

            int i = lo, j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid) a[k] = aux[j++];
                else if (j > hi) a[k] = aux[i++];
                else if (aux[j] < aux[i]) a[k] = aux[j++]; //In-place sort 
                else a[k] = aux[i++];
            }
        }

        public static void Sort(int[] a)
        {
            int[] aux = new int[a.Length];
            int N = a.Length;
            for(int sz=1; sz < N; sz = 2 * sz)
            {
                for(int i=0;i < N-sz; i = i + 2 * sz)
                {
                    Merge(a, aux, i, i + sz - 1, Math.Min(i + 2 * sz - 1, N - 1));
                }
            }
            
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
