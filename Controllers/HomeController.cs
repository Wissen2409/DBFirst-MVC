using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DBFirst_MVC.Models;
using DBFirst_MVC.DMO;

namespace DBFirst_MVC.Controllers;

public class HomeController : Controller
{

    private Db11596Context _context;

    public HomeController(Db11596Context context)
    {
        _context = context;
       
    }

    public IActionResult Index()
    {

        #region Açıklamalar
        // Uygulamaların veri tabanına bağlanması 4 farklı şekilde olmaktadır

        // 1 : Ado.net (eski bir yöntemdir, günümüzde hantal kalmaktadır)
        // 2 : Entity Framework Code First(Bu yöntemde veri tabanı yoktur, veri tabanı oluşturma c# tarafında yazılan kodlarla olur)
        // 3 : Entity Framework DbFirst (Bu yöntemde, veri tabanı vardır ve bu veri tabanına yazılım tarafından ulaşmak ve kullanmak için bazı yöntemler uygulanır!!)
        // 4 : Dapper diye bir yöntem vardır, Kolay ve basit bir pakettir, Hızlı şekilde veri tabanına bağlanmak için kullanılır(Dapper arka planda, Ado.net kullanmaktadır)

        
        // Örnek DBFirst örneği olacaktır, mevcutta olan bir veri tabanının içerisindeki tüm kolonları,
        // c# tarafında dmo modele çevirecek bir komut ile bu işlem yapılır!!


        /*
        
        
Package Manager Console a yazılabilir
Scaffold-DbContext "Name=DefaultConnection" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DMO -ContextDir DataAccessLayer -Context AdventureWorksContext


Vs Code’da terminale yazılabilir
dotnet ef dbcontext scaffold "Name=DefaultConnection" Microsoft.EntityFrameworkCore.SqlServer -o DMO   
        
        */

        #endregion
        
        // Context üzerinden product tablosunu çekelim!

       List<Product> products =  _context.Products.ToList();
        
      return View(products);
    }

    public IActionResult Privacy(int id)
    {
       var binaryImage =  _context.ProductPhotos.Where(s=>s.ProductPhotoId==70).FirstOrDefault();
        // actionlar geriye view partial view, json ve image dönebilirler!!

        // veri tabanından binary olarak gelen ürün resmini, actiondan geriye dönelim!!

        return File(binaryImage.LargePhoto,"image/jpeg");   
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
