using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace GestionPersonnes.WebSite
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Contact()
        {
            ViewBag.Title = "Contact";
            return View();
        }


        [Route("Home/Calcul/{a}/{b}/{c}")]
        public IActionResult Calcule(int a, int b, int c)
        {
            //int result = a + b + c;
            //return Content(result.ToString());
            //return Content((a + b + c).ToString());
            return Content(String.Format("{0}", a + b + c));
        }
    }
}

