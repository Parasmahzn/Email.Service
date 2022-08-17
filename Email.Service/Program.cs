using Email.Service;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<EmailWorker>();
    })
    .Build();

await host.RunAsync();
