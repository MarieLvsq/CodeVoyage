using CodeVoyage.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeVoyage.Controllers
{
    public class PaiementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index1()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string Nom, string Prenon, string Email, string numCb, string codeSecu, int OffreVoyageId)
        {


            using (Dal dal = new Dal())
            {
                dal.CreerPaiement(Nom, Email, OffreVoyageId);
                return View();
            }


        }
    }
}
