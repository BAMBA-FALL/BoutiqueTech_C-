# 💻 BoutiqueTech - E-Commerce ASP.NET Core MVC

![BoutiqueTech Logo](https://img.shields.io/badge/BoutiqueTech-E--Commerce-blue?style=for-the-badge&logo=microsoft)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-8.0-purple?style=for-the-badge&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-11.0-green?style=for-the-badge&logo=csharp)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5.3-purple?style=for-the-badge&logo=bootstrap)
![Docker](https://img.shields.io/badge/Docker-Conteneuris%C3%A9-2496ED?style=for-the-badge&logo=docker&logoColor=white)
![GitHub Actions](https://img.shields.io/badge/CI%2FCD-GitHub%20Actions-2088FF?style=for-the-badge&logo=githubactions&logoColor=white)

[![CI/CD DevSecOps](https://github.com/BAMBA-FALL/BoutiqueTech_C-/actions/workflows/ci.yml/badge.svg)](https://github.com/BAMBA-FALL/BoutiqueTech_C-/actions/workflows/ci.yml)
[![CodeQL](https://github.com/BAMBA-FALL/BoutiqueTech_C-/actions/workflows/codeql.yml/badge.svg)](https://github.com/BAMBA-FALL/BoutiqueTech_C-/actions/workflows/codeql.yml)

## 🛍️ **Titre du Projet**
**"BoutiqueTech - Plateforme E-Commerce pour Produits Technologiques"**

---

## 📋 **Description du Projet**

**BoutiqueTech** est une application web e-commerce moderne développée en **ASP.NET Core MVC** spécialisée dans la vente de produits technologiques. Cette plateforme permet la gestion complète d'un catalogue de produits avec des fonctionnalités CRUD avancées, une interface utilisateur intuitive et des Tag Helpers personnalisés.

Le projet intègre une démarche **DevOps / DevSecOps** : l'application est **conteneurisée avec Docker** (image multi-étapes, exécution non-root) et chaque push déclenche un **pipeline CI/CD GitHub Actions** qui compile le code, audite les dépendances, analyse le code source (**SAST avec CodeQL**), détecte les secrets (**Gitleaks**), scanne l'image Docker (**Trivy**) et vérifie que le conteneur démarre correctement. La sécurité est ainsi intégrée dès le développement (*shift-left*).

### 🎯 **Objectif du Projet**
Ce projet démontre la maîtrise des technologies **ASP.NET Core MVC**, **C#** et **Razor**, ainsi que l'application des bonnes pratiques de développement web : architecture MVC, injection de dépendances, validation des données et composants réutilisables — tout en appliquant une chaîne d'intégration continue sécurisée, de la compilation jusqu'à l'image Docker prête à déployer.

---

## ✨ **Fonctionnalités Principales**

### 🔧 **CRUD Complet**
- ✅ **Création** de nouveaux produits avec validation
- ✅ **Lecture** et affichage du catalogue complet
- ✅ **Modification** des produits existants
- ✅ **Suppression** avec confirmation obligatoire

### 🔍 **Recherche et Filtrage**
- **Recherche textuelle** par nom, description ou marque
- **Filtrage par catégorie** (Téléphone, Ordinateur, Tablette, etc.)
- **Combinaison** recherche + filtre

### 🏷️ **Tag Helpers Personnalisés**
- `<carte-produit>` : Affichage des cartes produits
- `<statut-produit>` : Badges de statut colorés
- `<affichage-prix>` : Formatage des prix en euros
- `<indicateur-stock>` : Indicateurs visuels de stock
- `<resume-statut>` : Statistiques du catalogue

### 📊 **Types de Données Variés**
- **String** : Nom, Description, Marque
- **Decimal** : Prix avec validation
- **Int** : Stock, ID
- **DateTime** : Date d'ajout automatique
- **Enum** : Catégories et Statuts
- **URL** : Images des produits

---

## 🛠️ **Technologies Utilisées**

| Technologie | Version | Usage |
|-------------|---------|-------|
| **ASP.NET Core** | 8.0 | Framework principal |
| **C#** | 11.0 | Langage de programmation |
| **Razor** | - | Moteur de templates |
| **Bootstrap** | 5.3 | Framework CSS |
| **Font Awesome** | 6.0 | Icônes |
| **jQuery** | 3.6 | Interactions JavaScript |
| **Visual Studio** | 2022 | IDE de développement |
| **Docker** | - | Conteneurisation (build multi-étapes) |
| **GitHub Actions** | - | Pipeline CI/CD |
| **CodeQL** | - | Analyse statique de sécurité (SAST) |
| **Trivy** | - | Scan de vulnérabilités de l'image |
| **Gitleaks** | - | Détection de secrets dans l'historique Git |
| **Dependabot** | - | Mises à jour automatiques des dépendances |

---

## 📁 **Structure du Projet**

```
BoutiqueTech_C-/
├── 📁 .github/
│   ├── 📁 workflows/
│   │   ├── ci.yml          # Pipeline CI/CD DevSecOps
│   │   └── codeql.yml      # Analyse statique CodeQL
│   └── dependabot.yml      # Mises à jour des dépendances
├── Dockerfile              # Image multi-étapes, non-root
├── .dockerignore
└── 📁 BoutiqueTech/
    ├── 📁 Controllers/
    │   ├── AccueilController.cs
    │   └── ProduitsController.cs
    ├── 📁 Models/
    │   └── Produit.cs (Enums inclus)
    ├── 📁 Services/
    │   ├── IServiceProduit.cs
    │   └── ServiceProduit.cs
    ├── 📁 TagHelpers/
    │   ├── CarteProduitTagHelper.cs
    │   ├── StatutProduitTagHelper.cs
    │   ├── AffichagePrixTagHelper.cs
    │   ├── IndicateurStockTagHelper.cs
    │   └── ResumeStatutTagHelper.cs
    ├── 📁 Views/
    │   ├── 📁 Shared/
    │   │   ├── _Layout.cshtml
    │   │   └── Error.cshtml
    │   ├── 📁 Accueil/
    │   │   ├── Index.cshtml
    │   │   └── ViePrive.cshtml
    │   └── 📁 Produits/
    │       ├── Index.cshtml
    │       ├── Details.cshtml
    │       ├── Creer.cshtml
    │       ├── Modifier.cshtml
    │       └── Supprimer.cshtml
    └── 📁 wwwroot/
        ├── 📁 css/
        ├── 📁 js/
        └── 📁 images/
```

---

## 🚀 **Installation et Utilisation**

### **Prérequis**
- Visual Studio 2022
- .NET 8.0 SDK
- Navigateur web moderne

### **Étapes d'Installation**
1. **Cloner le repository**
   ```bash
   git clone https://github.com/BAMBA-FALL/BoutiqueTech_C-.git
   cd BoutiqueTech_C-
   ```

2. **Ouvrir dans Visual Studio 2022**
   ```bash
   start BoutiqueTech.sln
   ```

3. **Restaurer les packages NuGet**
   ```bash
   dotnet restore
   ```

4. **Lancer l'application**
   ```bash
   dotnet run
   ```

5. **Accéder à l'application**
   ```
   https://localhost:7096
   ```

### 🐳 **Lancement avec Docker**
```bash
docker build -t boutiquetech .
docker run -d -p 8080:8080 --name boutiquetech boutiquetech
```
L'application est alors accessible sur `http://localhost:8080`.

---

## 📸 **Captures d'Écran**

### 🏠 **Page d'Accueil**
- Hero section avec gradient moderne
- Produits vedettes en cartes
- Statistiques du catalogue
- Navigation intuitive

### 🛍️ **Catalogue Produits**
- Liste complète avec pagination visuelle
- Barre de recherche fonctionnelle
- Filtres par catégorie
- Actions CRUD sur chaque produit

### ➕ **Formulaires**
- Interface de création propre
- Validation côté client et serveur
- Messages d'erreur contextuels
- Confirmation de suppression

---

## 🔄 **DevOps & DevSecOps**

### **Pipeline CI/CD (GitHub Actions)**
Déclenché à chaque `push` et `pull request` sur `main` :

```
┌──────────────────┐   ┌──────────────────────┐   ┌───────────────────────┐
│ Gitleaks         │   │ Build .NET (Release) │   │ CodeQL (SAST)         │
│ secrets dans Git │   │ + audit NuGet (SCA)  │   │ analyse du code C#    │
└────────┬─────────┘   └──────────┬───────────┘   └───────────────────────┘
         └────────────┬───────────┘
                      ▼
         ┌──────────────────────────┐
         │ Build de l'image Docker  │
         │ → Scan Trivy (HIGH/CRIT) │
         │ → Smoke test du conteneur│
         └──────────────────────────┘
```

| Étape | Outil | Rôle |
|-------|-------|------|
| **Détection de secrets** | Gitleaks | Bloque le pipeline si un mot de passe, token ou clé est présent dans l'historique Git |
| **Build** | .NET 8 SDK | Compilation en configuration Release |
| **SCA** | `dotnet list package --vulnerable` | Échec si une dépendance NuGet a une vulnérabilité High/Critical |
| **SAST** | CodeQL | Analyse statique du code C# (injections, XSS, mauvaises pratiques) + exécution hebdomadaire |
| **Scan d'image** | Trivy | Échec si l'image Docker contient une vulnérabilité HIGH/CRITICAL corrigeable |
| **Smoke test** | Docker + curl | Vérifie que le conteneur démarre et répond en HTTP |
| **Mises à jour** | Dependabot | Pull requests hebdomadaires pour NuGet, Docker et GitHub Actions |

### **Conteneurisation sécurisée**
- **Build multi-étapes** : le SDK .NET n'est présent que dans l'étape de build, l'image finale ne contient que le runtime ASP.NET
- **Utilisateur non-root** : le conteneur s'exécute avec l'utilisateur non privilégié de l'image officielle Microsoft
- **`.dockerignore`** : exclusion des artefacts de build, fichiers IDE et données locales
- **Cache des couches** : restauration NuGet séparée pour accélérer les builds

---

## 🎨 **Caractéristiques Techniques**

### **Architecture MVC**
- **Modèles** : Entités métier avec validation
- **Vues** : Interface utilisateur responsive
- **Contrôleurs** : Logique de traitement

### **Stockage en Mémoire**
- Aucune base de données requise
- Données persistantes pendant la session
- 6 produits d'exemple préchargés

### **Tag Helpers Personnalisés**
- Réutilisabilité du code d'affichage
- Encapsulation de la logique de présentation
- Facilité de maintenance

### **Interface Responsive**
- Compatible mobile, tablette et desktop
- Bootstrap 5.3 avec personnalisations
- Animations CSS fluides

---

## 👤 **Auteur**

| Rôle | Nom | Contribution |
|------|-----|-------------|
| **Développeur Full-Stack .NET** | Khadim Mbacké FALL | Architecture, CRUD, Tag Helpers, Interface, Validation, Tests, Documentation |

---

## 📊 **Spécifications Fonctionnelles**

### **Modèle de Données - Produit**
```csharp
public class Produit
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Description { get; set; }
    public decimal Prix { get; set; }
    public CategorieProduit Categorie { get; set; }
    public StatutProduit Statut { get; set; }
    public DateTime DateAjout { get; set; }
    public int Stock { get; set; }
    public string UrlImage { get; set; }
    public string Marque { get; set; }
}
```

### **Énumérations**
- **CategorieProduit** : Téléphone, OrdinateurPortable, Tablette, Accessoire, Gaming
- **StatutProduit** : EnStock, RuptureStock, PreCommande

---

## 🔍 **Fonctionnalités Avancées**

### **Validation**
- Validation côté serveur avec DataAnnotations
- Validation côté client avec jQuery Unobtrusive
- Messages d'erreur personnalisés en français

### **Sécurité applicative**
- **Mots de passe hachés** avec `PasswordHasher` d'ASP.NET Core Identity (PBKDF2 + sel), jamais stockés en clair
- Protection **CSRF** avec `ValidateAntiForgeryToken` sur les formulaires
- **HTTPS** forcé et en-tête **HSTS** en production
- Validation des entrées utilisateur (DataAnnotations)
- Gestion sécurisée des erreurs
- Aucun secret ni artefact de build versionné (`.gitignore` dédié)

### **UX/UI**
- Messages de confirmation avec TempData
- Animations au survol des éléments
- Indicateurs visuels de statut
- Interface intuitive et accessible

---

## 📈 **Métriques du Projet**

- **Lignes de code** : ~2000+
- **Fichiers** : 25+
- **Tag Helpers** : 5 personnalisés
- **Vues** : 8 complètes
- **Modèles** : 1 avec validation
- **Contrôleurs** : 2 avec actions CRUD
- **Services** : 1 avec interface

---

## 🎯 **Compétences Démontrées**

✅ **Maîtrise d'ASP.NET Core MVC**  
✅ **Utilisation avancée de C# et Razor**  
✅ **Création de Tag Helpers personnalisés**  
✅ **Interface utilisateur moderne avec Bootstrap**  
✅ **Opérations CRUD complètes**  
✅ **Validation des données**  
✅ **Architecture MVC respectée**  
✅ **Documentation technique complète**  
✅ **Conteneurisation Docker sécurisée (multi-étapes, non-root)**  
✅ **Pipeline CI/CD avec GitHub Actions**  
✅ **Intégration de la sécurité dans la CI (SAST, SCA, secrets, scan d'image)**  

---

## 📝 **Notes de Version**

### **Version 1.0.0** (Septembre 2025)
- ✨ Version initiale complète
- ✨ CRUD complet des produits
- ✨ 5 Tag Helpers personnalisés
- ✨ Interface responsive Bootstrap 5.3
- ✨ Recherche et filtrage avancés
- ✨ Validation complète des formulaires

### **Version 1.1.0** (Septembre 2026)
- 🐳 Conteneurisation Docker (multi-étapes, non-root)
- 🔄 Pipeline CI/CD GitHub Actions
- 🔐 CodeQL, Trivy, Gitleaks, audit NuGet et Dependabot
- 🔑 Hachage des mots de passe et protection CSRF sur l'authentification

---

## 📄 **Licence et Utilisation**

Projet personnel réalisé dans le cadre de mon portfolio de développeur .NET. Le code est librement consultable à titre de démonstration.

**© 2025 - Khadim Mbacké FALL**

---

## 📞 **Contact**

Pour toute question concernant ce projet :

- **Email :** contact.bamba.pro@gmail.com
- **GitHub :** [BAMBA-FALL](https://github.com/BAMBA-FALL)
- **Repository :** [BoutiqueTech_C-](https://github.com/BAMBA-FALL/BoutiqueTech_C-)

---

**⭐ N'hésitez pas à donner une étoile à ce repository si ce projet vous intéresse !**
