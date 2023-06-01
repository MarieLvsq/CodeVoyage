using CodeVoyage.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;

namespace CodeVoyage.ViewModels
    {
    public class OffreViewModel
        {
        public int Id { get; set; }
        public IEnumerable<SelectListItem> Itineraires { get; set; }
        public IEnumerable<SelectListItem> Evenements { get; set; }
        public IEnumerable<SelectListItem> ServicesdeBase { get; set; }
        public IEnumerable<SelectListItem> ServicesExtra { get; set; }
        public int Remise { get; set; }
        public double prixTotal { get; set; }
        public double prixAffiche { get; set; }
        public OffreViewModel(int id, IEnumerable itineraires, IEnumerable evenements, IEnumerable servicesdeBase, IEnumerable servicesExtra, int remise, double prixAffiche, double prixTotal)
            {
            Id = id;
            Itineraires = new SelectList(itineraires, "Depart", "Destination", itineraires);
            }
        }
    }
