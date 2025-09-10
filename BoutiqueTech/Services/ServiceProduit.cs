using BoutiqueTech.Models;

namespace BoutiqueTech.Services
{
    public class ServiceProduit : IServiceProduit
    {
        private static List<Produit> _produits = new List<Produit>
        {
            // TÉLÉPHONES
            new Produit
            {
                Id = 1,
                Nom = "iPhone 15 Pro",
                Description = "Dernier iPhone avec puce A17 Pro et appareil photo révolutionnaire",
                Prix = 1199,
                Categorie = CategorieProduit.Telephone,
                Statut = StatutProduit.EnStock,
                Stock = 25,
                Marque = "Apple",
                DateAjout = DateTime.Now.AddDays(-30),
                UrlImage = "/images/Téléphone/iphone15pro.jpeg"
            },
            new Produit
            {
                Id = 2,
                Nom = "Samsung Galaxy S24 Ultra",
                Description = "Smartphone Android haut de gamme avec stylet S Pen inclus",
                Prix = 1299,
                Categorie = CategorieProduit.Telephone,
                Statut = StatutProduit.EnStock,
                Stock = 30,
                Marque = "Samsung",
                DateAjout = DateTime.Now.AddDays(-28),
                UrlImage = "/images/Téléphone/samsung-s24-ultra.jpg"
            },
            new Produit
            {
                Id = 3,
                Nom = "Google Pixel 8 Pro",
                Description = "Smartphone Google avec intelligence artificielle avancée",
                Prix = 899,
                Categorie = CategorieProduit.Telephone,
                Statut = StatutProduit.RuptureStock,
                Stock = 0,
                Marque = "Google",
                DateAjout = DateTime.Now.AddDays(-26),
                UrlImage = "/images/Téléphone/pixel-8-pro.avif"
            },

            // ORDINATEURS PORTABLES
            new Produit
            {
                Id = 4,
                Nom = "MacBook Air M3",
                Description = "Ordinateur portable ultra-léger avec la nouvelle puce M3",
                Prix = 1399,
                Categorie = CategorieProduit.OrdinateurPortable,
                Statut = StatutProduit.EnStock,
                Stock = 15,
                Marque = "Apple",
                DateAjout = DateTime.Now.AddDays(-25),
                UrlImage = "/images/Ordinateur Portable/macbook-air-m3.jpg"
            },
            new Produit
            {
                Id = 5,
                Nom = "Dell XPS 13",
                Description = "Ultrabook Windows haut de gamme avec écran InfinityEdge",
                Prix = 1299,
                Categorie = CategorieProduit.OrdinateurPortable,
                Statut = StatutProduit.EnStock,
                Stock = 12,
                Marque = "Dell",
                DateAjout = DateTime.Now.AddDays(-23),
                UrlImage = "/images/Ordinateur Portable/dell-xps-13.jpg"
            },
            new Produit
            {
                Id = 6,
                Nom = "Surface Laptop 5",
                Description = "Ordinateur portable Microsoft élégant et performant",
                Prix = 1199,
                Categorie = CategorieProduit.OrdinateurPortable,
                Statut = StatutProduit.EnStock,
                Stock = 10,
                Marque = "Microsoft",
                DateAjout = DateTime.Now.AddDays(-21),
                UrlImage = "/images/Ordinateur Portable/surface-laptop.jpg"
            },

            // TABLETTES
            new Produit
            {
                Id = 7,
                Nom = "iPad Air 6ème génération",
                Description = "Tablette polyvalente parfaite pour le travail et les loisirs",
                Prix = 649,
                Categorie = CategorieProduit.Tablette,
                Statut = StatutProduit.EnStock,
                Stock = 18,
                Marque = "Apple",
                DateAjout = DateTime.Now.AddDays(-15),
                UrlImage = "/images/Tablette/ipad-air-6.jpg"
            },
            new Produit
            {
                Id = 8,
                Nom = "Surface Pro 10",
                Description = "Tablette 2-en-1 pour les professionnels créatifs",
                Prix = 899,
                Categorie = CategorieProduit.Tablette,
                Statut = StatutProduit.EnStock,
                Stock = 14,
                Marque = "Microsoft",
                DateAjout = DateTime.Now.AddDays(-17),
                UrlImage = "/images/Tablette/surface-pro.jpg"
            },
            new Produit
            {
                Id = 9,
                Nom = "Galaxy Tab S9 Ultra",
                Description = "Grande tablette Android avec S Pen inclus",
                Prix = 799,
                Categorie = CategorieProduit.Tablette,
                Statut = StatutProduit.EnStock,
                Stock = 12,
                Marque = "Samsung",
                DateAjout = DateTime.Now.AddDays(-13),
                UrlImage = "/images/Tablette/galaxy-tab-s9.jpg"
            },

            // ACCESSOIRES
            new Produit
            {
                Id = 10,
                Nom = "AirPods Pro 3",
                Description = "Écouteurs sans fil avec réduction de bruit active améliorée",
                Prix = 279,
                Categorie = CategorieProduit.Accessoire,
                Statut = StatutProduit.EnStock,
                Stock = 50,
                Marque = "Apple",
                DateAjout = DateTime.Now.AddDays(-10),
                UrlImage = "/images/Accessoire/airpods-pro-3.jpg"
            },
            new Produit
            {
                Id = 11,
                Nom = "Logitech MX Master 3S",
                Description = "Souris ergonomique professionnelle ultra-précise",
                Prix = 99,
                Categorie = CategorieProduit.Accessoire,
                Statut = StatutProduit.EnStock,
                Stock = 35,
                Marque = "Logitech",
                DateAjout = DateTime.Now.AddDays(-8),
                UrlImage = "/images/Accessoire/logitech-mx-master.jpg"
            },
            new Produit
            {
                Id = 12,
                Nom = "Anker PowerCore 20K",
                Description = "Batterie externe haute capacité avec charge rapide",
                Prix = 49,
                Categorie = CategorieProduit.Accessoire,
                Statut = StatutProduit.EnStock,
                Stock = 40,
                Marque = "Anker",
                DateAjout = DateTime.Now.AddDays(-6),
                UrlImage = "/images/Accessoire/anker-charger.jpg"
            },

            // GAMING
            new Produit
            {
                Id = 13,
                Nom = "PlayStation 5 Pro",
                Description = "Console de jeu nouvelle génération avec performances 4K",
                Prix = 799,
                Categorie = CategorieProduit.Gaming,
                Statut = StatutProduit.RuptureStock,
                Stock = 0,
                Marque = "Sony",
                DateAjout = DateTime.Now.AddDays(-5),
                UrlImage = "/images/Gaming/ps5-pro.jpg"
            },
            new Produit
            {
                Id = 14,
                Nom = "Xbox Series X",
                Description = "Console Microsoft ultra-puissante pour le gaming 4K",
                Prix = 499,
                Categorie = CategorieProduit.Gaming,
                Statut = StatutProduit.EnStock,
                Stock = 8,
                Marque = "Microsoft",
                DateAjout = DateTime.Now.AddDays(-3),
                UrlImage = "/images/Gaming/xbox-series-x.jpg"
            },
            new Produit
            {
                Id = 15,
                Nom = "Nintendo Switch OLED",
                Description = "Console portable hybride avec écran OLED amélioré",
                Prix = 349,
                Categorie = CategorieProduit.Gaming,
                Statut = StatutProduit.EnStock,
                Stock = 22,
                Marque = "Nintendo",
                DateAjout = DateTime.Now.AddDays(-1),
                UrlImage = "/images/Gaming/nintendo-switch.jpg"
            }
        };

