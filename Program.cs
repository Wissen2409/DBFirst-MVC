using DBFirst_MVC.DMO;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Veri tabanını (Context) Dependency Injection'a ekleyelim!!

// Context'imizi, veri tabanı olarak sisteme tanıttık ve connection string bilgisini, appsettings.json'dan almasını söyledik!!

// builder.Configuration.GetConnectionString metodu, içerisine key değeri alır!!
// aldığı bu key değeri ile, appsettings.json dosyasında bu key'in karşılığı arar, 

// bulduğunda, bu veriyi getirir
builder.Services.AddDbContext<Db11596Context>(options=>{

  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

  // eğer external dosyadan almak istemezseniz connection string bilgisini aşağıdaki şekilde de verebilirsiniz
// options.UseSqlServer("Server=db11596.public.databaseasp.net; Database=db11596; User Id=db11596; Password=i#5G!Tc2p6J+; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;");
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
