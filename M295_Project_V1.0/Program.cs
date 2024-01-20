using M295_Project_V1._0.Data;
using M295_Project_V1._0.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddDbContext<ProductAppContext>(opt =>
 opt.UseSqlServer(
     builder.Configuration.GetConnectionString("DefaultConnection")
        .Replace("[Path]", builder.Environment.ContentRootPath)));
builder.Services.AddTransient<DbInitializer>();


builder.Services.AddRazorPages();
builder.Services.AddControllers();

var app = builder.Build();

// add -->
app.MapControllers();
app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = (context) =>
    {
        var headers = context.Context.Response.GetTypedHeaders();

        headers.CacheControl = new CacheControlHeaderValue
        {
            NoCache = true,
            NoStore = true
        };
    }
});
app.MapRazorPages();
app.UseCors("CORS_CONFIG");
// <--




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

using (var scope = app.Services.CreateScope()) // oberhalb von app.Run()
{
    scope.ServiceProvider.GetRequiredService<DbInitializer>().Run(); // run initializer
}

app.Run();
