using ContactControl.Repositories;
using Microsoft.EntityFrameworkCore; // Este using � necess�rio para UseSqlServer
// using Microsoft.EntityFrameworkCore.Infrastructure; // N�o � estritamente necess�rio para este cen�rio
// using Pomelo.EntityFrameworkCore.MySql.Infrastructure; // REMOVA ESTE USING

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IContactRepositories, ContactRepositories>();

// Configura��o do DbContext para SQL Server - SIMPLIFICADA E CORRETA
builder.Services.AddDbContext<BancoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));
// A chamada .AddEntityFrameworkSqlServer() foi removida daqui
// pois AddDbContext j� cuida da inje��o do provedor.


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