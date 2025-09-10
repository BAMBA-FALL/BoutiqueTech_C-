using Microsoft.AspNetCore.Mvc;
using BoutiqueTech.Models;
using BoutiqueTech.Services;
using System.Diagnostics;

namespace BoutiqueTech.Controllers
{
    public class AccueilController : Controller
    {
        private readonly IServiceProduit _serviceProduit;

        public AccueilController(IServiceProduit serviceProduit)
        {
            _serviceProduit = serviceProduit;
        }

        public async Task<IActionResult> Index()
        {
            var produits = await _serviceProduit.ObtenirTousLesProduitsAsync();
            var produitsVedettes = produits.Take(6).ToList();
            ViewData["Title"] = "Accueil - BoutiqueTech";
            return View(produitsVedettes);
        }

        public IActionResult ViePrive()
        {
            ViewData["Title"] = "Politique de Confidentialité";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Erreur()
        {
            return View(new ModeleErreur { IdRequete = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class ModeleErreur
    {
        public string? IdRequete { get; set; }
        public bool AfficherIdRequete => !string.IsNullOrEmpty(IdRequete);
    }
}