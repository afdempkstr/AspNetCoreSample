using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreSample.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
