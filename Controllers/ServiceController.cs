using CodeVoyage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System;

namespace CodeVoyage.Controllers
{
    public class ServiceController : Controller
    {
       public IActionResult CreerService()
        {
            return View();
        }

        //public IActionResult ModifierService(int id)
        //{
        //    if (id != 0)
        //    {
        //        using (Dal dal = new Dal())
        //        {
        //            Service service = dal.ObtientTousLesServices().Where(s => s.Id == id).FirstOrDefault();
        //            if (service == null)
        //            {
        //                return View("Error");
        //            }
        //            return View(service);
        //        }
        //    }
        //    return View("Error");
        //}
        [HttpPost]
        public IActionResult CreerService(string nomService, TypeService TypeService, int Capacite, DateTime DateDeb, DateTime DateFin, double Prix)
        {


            using (Dal dal = new Dal())
            {
                dal.CreerService(nomService, TypeService, Capacite,  DateDeb, DateFin, Prix);
                return RedirectToAction("CreerService");
            }


        }
        //public ActionResult Index()

        //{

        //    

        //    return View(entites.Services.ToList());

        //}

        [HttpPost]
        public IActionResult ModifierService(Service service)
        {

            if (!ModelState.IsValid)
                return View(service);

            if (service.Id != 0)
            {
                using (Dal dal = new Dal())
                {
                    dal.ModifierService(service);
                    return RedirectToAction("ModifierService", new { @id = service.Id });
                }
            }
            else
            {
                return View("Error");
            }
        }


        public IActionResult SupprimerService(int id)

        {
            using (Dal dal = new Dal())
            {
                dal.SupprimerService(id);
                return RedirectToAction("SupprimerService");

            }
        }
    }


}
