# 💻 BoutiqueTech - E-Commerce ASP.NET Core MVC

![BoutiqueTech Logo](https://img.shields.io/badge/BoutiqueTech-E--Commerce-blue?style=for-the-badge&logo=microsoft)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-8.0-purple?style=for-the-badge&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-11.0-green?style=for-the-badge&logo=csharp)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5.3-purple?style=for-the-badge&logo=bootstrap)
![Docker](https://img.shields.io/badge/Docker-Conteneuris%C3%A9-2496ED?style=for-the-badge&logo=docker&logoColor=white)
![GitHub Actions](https://img.shields.io/badge/CI%2FCD-GitHub%20Actions-2088FF?style=for-the-badge&logo=githubactions&logoColor=white)

[![CI/CD DevSecOps](https://github.com/BAMBA-FALL/BoutiqueTech_C-/actions/workflows/ci.yml/badge.svg)](https://github.com/BAMBA-FALL/BoutiqueTech_C-/actions/workflows/ci.yml)
[![CodeQL](https://github.com/BAMBA-FALL/BoutiqueTech_C-/actions/workflows/codeql.yml/badge.svg)](https://github.com/BAMBA-FALL/BoutiqueTech_C-/actions/workflows/codeql.yml)
[![Ansible](https://github.com/BAMBA-FALL/BoutiqueTech_C-/actions/workflows/ansible.yml/badge.svg)](https://github.com/BAMBA-FALL/BoutiqueTech_C-/actions/workflows/ansible.yml)

## 🛍️ **Titre du Projet**
**"BoutiqueTech - Plateforme E-Commerce pour Produits Technologiques"**

---

## 📋 **Description du Projet**

**BoutiqueTech** est une application web e-commerce moderne développée en **ASP.NET Core MVC** spécialisée dans la vente de produits technologiques. Cette plateforme permet la gestion complète d'un catalogue de produits avec des fonctionnalités CRUD avancées, une interface utilisateur intuitive et des Tag Helpers personnalisés.

Le projet intègre une démarche **DevOps / DevSecOps** : l'application est **conteneurisée avec Docker** (image multi-étapes, exécution non-root) et chaque push déclenche un **pipeline CI/CD GitHub Actions** qui compile le code, audite les dépendances, analyse le code source (**SAST avec CodeQL**), détecte les secrets (**Gitleaks**), scanne l'image Docker (**Trivy**) et vérifie que le conteneur démarre correctement. Le déploiement sur un serveur **Ubuntu** est automatisé avec **Ansible** (durcissement du serveur, Docker, reverse proxy nginx), et le playbook est lui-même testé en CI. La sécurité est ainsi intégrée dès le développement (*shift-left*).

La partie DevOps a été réalisée avec l'assistance de **Claude (Anthropic)**, utilisé comme outil d'ingénierie : analyse des logs du pipeline, écriture des scripts Bash, du playbook Ansible et des workflows CI/CD, et revue de sécurité du code (voir [Développement assisté par IA](#-développement-assisté-par-ia)).

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
| **Ansible** | - | Configuration et déploiement du serveur Ubuntu |
| **nginx** | - | Reverse proxy avec en-têtes de sécurité |
| **Claude (Anthropic)** | - | Assistant IA : analyse de logs, scripts, revue de sécurité |

---

## 📁 **Structure du Projet**

```
BoutiqueTech_C-/
├── 📁 .github/
│   ├── 📁 workflows/
│   │   ├── ci.yml          # Pipeline CI/CD DevSecOps
│   │   ├── codeql.yml      # Analyse statique CodeQL
│   │   └── ansible.yml     # Lint + déploiement de test du playbook
│   └── dependabot.yml      # Mises à jour des dépendances
├── 📁 ansible/
│   ├── deploy.yml          # Playbook principal
│   ├── group_vars/all.yml  # Variables (version, domaine, pare-feu…)
│   ├── inventory.example.ini
│   └── 📁 roles/
│       ├── common/         # Durcissement : UFW, fail2ban, mises à jour auto, SSH
│       ├── docker/         # Docker Engine depuis le dépôt officiel
│       ├── app/            # Build de l'image et lancement du conteneur
│       └── nginx/          # Reverse proxy
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

### 🚀 **Déploiement sur un serveur Ubuntu (Ansible)**
Prérequis : un serveur Ubuntu 22.04 ou 24.04 accessible en SSH avec un utilisateur `sudo`, et Ansible installé sur le poste de déploiement.

```bash
cd ansible
ansible-galaxy collection install -r requirements.yml
cp inventory.example.ini inventory.ini   # renseigner l'IP et l'utilisateur du serveur
ansible-playbook deploy.yml --ask-become-pass
```

Pour déployer une version précise : `ansible-playbook deploy.yml -e app_version=<tag ou SHA>`.

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

### **Déploiement automatisé avec Ansible**

Le playbook `ansible/deploy.yml` prépare un serveur Ubuntu vierge et y déploie l'application :

```
Internet ──► UFW (22, 80) ──► nginx :80 ──► conteneur BoutiqueTech 127.0.0.1:8080
```

| Rôle | Actions |
|------|---------|
| **common** | Mises à jour, fuseau horaire, **UFW** (SSH limité + HTTP), **fail2ban**, mises à jour de sécurité automatiques, durcissement SSH optionnel (`ssh_hardening`) |
| **docker** | Installation de Docker Engine depuis le dépôt officiel, rotation des logs |
| **app** | Clone de la version demandée, build de l'image taguée avec le commit, conteneur sans capabilities Linux (`cap_drop: ALL`, `no-new-privileges`), exposé uniquement en local, vérification de santé |
| **nginx** | Reverse proxy, suppression de la version du serveur, en-têtes de sécurité (`X-Content-Type-Options`, `X-Frame-Options`, `Referrer-Policy`) |

**Le playbook est testé en CI** (workflow `ansible.yml`) :
1. **ansible-lint** avec le profil `production`
2. **Déploiement réel** sur un runner Ubuntu jetable
3. **Test d'idempotence** : un second passage doit se terminer avec `changed=0`
4. **Test de bout en bout** : requête HTTP à travers nginx et contrôle des en-têtes de sécurité

### **Conteneurisation sécurisée**
- **Build multi-étapes** : le SDK .NET n'est présent que dans l'étape de build, l'image finale ne contient que le runtime ASP.NET
- **Utilisateur non-root** : le conteneur s'exécute avec l'utilisateur non privilégié de l'image officielle Microsoft
- **`.dockerignore`** : exclusion des artefacts de build, fichiers IDE et données locales
- **Cache des couches** : restauration NuGet séparée pour accélérer les builds

---

## 🤖 **Développement assisté par IA**

J'utilise **Claude (Anthropic)** comme assistant d'ingénierie DevOps. Je garde la main sur les choix techniques et je valide chaque modification ; Claude accélère l'analyse et l'écriture. Sur ce projet, il a servi à :

| Usage | Exemple concret sur ce projet |
|-------|-------------------------------|
| **Analyse des logs du pipeline** | Diagnostic d'un échec du job Docker (`Unable to resolve action aquasecurity/trivy-action@0.28.0`) : l'action avait changé de schéma de tags. Correction en épinglant l'action sur un SHA de commit, une bonne pratique contre les attaques de la chaîne d'approvisionnement |
| **Écriture de scripts Bash** | Étapes du pipeline : audit des vulnérabilités NuGet qui fait échouer le build sur High/Critical, smoke test qui attend que le conteneur réponde en HTTP |
| **Workflows CI/CD & conteneurisation** | Rédaction des workflows GitHub Actions, du `Dockerfile` multi-étapes non-root et de la configuration Dependabot |
| **Playbook Ansible pour serveurs Linux** | Rédaction des rôles de configuration d'un serveur Ubuntu (durcissement, Docker, nginx) et du workflow qui déploie le playbook sur un runner jetable et vérifie son idempotence |
| **Revue de sécurité du code** | Détection des mots de passe stockés en clair (remplacés par un hachage PBKDF2), d'une protection CSRF manquante et d'artefacts de build versionnés |
| **Débogage du build** | Identification d'un fichier `gitignore` compilé comme du code C#, qui empêchait le projet de compiler depuis un clone propre |

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
✅ **Infrastructure as Code : déploiement Ubuntu automatisé avec Ansible**  
✅ **Utilisation d'un assistant IA (Claude) dans un workflow DevOps**  

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
- ⚙️ Playbook Ansible de déploiement sur Ubuntu (UFW, fail2ban, Docker, nginx), testé en CI

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
