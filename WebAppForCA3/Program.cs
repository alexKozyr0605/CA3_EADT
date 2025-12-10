//var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast")
//.WithOpenApi();

//app.Run();

//internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}

//Program.cs (WebAppForCA3 folder)

using Shared;
using System.Net.Http;
using System.Net.Http.Json;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.MapGet("/api/rates", async (IHttpClientFactory factory, IConfiguration config) =>
{
    var client = factory.CreateClient();
    var apiKey = config["FixerApiKey"];
    client.DefaultRequestHeaders.Add("apikey", apiKey);
    var result = await client.GetFromJsonAsync<FixerResponse>("https://api.apilayer.com/fixer/latest?base=EUR");
    return Results.Ok(result);
});
app.MapFallbackToFile("index.html");

app.Run();