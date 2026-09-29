using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using BoutiqueTech.Models;
using Microsoft.AspNetCore.Identity;

namespace BoutiqueTech.Services
{
    public class UserService
    {
        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "users.json");
        private readonly PasswordHasher<UserModel> _hasher = new PasswordHasher<UserModel>();

        public List<UserModel> ObtenirTous()
        {
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]"); // créer fichier vide si inexistant
            }

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<UserModel>>(json) ?? new List<UserModel>();
        }

        public void Ajouter(UserModel user)
        {
            var utilisateurs = ObtenirTous();
            // Le mot de passe n'est jamais stocké en clair (hachage PBKDF2 avec sel)
            user.MotDePasse = _hasher.HashPassword(user, user.MotDePasse);
            utilisateurs.Add(user);
            File.WriteAllText(_filePath, JsonSerializer.Serialize(utilisateurs, new JsonSerializerOptions { WriteIndented = true }));
        }

        // 🔹 Nouvelle méthode pour l'authentification
        public bool Authentifier(string email, string motDePasse)
        {
            var utilisateur = ObtenirTous().FirstOrDefault(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            if (utilisateur == null) return false;

            return _hasher.VerifyHashedPassword(utilisateur, utilisateur.MotDePasse, motDePasse)
                != PasswordVerificationResult.Failed;
        }
    }
}
