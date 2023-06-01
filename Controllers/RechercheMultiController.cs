using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodeVoyage.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeVoyage.Controllers
{
    public class RechercheMultiController : Controller
    {
        private List<OffreVoyage> listeOffreVoyage;

        private BddContext _bddContext;

        public RechercheMultiController()
        {
            _bddContext = new BddContext();
        }

       /* public List<OffreVoyage> listeOffreVoyageMulti(int id, Itineraire Itineraire, Evenement Event, Service Service, Service ServiceEx, double prixMin, double prixMax)
        {

            List<OffreVoyage> listeOffreVoyage = _bddContext.OffreVoyages.ToList();

            List<OffreVoyage> listeOffreVoyageMulti = new List<OffreVoyage>();

            foreach (OffreVoyage offre in listeOffreVoyage)
            {
                if ((Itineraire == null || offre.Itineraire == Itineraire)
                       && (Event == null || offre.Event == Event)
                       && (Service == null || offre.Service == Service)
                       && (ServiceEx == null || offre.ServiceEx == ServiceEx)
                       && (prixMin == 0|| offre.prixTotal >= prixMin && offre.prixTotal<= prixMax))
                {

                    listeOffreVoyageMulti.Add(offre);

                    return listeOffreVoyageMulti;
                }
            }

           // return View();
        }*/
        
            // GET: /<controller>/
            public IActionResult Index()
        {
            return View();
        }
    }
}

