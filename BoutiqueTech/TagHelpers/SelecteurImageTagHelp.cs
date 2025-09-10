using Microsoft.AspNetCore.Razor.TagHelpers;
using BoutiqueTech.Models;

namespace BoutiqueTech.TagHelpers
{
    [HtmlTargetElement("selecteur-image")]
    public class SelecteurImageTagHelper : TagHelper
    {
        public CategorieProduit Categorie { get; set; }
        public string NomFichier { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "select";
            output.Attributes.SetAttribute("class", "form-select");
            output.Attributes.SetAttribute("name", "UrlImage");
            output.Attributes.SetAttribute("id", "UrlImage");

            var dossierCategorie = Categorie switch
            {
                CategorieProduit.Telephone => "Téléphone",
                CategorieProduit.OrdinateurPortable => "Ordinateur Portable",
                CategorieProduit.Tablette => "Tablette",
                CategorieProduit.Accessoire => "Accessoire",
                CategorieProduit.Gaming => "Gaming",
                _ => "default"
            };

            // Utiliser les MÊMES chemins que dans ServiceProduit.cs
            var imagesDisponibles = GetImagesDisponiblesPourCategorie(dossierCategorie);

            var options = "<option value=''>Choisir une image</option>";
            foreach (var image in imagesDisponibles)
            {
                var selected = image.Contains(NomFichier ?? "") ? "selected" : "";
                var nomAffichage = Path.GetFileNameWithoutExtension(image).Replace("-", " ");
                options += $"<option value='{image}' {selected}>{nomAffichage}</option>";
            }

            output.Content.SetHtmlContent(options);
        }

        private static List<string> GetImagesDisponiblesPourCategorie(string categorie)
        {
            // MÊMES chemins que dans ServiceProduit.cs
            return categorie switch
            {
                "Téléphone" => new List<string>
                {
                    "/images/Téléphone/iphone15pro.jpg",
                    "/images/Téléphone/samsung-s24-ultra.jpg",
                    "/images/Téléphone/pixel-8-pro.jpg",
                    "/images/Téléphone/xiaomi-14.jpg"
                },
                "Ordinateur Portable" => new List<string>
                {
                    "/images/Ordinateur Portable/macbook-air-m3.jpg",
                    "/images/Ordinateur Portable/dell-xps-13.jpg",
                    "/images/Ordinateur Portable/surface-laptop.jpg",
                    "/images/Ordinateur Portable/thinkpad-x1.jpg"
                },
                "Tablette" => new List<string>
                {
                    "/images/Tablette/ipad-air-6.jpg",
                    "/images/Tablette/surface-pro.jpg",
                    "/images/Tablette/galaxy-tab-s9.jpg",
                    "/images/Tablette/ipad-pro.jpg"
                },
                "Accessoire" => new List<string>
                {
                    "/images/Accessoire/airpods-pro-3.jpg",
                    "/images/Accessoire/logitech-mx-master.jpg",
                    "/images/Accessoire/anker-charger.jpg",
                    "/images/Accessoire/webcam-logitech.jpg"
                },
                "Gaming" => new List<string>
                {
                    "/images/Gaming/ps5-pro.jpg",
                    "/images/Gaming/xbox-series-x.jpg",
                    "/images/Gaming/nintendo-switch.jpg",
                    "/images/Gaming/steam-deck.jpg"
                },
                _ => new List<string> { "/images/produit-defaut.jpg" }
            };
        }
    }
}