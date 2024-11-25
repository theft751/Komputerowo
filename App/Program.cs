using DataBaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppDbContext>( options =>
    options
        .UseLazyLoadingProxies()
        .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")))
        ;

builder.Services.AddSession(options =>
{
    options.Cookie.Name = "Komputerowo_login_session";
    options.IdleTimeout = TimeSpan.FromMinutes(120);
    options.Cookie.IsEssential = true;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//using (var scope = app.Services.CreateScope())
//{
    //  try
    //{
    //var scopedContext = app.Services.GetRequiredService<AppDbContext>();
    //scopedContext.Database.EnsureCreated();
    //DbInitializer.Seed(scopedContext);
    //    }
    //catch
    // {
    //throw new Exception("Unable to initialize database");
    //}
//}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();


app.MapRazorPages();

app.Run();
