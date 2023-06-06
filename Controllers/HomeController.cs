using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeVoyage.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeVoyage.Controllers
{
    public class HomeController : Controller
    {
        private BddContext _bddContext;

        public HomeController()
        {
            _bddContext = new BddContext();
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        /*public IActionResult Recherche(int id)
        {
            //ViewData["Nom"] = id;

            OffreVoyage offre = _bddContext.OffreVoyages.FirstOrDefault(o => o.Id == id); 

            Itineraire itineraire = _bddContext.Itineraires.FirstOrDefault(m => m.Id == id);

            if (itineraire != null)

            {
                offre.Itineraire = itineraire;

                return View ();

            }
            return View("NonTrouve");
        }*/


        public IActionResult IndexA()
        {
            return View();
        }
    }
}

