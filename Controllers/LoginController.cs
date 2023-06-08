using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CodeVoyage.Models;
using CodeVoyage.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeVoyage.Controllers
{
    public class LoginController : Controller
    {
        private Dal dal;
        public LoginController()
        {
            dal = new Dal();
        }

        // MEMBRE- LOGIN

        public IActionResult IndexM()
        {
            MembreViewModel viewModel = new MembreViewModel { AuthentifierM = HttpContext.User.Identity.IsAuthenticated };
            if (viewModel.AuthentifierM)
            {
                viewModel.Membre = dal.ObtenirMembre(HttpContext.User.Identity.Name);
                return View(viewModel);
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult IndexM(MembreViewModel viewModel, string returnUrl)
        {
            if (viewModel.Membre.Email != null && viewModel.Membre.MotDePasse != null)
            {
                Membre membre = dal.AuthentifierM(viewModel.Membre.Email, viewModel.Membre.MotDePasse);
                if (membre != null)
                {
                    var userClaims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, membre.Id.ToString()),
                       //new Claim(ClaimTypes.Role, utilisateur.Role),

                    };

                    var ClaimIdentity = new ClaimsIdentity(userClaims, "User Identity");

                    var userPrincipal = new ClaimsPrincipal(new[] { ClaimIdentity });

                    HttpContext.SignInAsync(userPrincipal);

                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);

                    return Redirect("../Membre/EspaceMembre");
                }
                ModelState.AddModelError("Membre.Prenom", "Email et/ou mot de passe incorrect(s)");
            }
            return View("IndexM");
        }

        [HttpPost]
        public IActionResult CreerCompteM(Membre membre)
        {
            if (ModelState.IsValid)
            {
                int id = dal.InscriptionMembre(membre.Nom, membre.Prenom, membre.MotDePasse, membre.Email, membre.Localisation, membre.Age, membre.User);

                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, id.ToString()),
                };

                var ClaimIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { ClaimIdentity });
                HttpContext.SignInAsync(userPrincipal);

                return Redirect("../Membre/EspaceMembre");// retourne à la vue du membre 
            }
            return View("CreerCompteMembre", membre);
        }

        public ActionResult DeconnexionM()
        {
            HttpContext.SignOutAsync();
            return Redirect("/");
        }

        /* public IActionResult IndexMe()
         {
             return View("../LoginMembre/Index");
         }*/

        public IActionResult CreerCompteMembre()
        {
            return View();
        }

        // PARTENAIRE-LOGIN



        public IActionResult IndexP()
        {
            PartenaireViewModel viewModel = new PartenaireViewModel { AuthentifierP = HttpContext.User.Identity.IsAuthenticated };
            if (viewModel.AuthentifierP)
            {
                viewModel.Partenaire = dal.ObtenirPartenaire(HttpContext.User.Identity.Name);
                return View(viewModel);
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult IndexP(PartenaireViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Partenaire partenaire = dal.AuthentifierP(viewModel.Partenaire.email, viewModel.Partenaire.MotDePasse);
                if (partenaire != null)
                {
                    var userClaims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, partenaire.Id.ToString()),
                       //new Claim(ClaimTypes.Role, utilisateur.Role),

                    };

                    var ClaimIdentity = new ClaimsIdentity(userClaims, "User Identity");

                    var userPrincipal = new ClaimsPrincipal(new[] { ClaimIdentity });

                    HttpContext.SignInAsync(userPrincipal);

                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);

                    return Redirect("../Partenaire/EspacePartenaire");
                }
                ModelState.AddModelError("Utilisateur.Prenom", "Prénom et/ou mot de passe incorrect(s)");
            }
            return View("IndexP");
        }


        [HttpPost]
        public IActionResult CreerCompteP(Partenaire partenaire)
        {
            if (ModelState.IsValid)
            {
                int id = dal.InscriptionPartenaire(partenaire.Nom, partenaire.Localisation, partenaire.email, partenaire.MotDePasse, partenaire.NumSiret, partenaire.TypeService, partenaire.Role);

                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, id.ToString()),
                };

                var ClaimIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { ClaimIdentity });
                HttpContext.SignInAsync(userPrincipal);

                return Redirect("../Partenaire/EspacePartenaire");
            }
            return View("CreerComptePartenaire", partenaire);
        }

        public IActionResult CreerComptePartenaire()
        {
            return View();
        }


        public ActionResult DeconnexionP()
        {
            HttpContext.SignOutAsync();
            return Redirect("../Home/Index");
        }

        //ADMIN-LOGIN

        public IActionResult IndexA()
        {
            AdminViewModel viewModel = new AdminViewModel { AuthentifierA = HttpContext.User.Identity.IsAuthenticated };
            if (viewModel.AuthentifierA)
            {
                using (var admindal = new Dal())
                {
                    viewModel.Admin = dal.ObtenirAdmin(HttpContext.User.Identity.Name);
                    return View(viewModel);
                }
            }
            return View(viewModel);
        }
        
        [HttpPost]
        public IActionResult IndexA(AdminViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                using (var admindal = new Dal())
                {
                    Admin admin = admindal.AuthentifierA(viewModel.Admin.Email, viewModel.Admin.MotDePasse);
                    if (admin != null)
                    {
                        var userClaims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, admin.Id.ToString()),
                       //new Claim(ClaimTypes.Role, utilisateur.Role),

                    };

                        var ClaimIdentity = new ClaimsIdentity(userClaims, "User Identity");

                        var userPrincipal = new ClaimsPrincipal(new[] { ClaimIdentity });



                        HttpContext.SignInAsync(userPrincipal);

                        if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))

                            return Redirect(returnUrl);

                        return View("../Home/Admin");
                    }
                    else
                    {
                        ModelState.AddModelError("Utilisateur.Prenom", "Prénom et/ou mot de passe incorrect(s)");
                        return View(viewModel);
                    }
                    
                    
                }
                

            }
            return View(viewModel); ;
        }

        public IActionResult VueAdmin()
        {
            return View();
        }

        public ActionResult DeconnexionA()
        {
            HttpContext.SignOutAsync();
            return Redirect("../Home/Index");
        }
    }
}

