using MicroBanking.Infra.Bus;
using Transfer.Application;
using Transfer.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
DependencyContainer.RegisterServices(builder.Services);
builder.Services.AddTransferServices();

var app = builder.Build();
app.ConfigureTransferBus();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.MapControllers();
app.Run();