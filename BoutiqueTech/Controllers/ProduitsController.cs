using Microsoft.AspNetCore.Mvc;
using BoutiqueTech.Models;
using BoutiqueTech.Services;
using System.IO;
namespace BoutiqueTech.Controllers
{
    public class ProduitsController : Controller
    {
        private readonly IServiceProduit _serviceProduit;

        public ProduitsController(IServiceProduit serviceProduit)
        {
            _serviceProduit = serviceProduit;
        }

        // GET: Produits
        public async Task<IActionResult> Index(string vue = "catalogue", string chaineRecherche = "", CategorieProduit? categorie = null)
        {
            var produits = await _serviceProduit.ObtenirTousLesProduitsAsync();

            // Filtrage par recherche
            if (!string.IsNullOrEmpty(chaineRecherche))
            {
                produits = await _serviceProduit.RechercherProduitsAsync(chaineRecherche);
                ViewData["FiltreActuel"] = chaineRecherche;
            }

            // Filtrage par catégorie
            if (categorie.HasValue)
            {
                produits = await _serviceProduit.ObtenirProduitsParCategorieAsync(categorie.Value);
                ViewData["CategorieActuelle"] = categorie;
            }

            // Données communes pour les deux vues
            ViewData["Categories"] = Enum.GetValues(typeof(CategorieProduit)).Cast<CategorieProduit>();
            ViewData["Statuts"] = Enum.GetValues(typeof(StatutProduit)).Cast<StatutProduit>();

            // Décision de la vue à retourner selon le paramètre 'vue'
            if (vue == "admin")
            {
                ViewData["Title"] = "Administration - Gestion des Produits";
                return View("IndexAdmin", produits);
            }
            else
            {
                ViewData["Title"] = "Catalogue des Produits";
                return View("Index", produits);
            }
        }

        // GET: Produits/Details/5
        public async Task<IActionResult> Details(int id, string retour = "catalogue")
        {
            var produit = await _serviceProduit.ObtenirProduitParIdAsync(id);
            if (produit == null)
            {
                TempData["MessageErreur"] = "Le produit demandé est introuvable.";
                return RedirectToAction(nameof(Index), new { vue = retour });
            }

            ViewData["Title"] = $"Détails - {produit.Nom}";
            ViewData["Retour"] = retour;

            // Retourner la vue appropriée selon le contexte
            if (retour == "admin")
            {
                return View("DetailsAdmin", produit);
            }
            else
            {
                return View("Details", produit);
            }
        }

        // GET: Produits/Creer
        public IActionResult Creer()
        {
            ViewData["Categories"] = Enum.GetValues(typeof(CategorieProduit)).Cast<CategorieProduit>();
            ViewData["Statuts"] = Enum.GetValues(typeof(StatutProduit)).Cast<StatutProduit>();
            ViewData["Title"] = "Ajouter un Nouveau Produit";
            return View();
        }

        // POST: Produits/Creer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Creer([Bind("Nom,Description,Prix,Categorie,Statut,Stock,Marque,UrlImage")] Produit produit)
        {
            if (ModelState.IsValid)
            {
                await _serviceProduit.CreerProduitAsync(produit);
                TempData["MessageSucces"] = $"Le produit '{produit.Nom}' a été créé avec succès !";
                return RedirectToAction(nameof(Index), new { vue = "admin" });
            }

            ViewData["Categories"] = Enum.GetValues(typeof(CategorieProduit)).Cast<CategorieProduit>();
            ViewData["Statuts"] = Enum.GetValues(typeof(StatutProduit)).Cast<StatutProduit>();
            ViewData["Title"] = "Ajouter un Nouveau Produit";
            return View(produit);
        }

        // GET: Produits/Modifier/5
        public async Task<IActionResult> Modifier(int id)
        {
            var produit = await _serviceProduit.ObtenirProduitParIdAsync(id);
            if (produit == null)
            {
                TempData["MessageErreur"] = "Le produit à modifier est introuvable.";
                return RedirectToAction(nameof(Index), new { vue = "admin" });
            }

            ViewData["Categories"] = Enum.GetValues(typeof(CategorieProduit)).Cast<CategorieProduit>();
            ViewData["Statuts"] = Enum.GetValues(typeof(StatutProduit)).Cast<StatutProduit>();
            ViewData["Title"] = $"Modifier - {produit.Nom}";
            return View(produit);
        }

        // POST: Produits/Modifier/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Modifier(int id, [Bind("Id,Nom,Description,Prix,Categorie,Statut,Stock,Marque,UrlImage,DateAjout")] Produit produit)
        {
            if (id != produit.Id)
            {
                TempData["MessageErreur"] = "Erreur de correspondance d'identifiant.";
                return RedirectToAction(nameof(Index), new { vue = "admin" });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _serviceProduit.ModifierProduitAsync(produit);
                    TempData["MessageSucces"] = $"Le produit '{produit.Nom}' a été modifié avec succès !";
                }
                catch (ArgumentException)
                {
                    TempData["MessageErreur"] = "Le produit à modifier est introuvable.";
                    return RedirectToAction(nameof(Index), new { vue = "admin" });
                }
                return RedirectToAction(nameof(Index), new { vue = "admin" });
            }

            ViewData["Categories"] = Enum.GetValues(typeof(CategorieProduit)).Cast<CategorieProduit>();
            ViewData["Statuts"] = Enum.GetValues(typeof(StatutProduit)).Cast<StatutProduit>();
            ViewData["Title"] = $"Modifier - {produit.Nom}";
            return View(produit);
        }

        // GET: Produits/Supprimer/5
        public async Task<IActionResult> Supprimer(int id)
        {
            var produit = await _serviceProduit.ObtenirProduitParIdAsync(id);
            if (produit == null)
            {
                TempData["MessageErreur"] = "Le produit à supprimer est introuvable.";
                return RedirectToAction(nameof(Index), new { vue = "admin" });
            }
            ViewData["Title"] = $"Supprimer - {produit.Nom}";
            return View(produit);
        }

        // POST: Produits/Supprimer/5
        [HttpPost, ActionName("Supprimer")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmerSuppression(int id)
        {
            var resultat = await _serviceProduit.SupprimerProduitAsync(id);
            if (resultat)
            {
                TempData["MessageSucces"] = "Le produit a été supprimé avec succès !";
            }
            else
            {
                TempData["MessageErreur"] = "Erreur lors de la suppression du produit.";
            }
            return RedirectToAction(nameof(Index), new { vue = "admin" });
        }
    }
}