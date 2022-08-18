using Email.Service.Helpers;
using Email.Service.Models;

namespace Email.Service
{
    public class EmailWorker : BackgroundService
    {
        private readonly ILogger<EmailWorker> _logger;
        private readonly IConfiguration _configuration;
        private readonly List<WorkerConfig> workerConfig;

        public EmailWorker(ILogger<EmailWorker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            workerConfig = _configuration.GetSection("WorkerConfiguration").Get<List<WorkerConfig>>();
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                var apiResp = await Utilities.MakeAPICall(new API.Request()
                {
                    ApiType = SD.ApiType.GET,
                    Url = workerConfig.FirstOrDefault()?.APIURL!
                });
                if (apiResp.Success)
                    Utilities.ExportServiceLog(apiResp.Stringyfy());

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
