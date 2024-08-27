using WhatsappNet.Api.Services;
using WhatsappNet.Api.Services.ChatGPT;
using WhatsappNet.Api.Services.Gemini;
using WhatsappNet.Api.Util;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add services
builder.Services.AddSingleton<IWhatsappCloudSendMessage, WhatsappCloudSendMessage>();
builder.Services.AddSingleton<IUtil,Util>();
builder.Services.AddSingleton<IChatGPTService, ChatGPTService>();
builder.Services.AddSingleton<IGeminiAPI, GeminiAPI>();


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
