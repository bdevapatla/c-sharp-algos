using System;
using System.Linq;

namespace Linear.Sort.Algorithms
{
    //Selection sort does more compares than swap 
    //There is no way you can optimize selection sort 
    //Because of this all the metrics are quadratic 
    //Only time this fares better than other linear 
    //sorting algorithms is where it is not advised to write to memory multiple times
    class Selection
    {
        static void Sort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                int lowest = i;
                for (int j = i+1; j < n; j++)
                {
                    if (arr[j] < arr[lowest])
                    {
                        lowest = j;
                    }
                }

                if (lowest != i)
                {
                    int temp = arr[i];
                    arr[i] = arr[lowest];
                    arr[lowest] = temp;
                }
            }

        }

        static void Main(string[] args)
        {
            int[] arr = { 7, 2, 1, 4, 5, 3 };
            Sort(arr);
            arr.ToList().ForEach(i => Console.Write(i + "\t"));
            Console.ReadKey();
        }
    }
}
