using MassTransit;
using RabbitMQ.Client;
using TCFiapProducerCreateContact.Application.Services;
using TCFiapProducerCreateContact.Application.Services.Implementation;
using TechChallenge.SDK.Infrastructure.Message;

var builder = WebApplication.CreateBuilder(args);


var envHostRabbitMqServer = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "localhost";

// Add services to the container.

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(envHostRabbitMqServer);

        cfg.Publish<UpdateContactMessage>(x =>
        {
            x.ExchangeType = ExchangeType.Direct; // Tipo do exchange do DLX
            x.BindQueue("update-contact-dlx-exchange", "update-contact-dlx");
        });

        cfg.Publish<CreateContactMessage>(x =>
        {
            x.ExchangeType = ExchangeType.Direct; // Tipo do exchange do DLX
            x.BindQueue("create-contact-dlx-exchange", "create-contact-dlx");
        });

        cfg.Publish<RemoveContactMessage>(x =>
        {
            x.ExchangeType = ExchangeType.Direct; // Tipo do exchange do DLX
            x.BindQueue("delete-contact-dlx-exchange", "delete-contact-dlx");
        });


    });
});
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddSingleton<IRabbitMqClient, RabbitMqClient>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
