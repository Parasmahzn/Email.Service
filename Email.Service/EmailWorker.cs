using Email.Service.Helpers;
using Email.Service.Models;
using Email.Service.Services.EmailConfig;

namespace Email.Service
{
    public class EmailWorker : BackgroundService
    {
        private readonly ILogger<EmailWorker> _logger;
        private readonly IConfiguration _configuration;
        private readonly IEmailConfiguration _emailConfiguration;
        private readonly List<WorkerConfig> workerConfig;
        private readonly EmailSetup emailSetup;

        public EmailWorker(ILogger<EmailWorker> logger, IConfiguration configuration, IEmailConfiguration emailConfiguration)
        {
            _logger = logger;
            _configuration = configuration;
            _emailConfiguration = emailConfiguration;
            workerConfig = _configuration.GetSection("WorkerConfiguration").Get<List<WorkerConfig>>();
            emailSetup = _configuration.GetSection("EmailContentSettings").Get<EmailSetup>();
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                var emailDataResp = await _emailConfiguration.GetEmailContentAsync(emailSetup
                    , emailSetup.FromDb
                    ? _configuration.GetConnectionString("DefaultConnection")
                    : string.Empty);

                if (emailDataResp != null && emailDataResp.Count > 1)
                {
                    foreach (var item in emailDataResp)
                    {
                        var apiResp = await Utilities.MakeAPICall(new API.Request()
                        {
                            ApiType = SD.ApiType.POST,
                            Url = workerConfig.FirstOrDefault()!.APIURL,
                            Data = item
                        });
                        Utilities.ExportServiceLog(apiResp.Stringyfy());
                    }
                }

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
