using jago.Application.AutoMapper;
using jago.Application.Interfaces.Services;
using jago.Application.Services;
using jago.domain.Interfaces.Repositories;
using jago.Infrastructure.DBConfiguration;
using jago.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => 
                 options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 29))));
builder.Services.AddAutoMapper(typeof(DomainViewModelMapping), typeof(ViewModelDomainMapping));

builder.Services.AddDbContext<ApplicationContext>();

//IoC
    builder.Services.AddScoped<IPassengerServices, PassengerServices>();
    builder.Services.AddScoped<ITripServices, TripServices>();
    builder.Services.AddScoped<IPassengerRepository, PassengerRepository>();
    builder.Services.AddScoped<ITripRepository, TripRepository>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
