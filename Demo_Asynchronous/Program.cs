using Demo_Asynchronous;

class Program
{
    static void Main()
    {

        int number;
        Console.WriteLine("Enter a number");
        number = Convert.ToInt32(Console.ReadLine());

        switch (number)
        {
            case 1:
                // returns a Task<int> object:
                Task<int> value = DoAsyncWork.CalculateSumAsync(10, 11);
                //Do Other processing
                Console.WriteLine("Value: {0}", value.Result);
                break;
            case 2:
                // returns a Task object:
                Task value2 = DoAsyncWork.CalculateSumAsync(10, 11);
                value2.Wait();
                Console.WriteLine("Async stuff is done");
                break;
            case 3:
                DoAsyncWork.CalculateSumAsync3(10, 11);
                Thread.Sleep(200);
                Console.WriteLine("Program Exiting");
                break;
        }

    }
}