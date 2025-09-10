using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using BoutiqueTech.Models;

namespace BoutiqueTech.Services
{
    public class UserService
    {
        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "users.json");

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
            utilisateurs.Add(user);
            File.WriteAllText(_filePath, JsonSerializer.Serialize(utilisateurs, new JsonSerializerOptions { WriteIndented = true }));
        }

        // 🔹 Nouvelle méthode pour l'authentification
        public bool Authentifier(string email, string motDePasse)
        {
            var utilisateurs = ObtenirTous();
            return utilisateurs.Any(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                u.MotDePasse == motDePasse
            );
        }
    }
}
