using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Deadlock
{
    public class Service
    {
        private static async Task DelayAsync()
        {
            await Task.Delay(1000);
        }

        public static void Test()
        {
            var delayTask = DelayAsync();
            delayTask.Wait();
        }

        public static async Task TestAsync()
        {
            var delayTask = DelayAsync();
            await delayTask;
        }

        public static void TestConfig()
        {
            var delayTask = DelayAsync().ConfigureAwait(false);
        }
    }
}