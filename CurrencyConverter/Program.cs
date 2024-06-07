using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

DefaultFilesOptions options = new DefaultFilesOptions
{
    DefaultFileNames = new List<string> { "Pages/index.html" }
};

app.UseDefaultFiles(options);
app.UseDirectoryBrowser();
app.UseStaticFiles(new StaticFileOptions());

app.Run();
