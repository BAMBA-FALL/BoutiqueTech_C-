using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BoutiqueTech.TagHelpers
{
    [HtmlTargetElement("affichage-prix")]
    public class AffichagePrixTagHelper : TagHelper
    {
        public decimal Prix { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";
            output.Attributes.SetAttribute("class", "prix-affichage text-success fw-bold");

            var prixFormate = Prix.ToString("F2", new System.Globalization.CultureInfo("fr-FR"));
            output.Content.SetHtmlContent($"<i class='fas fa-euro-sign'></i> {prixFormate} €");
        }
    }
}