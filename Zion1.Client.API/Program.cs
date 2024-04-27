using Zion1.Client.Infrastructure;
//using Zion1.Common.Helper.Logger;
using Zion1.Common.Helper.Cache;
//using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Add Log Service
//uilder.AddLogService(builder.Configuration);


//Add Cache Service
builder.Services.AddCacheService();

//Add Client Module Service
builder.Services.AddClientService(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//Enable Serilog request tracking
//app.UseSerilogRequestLogging();

//Cors
app.UseCors(policy =>
    policy.WithOrigins("https://localhost:7197", "https://localhost:7097", "https://localhost:7250")
    .AllowAnyHeader()
    .AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