        private static int _prochainId = 16;

        public async Task<IEnumerable<Produit>> ObtenirTousLesProduitsAsync()
        {
            await Task.Delay(50);
            return _produits.OrderByDescending(p => p.DateAjout);
        }

        public async Task<Produit?> ObtenirProduitParIdAsync(int id)
        {
            await Task.Delay(50);
            return _produits.FirstOrDefault(p => p.Id == id);
        }

        public async Task<Produit> CreerProduitAsync(Produit produit)
        {
            await Task.Delay(50);
            produit.Id = _prochainId++;
            produit.DateAjout = DateTime.Now;

            // Si aucune image n'est fournie, utiliser une image par défaut selon la catégorie
            if (string.IsNullOrEmpty(produit.UrlImage) || produit.UrlImage == "/images/produit-defaut.jpg")
            {
                produit.UrlImage = GetImageParDefautPourCategorie(produit.Categorie);
            }

            _produits.Add(produit);
            return produit;
        }

        public async Task<Produit> ModifierProduitAsync(Produit produit)
        {
            await Task.Delay(50);
            var produitExistant = _produits.FirstOrDefault(p => p.Id == produit.Id);
            if (produitExistant != null)
            {
                produitExistant.Nom = produit.Nom;
                produitExistant.Description = produit.Description;
                produitExistant.Prix = produit.Prix;
                produitExistant.Categorie = produit.Categorie;
                produitExistant.Statut = produit.Statut;
                produitExistant.Stock = produit.Stock;
                produitExistant.Marque = produit.Marque;
                produitExistant.UrlImage = produit.UrlImage;
                return produitExistant;
            }
            throw new ArgumentException("Produit introuvable");
        }

        public async Task<bool> SupprimerProduitAsync(int id)
        {
            await Task.Delay(50);
            var produit = _produits.FirstOrDefault(p => p.Id == id);
            if (produit != null)
            {
                _produits.Remove(produit);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Produit>> RechercherProduitsAsync(string termeRecherche)
        {
            await Task.Delay(50);
            if (string.IsNullOrWhiteSpace(termeRecherche))
                return await ObtenirTousLesProduitsAsync();

            return _produits.Where(p =>
                p.Nom.Contains(termeRecherche, StringComparison.OrdinalIgnoreCase) ||
                p.Description.Contains(termeRecherche, StringComparison.OrdinalIgnoreCase) ||
                p.Marque.Contains(termeRecherche, StringComparison.OrdinalIgnoreCase)
            ).OrderByDescending(p => p.DateAjout);
        }

        public async Task<IEnumerable<Produit>> ObtenirProduitsParCategorieAsync(CategorieProduit categorie)
        {
            await Task.Delay(50);
            return _produits.Where(p => p.Categorie == categorie).OrderByDescending(p => p.DateAjout);
        }

        // Méthode helper pour obtenir une image par défaut selon la catégorie
        private static string GetImageParDefautPourCategorie(CategorieProduit categorie)
        {
            return categorie switch
            {
                CategorieProduit.Telephone => "/images/Téléphone/iphone15pro.jpeg",
                CategorieProduit.OrdinateurPortable => "/images/Ordinateur Portable/macbook-air-m3.jpg",
                CategorieProduit.Tablette => "/images/Tablette/ipad-air-6.jpg",
                CategorieProduit.Accessoire => "/images/Accessoire/airpods-pro-3.jpg",
                CategorieProduit.Gaming => "/images/Gaming/ps5-pro.jpg",
                _ => "/images/produit-defaut.jpg"
            };
        }
    }
}