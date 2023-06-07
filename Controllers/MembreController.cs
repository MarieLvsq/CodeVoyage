using CodeVoyage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeVoyage.Controllers
{
    public class MembreController : Controller
    {

        // Méthodes Ajouter

        /*public IActionResult InscriptionMembre()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InscriptionMembre(string Nom, string Prenon, string Email , string Localisation, int Age)
        {


            using (Dal dal = new Dal())
            {
                dal.InscriptionMembre(Nom,Prenon,Email,Localisation,Age);
                return RedirectToAction("AfficherTousLesMembres");
            }


        }
        */

        //Méthodes Supprimer

        public IActionResult SupprimerMembre(int id)

        {
            using (Dal dal = new Dal())
            {
                dal.SupprimerMembre(id);

                return RedirectToAction("AfficherTousLesMembres");

            }
        }
        //Méthodes Modifier

        public IActionResult ModifierMembre(int id)
        {
            if (id != 0)
            {
                using (Dal dal = new Dal())
                {
                    Membre membre  = dal.ObtientTousLesMembres().Where(s => s.Id == id).FirstOrDefault();
                    if (membre== null)
                    {
                        return View("Error");
                    }
                    return View(membre);
                }
            }
            return View("Error");

        }

        [HttpPost]
        public IActionResult ModifierMembre(Membre membre)
        {

            if (!ModelState.IsValid)
                return View(membre);

            if (membre.Id != 0)
            {
                using (Dal dal = new Dal())
                {
                    dal.ModifierMembre(membre);
                    return RedirectToAction("ModifierMembre", new { @id = membre.Id });
                }
            }
            else
            {
                return View("Error");
            }
        }

        //Méthodes affichage 


        public ActionResult AfficherTousLesMembres()

        {
            List<Membre> membres;
            using (Dal dal = new Dal())
            {
                membres = dal.ObtientTousLesMembres();
            }


            return View(membres);

        }

        public ActionResult EspaceMembre()

        {
           return View();

        }
    }


}
