using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CancellationTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlowRequestController : Controller
    {
        private readonly ILogger _logger;

        public SlowRequestController(ILogger<SlowRequestController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/slowtest")]
        public async Task<string> Get()
        {
            _logger.LogInformation("Starting to do slow work");

            // slow async action, e.g. call external api
            await Task.Delay(10_000);

            var message = "Finished slow delay of 10 seconds.";

            _logger.LogInformation(message);

            return message;
        }

        [HttpGet("/slowtestCancel")]
        public async Task<string> Get(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting to do slow work");

            // slow async action, e.g. call external api
            await Task.Delay(10_000, cancellationToken);

            var message = "Finished slow delay of 10 seconds.";

            _logger.LogInformation(message);

            return message;
        }

        [HttpGet("/slowtestState")]
        public async Task<string> GetState(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting to do slow work");

            for (var i = 0; i < 10; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                // slow non-cancellable work
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
            var message = "Finished slow delay of 10 seconds.";

            _logger.LogInformation(message);

            return message;
        }
    }
}
