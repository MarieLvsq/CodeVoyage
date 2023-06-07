using CodeVoyage.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;

namespace CodeVoyage.Controllers
{
    public class PartenaireController : Controller
    {
        // Méthodes Créer

        public IActionResult InscriptionPartenaire()
        {
            return View();
        }
        public IActionResult EspacePartenaire()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InscriptionPartenaire(string Nom, string Localisation , string email,string motDePasse, string numSiret, TypeService typeService, Role role)
        {


            using (Dal dal = new Dal())
            {
                dal.InscriptionPartenaire(Nom, Localisation, email,motDePasse, numSiret, typeService,role);
                return RedirectToAction("InscriptionPartenaire");
            }


        }
        //Méthodes Supprimer

        public IActionResult SupprimerPartenaire(int id)

        {
            using (Dal dal = new Dal())
            {
                dal.SupprimerPartenaire(id);

                return RedirectToAction("AfficherTousLesPartenaires");

            }
        }
        //Méthodes Modifier

        public IActionResult ModifierPartenaire(int id)
        {
            if (id != 0)
            {
                using (Dal dal = new Dal())
                {
                    Partenaire partenaire = dal.ObtientTousLesPartenaires().Where(p => p.Id == id).FirstOrDefault();
                    if (partenaire == null)
                    {
                        return View("Error");
                    }
                    return View(partenaire);
                }
            }
            return View("Error");

        }

        [HttpPost]
        public IActionResult ModifierPartenaire(Partenaire partenaire)
        {

            if (!ModelState.IsValid)
                return View(partenaire);
            
            if (partenaire.Id != 0)
            {
                using (Dal dal = new Dal())
                {
                    dal.ModifierPartenaire(partenaire);
                    return RedirectToAction("ModifierPartenaire", new { @id = partenaire.Id });
                }
            }
            else
            {
                return View("Error");
            }
        }

        //Méthodes affichage 


        public ActionResult AfficherTousLesPartenaires()

        {
            List<Partenaire> partenaires;
            using (Dal dal = new Dal())
            {
                partenaires = dal.ObtientTousLesPartenaires();
            }


            return View(partenaires);

        }


    }

}

