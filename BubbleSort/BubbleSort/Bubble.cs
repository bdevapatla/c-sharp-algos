using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear.Sorting.Algorithms
{
    /// <summary>
    /// Bubble sorting algorithm is the most useless algorithm 
    /// </summary>
    public class Bubble
    {

        //The below is Prof. Sedgewick's bubble sort algorithm 
        //This actuallly moves the least element to the left after each pass 
        //Most bubblesort algorithms online move highest element to right after each pass 

            //This is BIG-OH-OF-N-SQUARE
            //BIG-OMEGA-N best case 
        public static void SortToLeft(int[] arr)
        {
            int n = arr.Length;
            for(int i=0; i < n; i++)
            {
                int exchanges = 0;
                for(int j = n-1; j > i; j--)
                {
                    if(arr[j] < arr[j - 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                        exchanges++;
                    }
                }
                if(exchanges == 0)
                {
                    break;
                }
            }
        }

        public static void SortToRight(int[] arr)
        {

            int n = arr.Length;
            for (int i=0; i < n; i++)
            {
                int exchanges = 0;
                for (int j=0;j < n - i - 1; j++)
                {
                    if(arr[j] > arr[j+1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j+1];
                        arr[j+1] = temp;
                        exchanges++;
                    }
                }

                if (exchanges == 0)
                {
                    break;
                }
            }
        }

        public static void Main(string[] args)
        {
            int[] arr = { 2,7,4,1,5,3};
            SortToRight(arr);
            foreach(var item in arr)
            {
                Console.Write(item + "\t");
            }
            Console.ReadKey();
        }
    }
}
