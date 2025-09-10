using System.ComponentModel.DataAnnotations;

namespace BoutiqueTech.Models
{
    public class UserModel
    {
        [Required]
        public string Nom { get; set; }

        [Required]
        public string Prenom { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string MotDePasse { get; set; }

        public string Adresse { get; set; }

        public string Telephone { get; set; }
    }
}
