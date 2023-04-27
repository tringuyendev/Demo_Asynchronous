using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Asynchronous
{
    public static class DoAsyncWork
    {
        public static async Task<int> CalculateSumAsync(int i1, int i2)
        {
            int sum = await Task.Run(() => GetSum(i1, i2));
            //Console.WriteLine("Value: {0}", sum);
            return sum;
        }

        public static async Task CalculateSumAsync2(int i1, int i2)
        {
            int sum = await Task.Run(() => GetSum(i1, i2));
            Console.WriteLine("Value: {0}", sum);            
        }

        public static async void CalculateSumAsync3(int i1, int i2)
        {
            int sum = await Task.Run(() => GetSum(i1, i2));
            Console.WriteLine("Value: {0}", sum);
        }

        private static int GetSum(int i1, int i2)
        {
            return i1 + i2;
        }
    }
}
