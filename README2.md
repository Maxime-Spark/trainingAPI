# Utiliser .NET avec VS Code sur Mac

## 1. Installer .NET SDK

- Rendez-vous sur le [site de téléchargement de .NET](https://dotnet.microsoft.com/download).
- Téléchargez et installez le SDK pour macOS.

## 2. Vérifier l'installation

- Ouvrez le terminal et exécutez :
  ```bash
  dotnet --version
   ```

## 3. Installer VS Code
- Téléchargez Visual Studio Code depuis le site officiel.
- Installez-le en suivant les instructions fournies.

## 4. Installer les extensions nécessaires
- Ouvrez VS Code.
- Accédez à la vue Extensions (ou utilisez le raccourci `Cmd+Shift+X`).
- Recherchez et installez les extensions suivantes :
- - **C#** (par Microsoft) : pour le support de C# et de .NET.
- - **NuGet Package Manager** (optionnel) : pour gérer les packages NuGet.

## 5. Configurer le projet .NET

- Ouvrez le terminal dans VS Code (avec le raccourci `Ctrl+` ``).
- Utilisez les commandes .NET pour créer et gérer des projets. Par exemple :
  ```bash
    dotnet new console -o MyApp
    cd MyApp
    code .
   ```

## 6. Exécuter et déboguer

- Pour exécuter le projet, utilisez la commande : 
  ```bash 
    dotnet run
   ```
- Pour déboguer, configurez le fichier `launch.json` si nécessaire. VS Code devrait automatiquement suggérer la configuration de débogage lorsque vous lancez un débogage pour la première fois.