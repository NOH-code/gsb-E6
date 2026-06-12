# Récapitulatif des modifications — Projet GSB Ordonnances

> Réparation et finalisation du projet WinForms GSB (dossier `GSB/`), en suivant
> le playbook « Projet GSB Ordonnances » tout en conservant la structure, les noms
> de classes et la logique déjà en place dans le projet.

**Date : 11/06/2026 — Résultat : le projet compile (0 erreur) et toutes les
fonctionnalités ont été testées avec succès contre la base MySQL `gsb_ordonnances`.**

---

## 1. État du projet avant intervention

| Élément | État |
|---|---|
| Compilation | OK, mais l'application n'était pas fonctionnelle |
| Base de données | Conforme au playbook (7 tables : PATIENT, MEDECIN, ORDONNANCE, MEDICAMENT, ALLERGIE, CONTENIR, ETRE_ALLERGIQUE) |
| Modèles | Renommés en anglais (`Person`, `Doctor`, `Medoc`, `Prescription`) — sans `Id`, sans `CalculerAge()`, `EstMajeur()`, `Presentation()` |
| Contrôleurs | Un seul : `PatientController` (lecture uniquement) |
| `Connexion` | Aucune authentification : le bouton ouvrait directement la suite |
| `Sign_up` | Validation de saisie seulement, aucune écriture en base, mot de passe en clair |
| `Création_patient` | Handler du bouton « Créer » entièrement vide |
| `Recherche_patient` | Combo patients jamais remplie, fiche jamais alimentée, historique vide |
| `Créateur_d_ordo` | Aucune logique (formulaire dessiné mais 100 % inerte) |
| `PatientListForm` | Chargement OK, mais recherche commentée/inactive |
| `Program.cs` | Démarrait sur `Création_patient` au lieu de la connexion |

### Différences projet ↔ playbook (assumées et conservées)
Le projet a divergé du playbook sur les noms (classes anglaises `Person`/`Doctor`/`Medoc`/
`Prescription` au lieu de `Personne`/`Medecin`/`Medicament`/`LignePrescription`, formulaires
`Connexion`/`Recherche_patient`/`Créateur_d_ordo` au lieu de `LoginForm`/`PatientListForm`/
`OrdonnanceEditForm`) et sur des propriétés supplémentaires (Poids, Taille, Sexe, Pathologie,
Email) absentes de la base. Conformément à la règle « un nom ne change jamais » et à la
consigne de ne pas dénaturer le projet, **tous ces noms ont été conservés** ; les patterns du
playbook (MVC, requêtes paramétrées, triple `using`, transaction, bcrypt, formulaires modaux)
ont été appliqués *à l'intérieur* de cette structure existante.

---

## 2. Modifications apportées

### 2.1 Modèles (`GSB/Models/`)

| Fichier | Modifications |
|---|---|
| `Personne.cs` (classe `Person`) | Ajout de `CalculerAge()` (tient compte du mois/jour, cf. playbook 1.1), `virtual Presentation()` → `"Prenom NOM"`, et `ToString()` → `Presentation()` pour l'affichage direct dans les ComboBox |
| `Patient.cs` | Ajout de `EstMajeur()` (réutilise `CalculerAge`) et `override Presentation()` |
| `Medecin.cs` (classe `Doctor`) | Ajout de `Id` (↔ `numMedecin`), `Specialite`, constructeur vide, `override Presentation()` → `"Dr NOM, Specialite"` |
| `Médicament.cs` (classe `Medoc`) | Ajout de `Id` (↔ `codeMedicament`), `DosageLibelle` (↔ colonne `dosage` texte), constructeur `(nom, dosageLibelle)` aligné sur la table, `Presentation()` → `"Doliprane 500 mg"` |
| `Ordonnance.cs` | Ajout de `Id` (↔ `numOrdonnance`), constructeur métier `Ordonnance(Doctor, Patient)` (liste vide + date = maintenant), méthode `AjouterLigne(Prescription)` (composition, cf. playbook 1.6) |
| `Prescription.cs` | Inchangé (déjà conforme : médicament + posologie + durée) |

### 2.2 Contrôleurs (`GSB/Controllers/`) — namespace `GSB.Ordonnances.Controllers`

