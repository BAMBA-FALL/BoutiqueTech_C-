using Microsoft.AspNetCore.Mvc;
using BoutiqueTech.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoutiqueTech.Controllers
{
    public class CommandeController : Controller
    {
        // GET: /Commande/Index
        public IActionResult Index()
        {
            ViewData["Title"] = "Finaliser ma commande";
            return View();
        }

        // POST: /Commande/Valider
        [HttpPost]
        public async Task<IActionResult> Valider([FromBody] CommandeModel commande)
        {
            try
            {
                // Ici vous pourriez enregistrer la commande en base de données
                // await _serviceCommande.CreerCommandeAsync(commande);

                // Génération d'un numéro de commande
                var numeroCommande = GenerateCommandeNumber();

                return Json(new
                {
                    success = true,
                    numeroCommande = numeroCommande,
                    message = "Commande validée avec succès !"
                });
            }
            catch (Exception)
            {
                return Json(new
                {
                    success = false,
                    message = "Erreur lors de la validation de la commande."
                });
            }
        }

        private string GenerateCommandeNumber()
        {
            var now = DateTime.Now;
            var random = new Random().Next(100, 999);
            return $"CMD-{now:yyyyMMdd}-{random:D3}";
        }
    }

    public class CommandeModel
    {
        public string Prenom { get; set; } = string.Empty;
        public string Nom { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public string Adresse { get; set; } = string.Empty;
        public string CodePostal { get; set; } = string.Empty;
        public string Ville { get; set; } = string.Empty;
        public List<ArticleCommande> Articles { get; set; } = new();
        public decimal Total { get; set; }
    }

    public class ArticleCommande
    {
        public int ProduitId { get; set; }
        public string Nom { get; set; } = string.Empty;
        public int Quantite { get; set; }
        public decimal Prix { get; set; }
    }
}
