using Microsoft.AspNetCore.Razor.TagHelpers;
using BoutiqueTech.Models;

namespace BoutiqueTech.TagHelpers
{
    [HtmlTargetElement("resume-statut")]
    public class ResumeStatutTagHelper : TagHelper
    {
        public IEnumerable<Produit> Produits { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "row text-center mb-4");

            var totalProduits = Produits.Count();
            var enStock = Produits.Count(p => p.Statut == StatutProduit.EnStock);
            var ruptureStock = Produits.Count(p => p.Statut == StatutProduit.RuptureStock);
            var preCommande = Produits.Count(p => p.Statut == StatutProduit.PreCommande);
            var stockTotal = Produits.Sum(p => p.Stock);
            var prixMoyen = totalProduits > 0 ? Produits.Average(p => p.Prix) : 0;

            output.Content.SetHtmlContent($@"
                <div class='col-lg-2 col-md-4 col-sm-6 mb-3'>
                    <div class='card bg-primary text-white h-100'>
                        <div class='card-body'>
                            <i class='fas fa-box-open fa-2x mb-2'></i>
                            <h4 class='fw-bold'>{totalProduits}</h4>
                            <p class='mb-0'>Total Produits</p>
                        </div>
                    </div>
                </div>
                <div class='col-lg-2 col-md-4 col-sm-6 mb-3'>
                    <div class='card bg-success text-white h-100'>
                        <div class='card-body'>
                            <i class='fas fa-check-circle fa-2x mb-2'></i>
                            <h4 class='fw-bold'>{enStock}</h4>
                            <p class='mb-0'>En Stock</p>
                        </div>
                    </div>
                </div>
                <div class='col-lg-2 col-md-4 col-sm-6 mb-3'>
                    <div class='card bg-danger text-white h-100'>
                        <div class='card-body'>
                            <i class='fas fa-times-circle fa-2x mb-2'></i>
                            <h4 class='fw-bold'>{ruptureStock}</h4>
                            <p class='mb-0'>Rupture Stock</p>
                        </div>
                    </div>
                </div>
                <div class='col-lg-2 col-md-4 col-sm-6 mb-3'>
                    <div class='card bg-warning text-dark h-100'>
                        <div class='card-body'>
                            <i class='fas fa-clock fa-2x mb-2'></i>
                            <h4 class='fw-bold'>{preCommande}</h4>
                            <p class='mb-0'>Pré-commande</p>
                        </div>
                    </div>
                </div>
                <div class='col-lg-2 col-md-4 col-sm-6 mb-3'>
                    <div class='card bg-info text-white h-100'>
                        <div class='card-body'>
                            <i class='fas fa-warehouse fa-2x mb-2'></i>
                            <h4 class='fw-bold'>{stockTotal}</h4>
                            <p class='mb-0'>Stock Total</p>
                        </div>
                    </div>
                </div>
                <div class='col-lg-2 col-md-4 col-sm-6 mb-3'>
                    <div class='card bg-secondary text-white h-100'>
                        <div class='card-body'>
                            <i class='fas fa-euro-sign fa-2x mb-2'></i>
                            <h4 class='fw-bold'>{prixMoyen:F0}€</h4>
                            <p class='mb-0'>Prix Moyen</p>
                        </div>
                    </div>
                </div>
            ");
        }
    }
}