| Fichier | Contenu |
|---|---|
| `PatientController.cs` (complété) | Ajout de `AjouterPatient(Patient)` (INSERT paramétré + `LAST_INSERT_ID()` via `ExecuteScalar`), `ModifierPatient(Patient)` (UPDATE avec `WHERE numPatient = @id` + vérification `ExecuteNonQuery() == 1`), `SupprimerPatient(int)` (DELETE paramétré) |
| `AuthController.cs` (**nouveau**) | `Authentifier(rpps, mdpClair)` : récupère le médecin par RPPS (jamais de mot de passe dans le `WHERE`), vérifie via `BCrypt.Verify`. **Compatibilité** : si la base contient encore un mot de passe en clair (jeu de test), la connexion est acceptée et le mot de passe est immédiatement migré vers un hash bcrypt |
| `MedecinController.cs` (**nouveau**) | `ObtenirTousLesMedecins()` (le hash ne sort jamais), `AjouterMedecin(Doctor)` (INSERT + id) |
| `MedicamentController.cs` (**nouveau**) | `ObtenirTousLesMedicaments()` |
| `OrdonnanceController.cs` (**nouveau**) | `AjouterOrdonnance(Ordonnance)` : **transaction** `BeginTransaction`/`Commit`/`Rollback + throw` — INSERT ORDONNANCE puis N INSERT CONTENIR, tout ou rien (playbook ch. 7). `ObtenirOrdonnancesParPatient(int)` (chargement léger avec JOIN MEDECIN), `ObtenirLignesOrdonnance(int)` (détail avec JOIN CONTENIR/MEDICAMENT, playbook 8.2) |

Toutes les requêtes utilisent des **paramètres** (`@motCle`, `@id`…) — aucune concaténation
de saisie utilisateur (OWASP A03), et le pattern **triple `using`** (connexion, commande, reader).

### 2.3 Vues (`GSB/Vue/`)

| Formulaire | Modifications |
|---|---|
| `Connexion` | Authentification réelle via `AuthController` (RPPS + mot de passe), stockage du médecin connecté dans `Session.MedecinConnecte`, messages d'erreur clairs, masquage du mot de passe (`UseSystemPasswordChar`), fermeture propre de l'application quand la fenêtre principale se ferme (plus de processus fantôme) |
| `Sign_up` | Inscription réelle en base : validation (champs, RPPS = 11 caractères, confirmation, date passée), **hachage bcrypt** du mot de passe avant INSERT, gestion du doublon RPPS (erreur 1062 avec `catch … when`). **Designer** : ajout des champs *Date de naissance* (`dateTimePicker_ddn`) et *Spécialité* (`textBox_specialite`) — colonnes NOT NULL de la table MEDECIN absentes du formulaire — et masquage des deux champs mot de passe |
| `Création_patient` | Bouton « Créer » câblé : validation (nom/prénom obligatoires, n° sécu = 13 caractères, date passée), `AjouterPatient`, gestion du doublon n° sécu (1062), retour `DialogResult.OK` au formulaire appelant. Combo sexe alimentée (Homme/Femme) |
| `Recherche_patient` | Devenu le **hub** de l'application : combo remplie avec tous les patients (affichage via `Presentation()`), fiche alimentée à la sélection, **historique des ordonnances** du patient dans la grille (maître-détail, chargement léger), **double-clic sur une ordonnance → détail des lignes**, bouton « Modifier » câblé (UPDATE du patient sélectionné avec validation), bouton « + » patient et « + » ordonnance ouverts en **modal** (`ShowDialog`) avec rafraîchissement si `DialogResult.OK` (motif du playbook ch. 6) |
| `Créateur_d_ordo` | Entièrement câblé : combo des médicaments depuis la base, unités de dose/fréquence/durée, bouton « Valider » (ligne) → ajout à la liste interne + grille récap, bouton « Retirer la ligne », bouton « Valider » (ordonnance) → construction de l'`Ordonnance` (prescripteur = médecin connecté) et enregistrement **transactionnel**. Nouveau constructeur `Créateur_d_ordo(Patient)` (surcharge avec `: this()`, playbook 6.1). La durée est convertie en jours (`dureeJours`), la posologie en texte lisible |
| `PatientListForm` | Recherche branchée sur la version **paramétrée** `ObtenirPatientsParNom` (la version vulnérable commentée a été retirée), factorisation `AfficherPatients(List<Patient>)`, bouton Reset corrigé (appel inutile supprimé), champ renommé `_patientController` (convention playbook) |

### 2.4 Autres fichiers

