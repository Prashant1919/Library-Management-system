using CrudeoperationsonRazorPages.DB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<MYDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDistributedMemoryCache();

// Add session services
builder.Services.AddSession(options=>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
 });
builder.Services.AddHttpContextAccessor();
var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();
// use session before UseAuthorization
app.UseSession();

app.UseAuthorization();

app.MapStaticAssets();

// rediredct root to signin page
app.MapGet("/", context =>
{
    context.Response.Redirect("/Account/SignIn");
    return Task.CompletedTask;
});
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
