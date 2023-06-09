using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeVoyage.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeVoyage.Controllers
{
    public class OffrePersoController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        private BddContext _bddContext;

        public OffrePersoController()
        {
            _bddContext = new BddContext();
        }

        public IActionResult CreerOffrePerso()
        {
            var itineraires = _bddContext.Itineraires.ToList();
            var evenements = _bddContext.Evenements.ToList();
            var services = _bddContext.Services.ToList();
            var offres = _bddContext.OffreVoyages.ToList();
            ViewBag.ItineraireList = itineraires;
            ViewBag.EvenementList = evenements;
            ViewBag.ServiceList = services;
            ViewBag.OffreVoyageList = offres;
            return View();
        }

        [HttpPost]
        public IActionResult CreerOffrePerso(OffrePerso offrePerso)
        {


            using (Dal dal = new Dal())
            {
                int id = dal.CreerOffrePerso(offrePerso.OffreId, offrePerso.ServicePersoId);
                return RedirectToAction("AfficherToutesLesOffresPerso");
            }

        }
    }
}

