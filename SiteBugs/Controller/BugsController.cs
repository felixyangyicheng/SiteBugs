using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionPersonnes.DB;
using GestionPersonnes.DB.DAL;
using GestionPersonnes.DB.Models;
using SiteBugs;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace GestionPersonnes.WebSite
{
    public class BugsController : Controller
    {
        private String connectionString;
        public BugsController(IConfiguration configRoot)
        {
            connectionString = configRoot["ConnectionString:DefaultConnection"];
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Bugs Tracker";

            PersonnesIndexViewModel model = new PersonnesIndexViewModel();
            model.Title = "Les personnes sont :";

            PersonnesContext personnesContext = new PersonnesContext(connectionString);
            List<Personne> personnes = personnesContext.GetAll();
            model.Personnes = personnes;

            return View(model);
        }

        // /Personnes/Personne/{id?}
        public IActionResult Personne(int id)
        {
            PersonnesContext personnesContext = new PersonnesContext(connectionString);
            Personne p = personnesContext.Get(id);
            
            PersonnesPersonneViewModel model = new PersonnesPersonneViewModel();
            model.Personne = p;

            IActionResult retour = null;
            if (p != null)
            {
                ViewBag.Title = p.Nom + " " + p.Prenom;
                retour = View(model);
            }
            else
            {
                retour = NotFound();
            }

            return retour;
        }
        
        [Route("Personnes/Personne/Remove/{id}")]
        public IActionResult Remove(int id)
        {
            PersonnesContext personnesContext = new PersonnesContext(connectionString);
            bool isDeleted = personnesContext.Remove(id);

            PersonnesPersonneRemoveViewModels model = new PersonnesPersonneRemoveViewModels();
            model.IsDeleted = isDeleted;

            return View(model);
        }
    }
}