using System.Text.Json;
using webSites.Models;
using webSites.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
// de estamanera puedo agregar los servicios a una pagina web con la nueva actualizacion
builder.Services.AddControllers();
builder.Services.AddTransient<JsonFileProductService>();

var app = builder.Build();

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
app.MapControllers();
app.MapBlazorHub();
/*app.MapGet("/products", (IServiceProvider serviceProvider) => {
    var products = serviceProvider.GetRequiredService<JsonFileProductService>().GetProducts();
    // Hacer algo con la lista de productos, como devolverla como una respuesta JSON
  
    return Results.Json(products);
});*/


app.Run();
