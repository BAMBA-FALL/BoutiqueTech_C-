using BoutiqueTech.Models;

namespace BoutiqueTech.Services
{
    public interface IServiceProduit
    {
        Task<IEnumerable<Produit>> ObtenirTousLesProduitsAsync();
        Task<Produit?> ObtenirProduitParIdAsync(int id);
        Task<Produit> CreerProduitAsync(Produit produit);
        Task<Produit> ModifierProduitAsync(Produit produit);
        Task<bool> SupprimerProduitAsync(int id);
        Task<IEnumerable<Produit>> RechercherProduitsAsync(string termeRecherche);
        Task<IEnumerable<Produit>> ObtenirProduitsParCategorieAsync(CategorieProduit categorie);
    }
}