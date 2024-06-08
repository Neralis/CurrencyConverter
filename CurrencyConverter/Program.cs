using Microsoft.Extensions.DependencyInjection;
using CurrencyConverter.services;

var builder = WebApplication.CreateBuilder(args);

// ���������� ����� �����������
builder.Services.AddAuthorization();

// ����������� HttpClient ��� CurrencyRateService
builder.Services.AddHttpClient<CurrencyRateService>();

// ���������� ������������
builder.Services.AddControllers();

var app = builder.Build();

// ��������� ��������� ����������� ������ � �������������
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