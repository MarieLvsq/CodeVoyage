using System.ComponentModel.DataAnnotations;

namespace CodeVoyage.Models
{
    public class Paiement
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le nom doit être saisi.")]


        public string Nom { get; set; }

        [Required(ErrorMessage = "Cette section doit être remplie.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Numéro Carte Bancaire")]

        [RegularExpression(@"^\d{16}$", ErrorMessage = "Il doit contenir 16 chiffres !")]
        public string numCb { get; set; }

        [Display(Name = "Code de Sécurité")]

        [RegularExpression(@"^\d{3}$", ErrorMessage = "Le code doit contenir 3 chiffres !")]
        public string codeSecu { get; set; }

        public int OffreVoyageId { get; set; }
        public virtual OffreVoyage OffrePayee { get; set; }


    }
}
