using HPSpells.Worker;
using Hangfire;
using HPSpells.Worker.Domain.Interfaces.Business;
using HPSpells.Worker.Business.Services;
using HPSpells.Worker.Domain.Interfaces.Infrastructure;
using HPSpells.Worker.Infrastructure.ExternalServices;
using HPSpells.Worker.Infrastructure.Jobs;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHangfire(x =>
{
    x.UseSqlServerStorage(builder.Configuration.GetConnectionString("HangfireConnection"));
});

builder.Services.AddHangfireServer();

builder.Services.AddTransient<ISpellService, SpellService>();
builder.Services.AddTransient<ISpellHangfireJob, SpellHangfireJob>();

builder.Services.AddHttpClient<IHarryPotterApiClient, HarryPotterApiClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["HarryPotterApiSettings:BaseUrl"]);
});

builder.Services.AddHttpClient<IInternalApiClient, InternalApiClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["InternalApiSettings:BaseUrl"]);
});

builder.Services.AddHostedService<Worker>();


var host = builder.Build();
host.Run();


