using EPES.Web.Services;
using EPES.Web.Services.IServices;
using EPES.Web.Utility;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();



/*builder.Services.AddHttpClient<IEmployeeService, EmployeeService>();*/
builder.Services.AddHttpClient<IAuthService, AuthService>();
builder.Services.AddHttpClient<IUserService, UserService>();
builder.Services.AddHttpClient<IProfileService, ProfileService>();

builder.Services.AddHttpClient<IEvaluationService, EvaluationService>();
builder.Services.AddHttpClient<IManagerEvaluationService, ManagerEvaluationService>();


SD.AuthAPIBase = builder.Configuration["ServiceUrls:AuthAPI"];
SD.UserAPIBase = builder.Configuration["ServiceUrls:AuthAPI"];
SD.ProfileAPIBase = builder.Configuration["ServiceUrls:AuthAPI"];

//SD.UserMangementAPIBase = builder.Configuration["ServiceUrls:UserMangementAPI"];
SD.SelfEvaluationAPIBase = builder.Configuration["ServiceUrls:SelfEvaluationAPI"];
SD.ManagerEvaluationAPIBase = builder.Configuration["ServiceUrls:ManagerEvaluationAPI"];




builder.Services.AddScoped<ITokenProvider, TokenProvider>();
builder.Services.AddScoped<IBaseService, BaseService>();
//builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IEvaluationService, EvaluationService>();
builder.Services.AddScoped<IManagerEvaluationService, ManagerEvaluationService>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromHours(10);
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/AccessDenied";
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();
