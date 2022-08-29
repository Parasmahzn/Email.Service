using Email.Service;
using Email.Service.Services.EmailConfig;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<EmailWorker>();
        services.AddTransient<IEmailConfiguration, EmailConfiguration>();
    })
    .UseWindowsService()
    .Build();

await host.RunAsync();
