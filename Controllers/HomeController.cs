using MaestroDetalle.Models;
using MaestroDetalle.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MaestroDetalle.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbcompraContext _dbcontext;

        public HomeController(DbcompraContext context)
        {
            _dbcontext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromBody] CompraVM oCompraVM)
        {
            Compra oCompra= oCompraVM.OCompra;



            oCompra.DetalleCompras = oCompraVM.oDetalleCompra;

            _dbcontext.Compras.Add(oCompra);
            _dbcontext.SaveChanges();



            return Json(new { respuesta = true });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
