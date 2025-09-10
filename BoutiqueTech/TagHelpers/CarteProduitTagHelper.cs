using Microsoft.AspNetCore.Razor.TagHelpers;
using BoutiqueTech.Models;

namespace BoutiqueTech.TagHelpers
{
    [HtmlTargetElement("carte-produit")]
    public class CarteProduitTagHelper : TagHelper
    {
        public Produit Produit { get; set; }
        public bool AfficherActions { get; set; } = false;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "card h-100 shadow-sm product-card");

            // Utiliser l'image du produit ou l'image par défaut de sa catégorie
            var imageUrl = string.IsNullOrEmpty(Produit.UrlImage) ?
                GetImageParDefautPourCategorie(Produit.Categorie) :
                Produit.UrlImage;

            var badgeStatut = Produit.Statut switch
            {
                StatutProduit.EnStock => "<span class='badge bg-success'><i class='fas fa-check-circle'></i> En Stock</span>",
                StatutProduit.RuptureStock => "<span class='badge bg-danger'><i class='fas fa-times-circle'></i> Rupture</span>",
                StatutProduit.PreCommande => "<span class='badge bg-warning text-dark'><i class='fas fa-clock'></i> Pré-commande</span>",
                _ => ""
            };

            var couleurStock = Produit.Stock > 20 ? "text-success" :
                               Produit.Stock > 5 ? "text-warning" : "text-danger";

            var actionsHtml = AfficherActions ? $@"
                <div class='card-footer bg-transparent'>
                    <div class='btn-group w-100' role='group'>
                        <a href='/Produits/Details/{Produit.Id}' class='btn btn-outline-primary btn-sm'>
                            <i class='fas fa-eye'></i> Voir
                        </a>
                        <a href='/Produits/Modifier/{Produit.Id}' class='btn btn-outline-warning btn-sm'>
                            <i class='fas fa-edit'></i> Modifier
                        </a>
                        <a href='/Produits/Supprimer/{Produit.Id}' class='btn btn-outline-danger btn-sm'>
                            <i class='fas fa-trash'></i> Supprimer
                        </a>
                    </div>
                </div>
            " : $@"
                <div class='card-footer bg-transparent'>
                    <a href='/Produits/Details/{Produit.Id}' class='btn btn-primary w-100'>
                        <i class='fas fa-eye'></i> Voir les détails
                    </a>
                </div>
            ";

            var nomCategorie = Produit.Categorie switch
            {
                CategorieProduit.Telephone => "Téléphone",
                CategorieProduit.OrdinateurPortable => "Ordinateur Portable",
                CategorieProduit.Tablette => "Tablette",
                CategorieProduit.Accessoire => "Accessoire",
                CategorieProduit.Gaming => "Gaming",
                _ => Produit.Categorie.ToString()
            };

            output.Content.SetHtmlContent($@"
                <div class='card-img-container' style='height: 200px; overflow: hidden;'>
                    <img src='{imageUrl}' class='card-img-top' alt='{Produit.Nom}' 
                         style='height: 100%; object-fit: cover; width: 100%;'
                         onerror='this.src=""{GetImageParDefautPourCategorie(Produit.Categorie)}""'>
                </div>
                <div class='card-body d-flex flex-column'>
                    <div class='d-flex justify-content-between align-items-start mb-2'>
                        <h6 class='card-title mb-0' title='{Produit.Nom}'>{(Produit.Nom.Length > 25 ? Produit.Nom.Substring(0, 25) + "..." : Produit.Nom)}</h6>
                        {badgeStatut}
                    </div>
                    <p class='card-text text-muted small flex-grow-1' title='{Produit.Description}'>
                        {(Produit.Description.Length > 80 ? Produit.Description.Substring(0, 80) + "..." : Produit.Description)}
                    </p>
                    <div class='mt-auto'>
                        <div class='d-flex justify-content-between align-items-center mb-2'>
                            <span class='badge bg-secondary'><i class='fas fa-tag'></i> {nomCategorie}</span>
                            <small class='{couleurStock}'>
                                <i class='fas fa-box'></i> Stock: {Produit.Stock}
                            </small>
                        </div>
                        <div class='d-flex justify-content-between align-items-center mb-2'>
                            <strong class='text-success h5 mb-0'>
                                <i class='fas fa-euro-sign'></i> {Produit.Prix:F2} €
                            </strong>
                            {(string.IsNullOrEmpty(Produit.Marque) ? "" : $"<small class='text-muted'><i class='fas fa-industry'></i> {Produit.Marque}</small>")}
                        </div>
                    </div>
                </div>
                {actionsHtml}
            ");
        }

        private static string GetImageParDefautPourCategorie(CategorieProduit categorie)
        {
            return categorie switch
            {
                CategorieProduit.Telephone => "/images/Téléphone/default-phone.jpg",
                CategorieProduit.OrdinateurPortable => "/images/Ordinateur Portable/default-laptop.jpg",
                CategorieProduit.Tablette => "/images/Tablette/default-tablet.jpg",
                CategorieProduit.Accessoire => "/images/Accessoire/default-accessory.jpg",
                CategorieProduit.Gaming => "/images/Gaming/default-gaming.jpg",
                _ => "/images/produit-defaut.jpg"
            };
        }
    }
}