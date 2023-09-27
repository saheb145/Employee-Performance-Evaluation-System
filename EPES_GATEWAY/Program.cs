using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


builder.Configuration.AddJsonFile("Ocelot.json", optional: false, reloadOnChange: true);

builder.Services.AddOcelot(builder.Configuration);



builder.Services.AddCors(options =>

{

    options.AddPolicy("AllowSpecificOrigin",

        builder => builder.WithOrigins("https://localhost:7194")

            .AllowAnyHeader()

            .AllowAnyMethod());

});






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
await app.UseOcelot();
app.UseCors("AllowSpecificOrigin");
app.Run();
