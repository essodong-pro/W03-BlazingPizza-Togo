using BlazingPizza;
using BlazingPizza.Components;
using Microsoft.AspNetCore.DataProtection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<CartState>();
if (builder.Environment.IsDevelopment())
{
    var keyFolder = Path.Combine(builder.Environment.ContentRootPath, ".keys");
    Directory.CreateDirectory(keyFolder);
    builder.Services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(keyFolder));
}

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
   
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
