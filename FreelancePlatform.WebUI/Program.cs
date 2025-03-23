var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();          // ✅ HttpClient ekledik
builder.Services.AddSession();             // ✅ Session desteği eklendi
builder.Services.AddAuthentication();      // (Eğer cookie-based auth kullanırsan burada yapılandırabilirsin)

// Build application
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();              // ✅ Session middleware sırası önemli!
app.UseAuthentication();       // ✅ Authentication burada olmalı
app.UseAuthorization();        // Authorization da burada

// Default route —> Auth/Login
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=İndex}/{id?}");

app.Run();
