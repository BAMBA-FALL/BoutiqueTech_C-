using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BoutiqueTech.TagHelpers
{
    [HtmlTargetElement("indicateur-stock")]
    public class IndicateurStockTagHelper : TagHelper
    {
        public int Stock { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";

            var (classBadge, icone, texte) = Stock switch
            {
                > 20 => ("badge bg-success", "fas fa-check-circle", $"{Stock} unités disponibles"),
                > 5 => ("badge bg-warning text-dark", "fas fa-exclamation-triangle", $"{Stock} unités restantes"),
                > 0 => ("badge bg-danger", "fas fa-exclamation-circle", $"Attention : {Stock} unités seulement"),
                _ => ("badge bg-dark", "fas fa-times", "Rupture de stock")
            };

            output.Attributes.SetAttribute("class", classBadge);
            output.Content.SetHtmlContent($"<i class='{icone}'></i> {texte}");
        }
    }
}