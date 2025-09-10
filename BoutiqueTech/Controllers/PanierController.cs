using Microsoft.AspNetCore.Mvc;
using BoutiqueTech.Models;
using BoutiqueTech.Services;
using System.Collections.Generic;
using System.Text.Json;

namespace BoutiqueTech.Controllers
{
    public class PanierController : Controller
    {
        private readonly IServiceProduit _serviceProduit;

        public PanierController(IServiceProduit serviceProduit)
        {
            _serviceProduit = serviceProduit;
        }

        // GET: /Panier/Index
        public IActionResult Index()
        {
            // On laisse le panier être géré par localStorage côté client
            // Le contrôleur ne fait que renvoyer la vue
            ViewData["Title"] = "Mon Panier";
            return View();
        }

        // POST: /Panier/Ajouter
        [HttpPost]
        public async Task<IActionResult> Ajouter(int produitId, int quantite = 1)
        {
            try
            {
                var produit = await _serviceProduit.ObtenirProduitParIdAsync(produitId);
                if (produit == null)
                {
                    return Json(new { success = false, message = "Produit introuvable." });
                }

                if (produit.Statut != StatutProduit.EnStock || produit.Stock < quantite)
                {
                    return Json(new { success = false, message = "Stock insuffisant." });
                }

                // Retourner les données du produit pour JavaScript
                return Json(new
                {
                    success = true,
                    produit = new
                    {
                        id = produit.Id,
                        nom = produit.Nom,
                        prix = produit.Prix,
                        urlImage = produit.UrlImage,
                        marque = produit.Marque,
                        description = produit.Description,
                        stock = produit.Stock
                    },
                    quantite = quantite,
                    message = $"{quantite} article(s) ajouté(s) au panier !"
                });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Erreur lors de l'ajout au panier." });
            }
        }

        // GET: /Panier/ObtenirProduit/{id} - Pour récupérer les détails d'un produit
        [HttpGet]
        public async Task<IActionResult> ObtenirProduit(int id)
        {
            try
            {
                var produit = await _serviceProduit.ObtenirProduitParIdAsync(id);
                if (produit == null)
                {
                    return Json(new { success = false, message = "Produit introuvable." });
                }

                return Json(new
                {
                    success = true,
                    produit = new
                    {
                        id = produit.Id,
                        nom = produit.Nom,
                        prix = produit.Prix,
                        urlImage = produit.UrlImage,
                        marque = produit.Marque,
                        description = produit.Description,
                        stock = produit.Stock,
                        statut = produit.Statut.ToString()
                    }
                });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Erreur lors de la récupération du produit." });
            }
        }
    }
}