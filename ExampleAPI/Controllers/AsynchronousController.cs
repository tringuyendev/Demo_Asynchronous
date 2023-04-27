using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsynchronousController : ControllerBase
    {
        [Route("URL")]
        [HttpGet]
        public async Task<int> GetURLContentLengthAsync()
        {
            var client = new HttpClient();

            Task<string> getStringTask = client.GetStringAsync("https://docs.microsoft.com/dotnet");

            DoIndepentWork();

            string contents = await getStringTask;

            return contents.Length;
        }

        void DoIndepentWork()
        {
            Console.WriteLine("Working...");
        }


        [Route("AvoidReturnVoid")]
        [HttpGet]
        public async Task GetAvoidReturnVoidAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(10));

            //AsyncVoidMethod();

            try
            {
                AsyncVoidMethod();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async void AsyncVoidMethod()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            throw new InvalidOperationException();
        }


        [Route("ExceptionHandling")]
        [HttpGet]
        public async Task ExceptionHandlingAsync()
        {
            try
            {
                await ThrowError();
            }
            catch
            {
                throw;
            }
        }

        private async Task ThrowError()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            throw new Exception("This is an error message...");
        }
    }
}
