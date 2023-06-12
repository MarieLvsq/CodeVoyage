using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeVoyage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeVoyage.Controllers
{
    public class ReservationPersoController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index1()
            {
            return View();
            }

        // Méthodes CreerReservation
        [Authorize]

        public IActionResult ReserverOffrePerso(int id)
        {

            Dal dal = new Dal();
            OffrePerso offre = dal.ObtientToutesLesOffresPerso().Where(o => o.Id == id).FirstOrDefault();
            return View(offre);
        }

        [HttpPost]
        public IActionResult ReserverOffrePerso(OffrePerso OffreVoyage)
        {

            using (Dal dal = new Dal())
            {
                Membre membre = dal.ObtenirMembre(User.Identity.Name);
                dal.CreerReservationPerso(membre, OffreVoyage);
                return Redirect("/ReservationPerso/Index");
            }
        }

        public ActionResult AfficherToutesLesReservations()

        {
            List<ReservationPerso> reservations;
            using (Dal dal = new Dal())
            {
                reservations = dal.ObtientToutesLesReservationsPerso();
            }


            return View(reservations);

        }
    }
}

