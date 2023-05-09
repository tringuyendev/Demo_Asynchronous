namespace Demo_Asynchronous
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1
            //RunSomeTask().Wait();

            // 2
            RunSomeTask().GetAwaiter().GetResult();
        }

        private static async Task RunSomeTask()
        {
            // some long running work
            await Task.Delay(200);

            throw new Exception("Failed because of some reason");
        }
    }
}