| Fichier | Modifications |
|---|---|
| `Program.cs` | Démarre sur `Connexion` (authentification obligatoire avant l'accès aux données) |
| `Session.cs` (**nouveau**) | Classe statique gardant le médecin connecté, accessible partout (prescripteur des ordonnances) |
| `GSB.csproj` | Ajout du paquet NuGet `BCrypt.Net-Next` 4.2.0 (hachage des mots de passe, playbook 8.1) |
| `DataAcces/DbConnexion.cs` | Inchangé (déjà conforme au playbook : chaîne `gsb`/`gsbpass`, méthode statique `Ouvrir()`) |

---

## 3. Vérifications effectuées

Compilation : **0 erreur** (subsistent des warnings CS8618 « nullable » sans impact, hérités
du style des modèles). Un harnais de test temporaire (supprimé ensuite) a exécuté chaque
contrôleur contre la base MySQL réelle (port 3306) :

```
[OK] ObtenirTousLesPatients : 22 patients
[OK] ObtenirPatientsParNom("Dup") : 3 patients
[OK] ObtenirTousLesMedecins : 2 medecins (Dr DURAND, Generaliste)
[OK] ObtenirTousLesMedicaments : 3 medicaments (Amoxicilline 1 g)
[OK] Authentifier RPPS 10101010101 / 'secret' : Dr DURAND, Generaliste
[OK] Authentifier refuse un mauvais mot de passe
[OK] Re-authentification apres migration bcrypt
[OK] AjouterOrdonnance (transaction) : ordonnance n°3
[OK] ObtenirOrdonnancesParPatient : 1 -> 2
[OK] ObtenirLignesOrdonnance : 2 lignes
[OK] Nettoyage : ordonnance de test supprimee
[OK] AjouterPatient : id 23  /  [OK] ModifierPatient  /  [OK] SupprimerPatient
[OK] EstMajeur/CalculerAge : patient 1990 -> 36 ans, majeur = True
```

L'ordonnance et le patient de test ont été supprimés : la base est revenue à son état initial,
**à une exception près** : le mot de passe de Dr DURAND a été migré de `'secret'` (clair) vers
un hash bcrypt — c'est le comportement voulu. La connexion avec `secret` fonctionne toujours.

L'exécutable a aussi été lancé : la fenêtre « Se connecter » s'ouvre correctement.

---

## 4. État final — parcours utilisateur

1. **Connexion** : saisir le RPPS (`10101010101`) et le mot de passe (`secret` pour le jeu de
   test) → ouverture de la fiche patient. Bouton « Créer un compte » → inscription d'un médecin
   (mot de passe haché bcrypt).
2. **Recherche_patient** (écran principal) : choisir un patient dans la liste → fiche +
   historique des ordonnances. Double-clic sur une ordonnance → détail des prescriptions.
   « + » (haut) → création de patient ; « Modifier » → mise à jour du patient ;
   « + » (historique) → nouvelle ordonnance.
3. **Créateur_d_ordo** : choisir médicament/dose/fréquence/durée, « Valider » pour chaque
   ligne, puis « Valider » en bas → enregistrement transactionnel (ordonnance + lignes,
   tout ou rien), signé par le médecin connecté.

### Limites connues (choix assumés, sans impact sur le fonctionnement)
- **Poids, taille, sexe, pathologie** (Création_patient) et **email** (Sign_up) sont saisis
  mais **non persistés** : la base du playbook ne possède pas ces colonnes. Les champs ont été
  conservés pour ne pas dénaturer les formulaires.
- `PatientListForm` est réparé et fonctionnel mais n'est ouvert par aucun écran du parcours
  actuel (le projet a retenu `Recherche_patient` comme écran principal). Pour l'essayer :
  `Application.Run(new GSB.Vue.PatientListForm())` dans `Program.cs`.
- Les allergies (tables ALLERGIE / ETRE_ALLERGIQUE) ne sont pas encore exploitées par
  l'interface — piste d'évolution (recherche nom + allergie du playbook ch. 5.3).
- Dr MARTIN a encore son mot de passe en clair en base ; il sera migré vers bcrypt
  automatiquement à sa première connexion.

### Fichiers créés / modifiés
```
Créés    : GSB/Session.cs, GSB/Controllers/AuthController.cs,
           GSB/Controllers/MedecinController.cs, GSB/Controllers/MedicamentController.cs,
           GSB/Controllers/OrdonnanceController.cs, RECAP-MODIFICATIONS.md
Modifiés : GSB/Program.cs, GSB/GSB.csproj,
           GSB/Models/{Personne,Patient,Medecin,Médicament,Ordonnance}.cs,
           GSB/Controllers/PatientController.cs,
           GSB/Vue/Connexion.cs (+ Designer), GSB/Vue/Sign_up.cs (+ Designer),
           GSB/Vue/Création patient.cs, GSB/Vue/Recherche_patient.cs,
           GSB/Vue/Créateur d'ordo.cs, GSB/Vue/PatientListForm.cs
```
