using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divide.And.Conquer.Algorithms
{
    //This class is copied from sof @https://stackoverflow.com/a/110570/2442396 
    //This randomization technique implements Fisher-Yates algorithm 
    static class RandomExtensions
    {
        public static void Shuffle<T>(this Random rng,T[] arr)
        {
            int n = arr.Length;
            while(n > 1)
            {
                int k = rng.Next(n--);

                T temp = arr[k];
                arr[k] = arr[n];
                arr[n] = temp;

            }
        }
    }
}
