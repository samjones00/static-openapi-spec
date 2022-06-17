using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//builder.Services
//              .AddMvc(options => options.EnableEndpointRouting = false)
//              .SetCompatibilityVersion(CompatibilityVersion.Latest);


app.UseStaticFiles(new StaticFileOptions
{
    ServeUnknownFileTypes = true,
    DefaultContentType = "application/yaml",
    //FileProvider = new PhysicalFileProvider(
    //    Path.Combine(env.WebRootPath, "yaml")),
    //RequestPath = new PathString("/yaml")
});
app.UseAuthorization();

app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();