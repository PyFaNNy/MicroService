using Microsoft.AspNetCore.Mvc;

namespace MicroService2.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "String from MicroService 2";
        }
    }
}
