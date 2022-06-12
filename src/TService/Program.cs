using Serilog;
using TService.Services;
using TService.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.RollingFile("Logs/log-{Date}.log")
    .WriteTo.Console());
builder.Configuration.AddJsonFile("_app_/appsettings.json", optional: false, reloadOnChange: true).AddEnvironmentVariables();
builder.Configuration.AddJsonFile($"_app_/appsettings.{builder.Environment.EnvironmentName}.json", optional: true).AddEnvironmentVariables();

var settings = builder.Configuration.Get<AppSettings>();
// Add services to the container.
builder.Services.AddSingleton(settings);
builder.Services.AddSingleton<TestService>();

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
var defaultOptions = new DefaultFilesOptions();
defaultOptions.DefaultFileNames.Clear();
defaultOptions.DefaultFileNames.Add("index.html");
app.UseDefaultFiles(defaultOptions);
app.UseStaticFiles();
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
