using Microsoft.Extensions.DependencyInjection;
using CurrencyConverter.services;

var builder = WebApplication.CreateBuilder(args);

// Добавление служб авторизации
builder.Services.AddAuthorization();

// Регистрация HttpClient для CurrencyRateService
builder.Services.AddHttpClient<CurrencyRateService>();

// Добавление контроллеров
builder.Services.AddControllers();

var app = builder.Build();

// Настройка обработки статических файлов и маршрутизации
DefaultFilesOptions options = new()
{
    DefaultFileNames = [ "Pages/index.html" ]
};

app.UseDefaultFiles(options);
app.UseDirectoryBrowser();
app.UseStaticFiles(new StaticFileOptions());

app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();