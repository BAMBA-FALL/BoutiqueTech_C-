using Microsoft.AspNetCore.Mvc;
using BoutiqueTech.Models;
using BoutiqueTech.Services;

namespace BoutiqueTech.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService = new UserService();

        // GET: User/Create
        public IActionResult Create() => View();

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserModel user)
        {
            if (!ModelState.IsValid) return View(user);

            _userService.Ajouter(user);
            TempData["MessageSucces"] = "Inscription réussie !";
            return RedirectToAction("Login");
        }

        // GET: User/Login
        public IActionResult Login() => View();

        // POST: User/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string motDePasse)
        {
            if (_userService.Authentifier(email, motDePasse))
            {
                TempData["MessageSucces"] = "Connexion réussie !";
                return RedirectToAction("Index", "Accueil");
            }
            TempData["MessageErreur"] = "Email ou mot de passe incorrect.";
            return View();
        }
    }
}
