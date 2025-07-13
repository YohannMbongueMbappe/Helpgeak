Documentation Technique – PPE2 : Application WindowsFormsAPP
================================================

Projet PPE2 – Application de gestion 
-----------------------------------------
Application développée en C# (.NET Windows Forms) pour gérer les interventions,
les clients, les utilisateurs et le matériel d'une entreprise.

Objectifs :
-----------
- Gérer les utilisateurs et leurs connexions sécurisées
- Suivre les clients et le matériel qu'ils possèdent
- Gérer les interventions techniques associées aux produits installés
- Centraliser les données dans une base SQL Server nommée 'MJV'

Technologies utilisées :
-------------------------
- C# (.NET Framework)
- Windows Forms
- SQL Server Express
- ADO.NET
- Visual Studio

Structure du projet :
----------------------
- .sln : Fichier de solution Visual Studio
- App.config : Configuration de la chaîne de connexion à SQL Server
- MJV.sql : Script de création de la base de données
- Formulaires principaux :
    - FormLogin.cs : Connexion utilisateur
    - FormClient.cs : Gestion des clients
    - FormProduit.cs : Matériel des clients
    - FormIntervention.cs : Suivi des interventions

Base de données – MJV :
------------------------
1. LOGIN
   - ID_USER (PK)
   - Nom
   - Password

2. CLIENT
   - ID_CLIENT (PK)
   - Nom
   - Mail
   - Tel
   - Adresse

3. MARQUE
   - ID_MARQUE (PK)
   - Nom

4. PRODUIT
   - ID_PROD (PK)
   - Nom
   - Description
   - Date_Installation
   - Code
   - MTBF
   - ID_MARQUE (FK → MARQUE)
   - ID_CLIENT (FK → CLIENT)

5. INTERVENTION
   - ID_INTER (PK)
   - DateInter
   - Commentaire
   - Prix
   - ID_PROD (FK → PRODUIT)

Relations :
-----------
- CLIENT 1 → N PRODUIT
- MARQUE 1 → N PRODUIT
- PRODUIT 1 → N INTERVENTION
- LOGIN utilisé pour connexion (pas de relation directe)

Identifiant de connexion
----------------------
-Login:Yohann
-Mot de passe :Mbappe

Connexion à la base :
----------------------
- SQL Server Express
- Utilisation de la chaîne de connexion dans App.config :
  Data Source=.;Initial Catalog=MJV;Integrated Security=True
- Connexion via SqlConnection et ADO.NET

Dépannage :
-----------
- Vérifier que la base 'MJV' est bien créée et accessible
- Vérifier que App.config correspond à l'instance locale SQL Server
- Vérifier les droits de l’utilisateur Windows si Integrated Security est utilisé

Conclusion :
------------
Le projet MJV est une application de gestion conforme au référentiel BTS SIO SLAM, 
avec interface Windows Forms et base SQL Server. Il couvre les aspects client, produit, intervention et sécurité.
