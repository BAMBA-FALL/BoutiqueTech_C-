using System.ComponentModel.DataAnnotations;

namespace BoutiqueTech.Models
{
    public enum CategorieProduit
    {
        [Display(Name = "Téléphone")]
        Telephone,
        [Display(Name = "Ordinateur Portable")]
        OrdinateurPortable,
        [Display(Name = "Tablette")]
        Tablette,
        [Display(Name = "Accessoire")]
        Accessoire,
        [Display(Name = "Gaming")]
        Gaming
    }

    public enum StatutProduit
    {
        [Display(Name = "En Stock")]
        EnStock,
        [Display(Name = "Rupture de Stock")]
        RuptureStock,
        [Display(Name = "Pré-commande")]
        PreCommande
    }

    public class Produit
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom du produit est obligatoire")]
        [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères")]
        [Display(Name = "Nom du produit")]
        public string Nom { get; set; } = string.Empty;

        [Required(ErrorMessage = "La description est obligatoire")]
        [StringLength(500, ErrorMessage = "La description ne peut pas dépasser 500 caractères")]
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le prix est obligatoire")]
        [Range(0.01, 10000, ErrorMessage = "Le prix doit être entre 0.01€ et 10000€")]
        [Display(Name = "Prix (€)")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal Prix { get; set; }

        [Required(ErrorMessage = "La catégorie est obligatoire")]
        [Display(Name = "Catégorie")]
        public CategorieProduit Categorie { get; set; }

        [Required(ErrorMessage = "Le statut est obligatoire")]
        [Display(Name = "Statut")]
        public StatutProduit Statut { get; set; }

        [Required(ErrorMessage = "La date d'ajout est obligatoire")]
        [DataType(DataType.Date)]
        [Display(Name = "Date d'ajout")]
        public DateTime DateAjout { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "La quantité en stock est obligatoire")]
        [Range(0, 1000, ErrorMessage = "Le stock doit être entre 0 et 1000")]
        [Display(Name = "Stock disponible")]
        public int Stock { get; set; }

        [Display(Name = "URL de l'image")]
        [Url(ErrorMessage = "Veuillez entrer une URL valide")]
        public string UrlImage { get; set; } = "/images/produit-defaut.jpg";

        [StringLength(50, ErrorMessage = "La marque ne peut pas dépasser 50 caractères")]
        [Display(Name = "Marque")]
        public string Marque { get; set; } = string.Empty;
    }
}