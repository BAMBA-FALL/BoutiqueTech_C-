using Microsoft.AspNetCore.Razor.TagHelpers;
using BoutiqueTech.Models;

namespace BoutiqueTech.TagHelpers
{
    [HtmlTargetElement("statut-produit")]
    public class StatutProduitTagHelper : TagHelper
    {
        public StatutProduit Statut { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";

            var (classBadge, icone, texte) = Statut switch
            {
                StatutProduit.EnStock => ("badge bg-success", "fas fa-check-circle", "En Stock"),
                StatutProduit.RuptureStock => ("badge bg-danger", "fas fa-times-circle", "Rupture de Stock"),
                StatutProduit.PreCommande => ("badge bg-warning text-dark", "fas fa-clock", "Pré-commande"),
                _ => ("badge bg-secondary", "fas fa-question", "Statut Inconnu")
            };

            output.Attributes.SetAttribute("class", classBadge);
            output.Content.SetHtmlContent($"<i class='{icone}'></i> {texte}");
        }
    }
}