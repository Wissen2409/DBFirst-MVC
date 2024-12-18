using DBFirst_MVC.DMO;
using Microsoft.AspNetCore.Mvc;



[Route("")]
public class ProductDetailController : Controller
{

    private Db11596Context _context;

    public ProductDetailController(Db11596Context context)
    {
        _context = context;
    }

    // routing ile product detail sayfasını product
    [Route("{productname}")]
    public IActionResult ProductDetail(string productname)
    {
        var selectedProduct = _context.Products.Where(s => s.Name == productname.Replace('-', ' ')).FirstOrDefault();

        return View(selectedProduct);
    }

}