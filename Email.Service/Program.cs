using Email.Service;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<EmailWorker>();
    })
    .UseWindowsService()
    .Build();

await host.RunAsync();
