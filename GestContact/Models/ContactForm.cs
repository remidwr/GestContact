using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestContact.Models
{
    public class ContactForm
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Votre Nom : ", Description = "Inserez votre nom ")]
        public string Prenom { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Entrez votre adresse mail : ")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Ne correspont pas au format d'adresse E-Mail")]
        public string Email { get; set; }
        [Compare("Email", ErrorMessage = "Les Deux e-mails doivent correspondre")]
        [DisplayName("Répétez l'e-mail")]
        public string RepeatEmail { get; set; }
        public string Telephone { get; set; }
    }
}