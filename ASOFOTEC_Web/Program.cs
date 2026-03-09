using ASOFOTEC_Web.Data;
using ASOFOTEC_Web.DTOs;
using ASOFOTEC_Web.Services;
using ASOFOTEC_Web.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppdbContext>(Option => Option.UseSqlServer(connectionString));

builder.Services.AddScoped<UserService>();

//Keyed Services
builder.Services.AddKeyedSingleton<IRandomService, RandomService>("RandomKeySingleton");
builder.Services.AddKeyedScoped<IRandomService, RandomService>("RandomKeyScoped");
builder.Services.AddKeyedTransient<IRandomService, RandomService>("RandomKeyTransient");

//Vaidators
builder.Services.AddScoped<IValidator<InsertUsersDto>, UserInsertValidator>();
builder.Services.AddScoped<IValidator<UpdateUsersDto>, UpdateValidator>();

//Services
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IPostSeviceUser, PostServiceUser>();

//HttpClient
builder.Services.AddHttpClient<IPostService, PostService>(P => 
{
    P.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/posts");
});

builder.Services.AddHttpClient<IPostSeviceUser, PostServiceUser>(P =>
{
    P.BaseAddress = new Uri("https://localhost:7032/");
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
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
