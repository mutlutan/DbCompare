using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using WebApp.Codes;


namespace WebApp.Controllers
{
    public class CompareController(IServiceProvider _serviceProvider) : BaseController(_serviceProvider)
    {
        public IActionResult Index()
        {
            ViewBag.kaynak = this.connectionString;
            ViewBag.hedef = this.connectionString;

            return View();
        }

        public IActionResult Run(string _kaynak, string _hedef)
        {
            Boolean rSonuc = false;
            System.Text.StringBuilder logs = new();

            try
            {
                logs = MyApp.CompareDatabase(_kaynak, _hedef);
            }
            catch (Exception ex)
            {
                logs.Append(ex.MyLastInner().Message);
            }

            logs.Append(Environment.NewLine + "İşlem sonu...");

            return Json(new { Sonuc = rSonuc, Mesaj = logs.ToString() });
        }




    }
}