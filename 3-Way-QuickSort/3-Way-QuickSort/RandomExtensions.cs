using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divide.And.Conquer.Algorithms
{
    static class RandomExtensions
    {
        public static void Shuffle<T>(this Random rng, T[] arr)
        {
            int n = arr.Length;
            while(n > 1)
            {
                int k = rng.Next(n--);
                T temp = arr[n];
                arr[n] = arr[k];
                arr[k] = temp;
            }
        }
    }
}
