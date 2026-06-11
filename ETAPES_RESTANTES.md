# GSB.Ordonnances — Étapes restantes (tuto détaillé)

> Mis à jour le 11/06/2026.
> **Le code de l'application est désormais complet et compile (build vérifié : 0 erreur).**
> Il ne reste que des étapes d'environnement, d'exécution, de tests, et des bonus optionnels.

---

## ✅ Ce qui est fait (tout le code)

| Couche | Fichiers | État |
|---|---|---|
| **Models** | Personne, Patient, Medecin, Medicament, Allergie, LignePrescription, OrdonnanceResume, Ordonnance | ✔ |
| **DataAccess** | DbConnexion.cs | ✔ |
| **Controllers** | Allergie, Medecin (+ Authentifier), Medicament, Patient (CRUD + recherches), Ordonnance (transactionnel) | ✔ |
| **Views** | LoginForm, PatientListForm, PatientDetailForm, PatientEditForm, OrdonnanceEditForm, OrdonnanceListForm (+ leurs `.Designer.cs`) | ✔ |
| **Program.cs** | Login → PatientListForm | ✔ |
| **.csproj** | Form1 retiré, tous les fichiers ajoutés, `MySql.Data` en PackageReference | ✔ |

> ⏱️ **Temps restant estimé : ~1 h 30 à 2 h** (environnement + tests). Les bonus sont en plus.

---

## Étape 1 — Ouvrir dans Visual Studio et restaurer NuGet (10 min)

1. Ouvre `GSB_Ordonnances.slnx` (ou le `.csproj`) dans **Visual Studio**.
2. Visual Studio va **restaurer automatiquement** le paquet `MySql.Data` (déclaré dans le
   `.csproj`). Patiente quelques secondes (icône de restauration en bas).
3. Compile : **`Ctrl+Shift+B`**.

### Si tu vois une erreur « MySql introuvable »
- Clic droit sur la **solution** → **Restore NuGet Packages**.
- Ou : menu **Tools → NuGet Package Manager → Package Manager Console**, tape :
  ```powershell
  Update-Package -reinstall MySql.Data
  ```
- En dernier recours, réinstalle proprement : clic droit projet → **Manage NuGet Packages** →
  onglet **Installed** → MySql.Data → **Update/Reinstall**.

> ℹ️ La version épinglée est `8.0.33` (compatible .NET Framework 4.8). Le build a déjà été
> validé avec cette version.

### Note sur le Designer
Les formulaires n'ont pas de fichier `.resx` (ils n'utilisent aucune ressource image/icône) :
**ils compilent et s'exécutent parfaitement**. Si tu ouvres un formulaire dans le **concepteur
visuel**, Visual Studio peut proposer de créer un `.resx` — accepte, c'est sans conséquence.

---

## Étape 2 — Démarrer la base Docker + corriger les accents (20 min)

### 2.1 — Lancer le conteneur
Ouvre **PowerShell DANS le dossier qui contient `docker-compose.yml`** (⚠ sinon erreur
*« no configuration file provided »*) :
```powershell
cd C:\chemin\vers\le\dossier-docker
docker compose up -d
```
> Si tu n'as pas encore de `docker-compose.yml`, crée-le (playbook ch. 3.4) : service
> `mysql:8.0` (port 3306) + `phpmyadmin:latest` (port 8080), variables
> `MYSQL_DATABASE=gsb_ordonnances`, `MYSQL_USER=gsb`, `MYSQL_PASSWORD=gsbpass`, et monte
> `DataBase/gsb_ordonnances.sql` dans `/docker-entrypoint-initdb.d/`.

### 2.2 — Vérifier
http://localhost:8080 → connexion `gsb` / `gsbpass` → les **7 tables** doivent être présentes
avec le jeu de test.

### 2.3 — Corriger l'encodage des accents
Onglet **SQL** de phpMyAdmin :
```sql
UPDATE MEDECIN  SET specialite = 'Généraliste' WHERE specialite LIKE '%n%raliste';
UPDATE ALLERGIE SET libelle    = 'Pénicilline' WHERE libelle LIKE '%nicilline';
```
> ⚠ Ton fichier SQL contient `GÃ©nÃ©raliste` et `PÃ©nicilline`. Sans cette correction, les
> accents s'affichent corrompus partout dans l'appli (problème de **données**, pas de code).

### Pièges Docker
- *« Unable to connect… »* → conteneur pas lancé → `docker compose up -d`.
- *« Access denied for user 'gsb' »* → identifiants ≠ docker-compose → vérifie `gsb`/`gsbpass`.
- *« Unknown database »* → `docker compose down -v` puis `docker compose up -d` (le `-v` efface
  le volume pour rejouer le script SQL).

---

## Étape 3 — Lancer et tester l'application (45 min)

Appuie sur **`F5`**. La fenêtre de connexion s'ouvre.

> 💡 Pour tester sans login pendant le dev : dans `Program.cs`, commente le bloc `LoginForm` et
> décommente `Application.Run(new PatientListForm());`. **Pense à le remettre avant de rendre.**

### Comptes de test
RPPS **`10101010101`** ou **`20202020202`**, mot de passe **`secret`**.

### Checklist de recette (coche au fur et à mesure)
- [ ] Login `10101010101` / `secret` → accès ; mauvais mot de passe → refus
- [ ] Liste des patients affichée, **sans colonne NomComplet ni Allergies en doublon**
- [ ] Recherche par nom + filtre allergie + bouton Réinitialiser
- [ ] Nouveau patient : nom vide refusé, n° sécu ≠ 13 caractères refusé, date en jj/mm/aaaa
- [ ] Double-clic sur un patient → modification, champs pré-remplis
- [ ] Suppression : confirmation ; patient avec ordonnances → message clair (erreur 1451)
- [ ] « Voir la fiche » → infos + âge + allergies + historique
- [ ] Nouvelle ordonnance : combos lisibles (noms, pas `GSB_Ordonnances.Models…`), ajout/suppression
      de lignes, validations (médecin, patient, ≥ 1 ligne) → enregistrée
- [ ] L'ordonnance apparaît dans l'historique du bon patient
- [ ] Double-clic sur une ordonnance de l'historique → liste maître-détail, lignes lisibles
- [ ] Bouton Fermer fonctionnel partout
- [ ] Accents corrects partout (Généraliste, Pénicilline)

### Si une fenêtre plante au lancement
- 99 % du temps : la **base n'est pas démarrée** ou les **accents/identifiants** sont faux
  (revois l'Étape 2). Le message d'erreur de connexion s'affiche dans une MessageBox.

---

## Étape 4 — Les Flags du playbook (preuves à rendre) (1 h)

Ce sont les **livrables pédagogiques** à présenter au prof. Voici comment produire chacun.

| Flag | Quoi | Comment le réaliser |
|---|---|---|
| **A1** | POO — majorité | Dans un petit `Main` de test (ou un bouton temporaire), crée `new Patient("X","Y", new DateTime(2001,1,1), "...")` (25 ans) et un de 16 ans, puis `Console.WriteLine($"FLAG-A1-{(p25.EstMajeur()?1:0)}{(p16.EstMajeur()?1:0)}")` → **`FLAG-A1-10`**. Rends la valeur. |
| **B1** | MCD | Phrase à rédiger : *« `posologie` est portée par l'association CONTENIR car elle dépend du couple (ordonnance, médicament) : un même médicament a une posologie différente selon l'ordonnance, donc elle ne peut appartenir ni à ORDONNANCE ni à MEDICAMENT seuls. »* |
| **C1** | Base | Dans phpMyAdmin (SQL) : `SELECT COUNT(*) FROM ORDONNANCE o JOIN PATIENT p ON p.numPatient=o.numPatient WHERE p.nom='DUPONT' AND p.prenom='Marie';` → rends le nombre. |
| **C2** | Debug `UPDATE` sans `WHERE` | Phrase : *« Sans `WHERE`, l'`UPDATE` modifie les 10 patients (tous prennent les mêmes valeurs) ; `ExecuteNonQuery()` renvoie **10** au lieu de 1. »* |
| **D1** | OWASP A03 | Sur owasp.org, page *A03:2021 – Injection*, le CWE le plus fréquent est **CWE-89 — Improper Neutralization of Special Elements used in an SQL Command ('SQL Injection')**. |
| **E1** | Rollback | Mets temporairement `throw new Exception("test");` dans la boucle des lignes de `OrdonnanceController.EnregistrerOrdonnance` (après le 1er INSERT CONTENIR). Crée une ordonnance à 2 lignes → erreur. Vérifie dans phpMyAdmin qu'**aucune** ligne n'a été ajoutée (ni ORDONNANCE ni CONTENIR), malgré l'INSERT d'en-tête. Retire le `throw`. Conclus : le `Rollback` annule tout. |
| **E2** | Authentification | Voir le bonus bcrypt ci-dessous. En l'état (mot de passe en clair), montre que `Authentifier("10101010101","secret")` renvoie le médecin et qu'un mauvais mot de passe renvoie `null`. |

---

## Bonus optionnels (non requis pour la version finale, mais valorisants)

Ces points figurent dans le playbook (chapitre 8) mais **pas** dans la checklist « version finale ».
À faire seulement si tu as le temps ou si ton prof les demande.

### B1 — bcrypt pour le Flag E2 « pur » (~30 min)
Ta base stocke `secret` en clair, donc `MedecinController.Authentifier` fait une **comparaison
directe** (un commentaire dans le code l'explique). Pour le vrai bcrypt :
1. NuGet → installe **`BCrypt.Net-Next`**.
2. Génère un hash : `BCrypt.Net.BCrypt.HashPassword("secret")` (commence par `$2a$`).
3. En base : `UPDATE MEDECIN SET motDePasse='$2a$...' WHERE numeroRPPS='10101010101';`
4. Dans `Authentifier`, remplace `if (motDePasseClair != motDePasseStocke)` par
   `if (!BCrypt.Net.BCrypt.Verify(motDePasseClair, motDePasseStocke))`.

### B2 — OrdonnanceDetailForm (~40 min)
Un formulaire en lecture seule affichant une ordonnance complète (en-tête + lignes), ouvert par
double-clic depuis `OrdonnanceListForm`. Le contrôleur a déjà `ObtenirOrdonnance(int)` prêt.
Modèle : calque-toi sur `PatientDetailForm` (labels + une grille de lignes).

### B3 — Modification d'une ordonnance (~40 min)
Le contrôleur a déjà `ModifierOrdonnance(Ordonnance)` (transaction, « efface et réécris »).
Il reste à : ajouter un constructeur `OrdonnanceEditForm(Ordonnance ord)` (mode modif, pré-remplit
combos + lignes) et appeler `ModifierOrdonnance` au lieu de `EnregistrerOrdonnance` quand on est
en mode modif (même logique que `PatientEditForm`).

### B4 — Export PDF (~1 h)
NuGet **`QuestPDF`** + un `Services/OrdonnancePdfService.Generer(Ordonnance, chemin)` (playbook 8.4).

---

## Notes d'implémentation (choix faits, à savoir expliquer à l'oral)

1. **Grille des lignes d'ordonnance** : je n'ai PAS lié `dgvLignes` à une `BindingList` avec
   `DataPropertyName`. La colonne médicament est une `DataGridViewComboBoxColumn` **sans**
   `DataPropertyName` ; à l'enregistrement, on lit les cellules à la main
   (`row.Cells["Medicament"].Value`, etc.). C'est exactement la parade au piège
   **FormatException** décrite dans la marche à suivre (§4.5).
2. **Colonnes techniques masquées** : `PersonnaliserColonnes()` cache `NomComplet` et `Allergies`
   (sinon doublons), et formate les dates en `dd/MM/yyyy`.
3. **Sécurité** (bloc 3) : toutes les requêtes utilisateur sont **paramétrées** ; la méthode
   `RechercherParNom_Vulnerable` est laissée **uniquement** comme contre-exemple OWASP (aucun
   bouton ne l'appelle) ; les `UPDATE`/`DELETE` ont toujours un `WHERE` ; l'ordonnance est écrite
   en **transaction**.
4. **Authentification** : on récupère le médecin par RPPS (jamais le mot de passe dans le `WHERE`),
   puis on compare côté C#.

---

## Récapitulatif des temps restants

| # | Étape | Temps |
|---|---|---|
| 1 | Ouvrir dans VS + restaurer NuGet + compiler | 10 min |
| 2 | Docker + correction des accents | 20 min |
| 3 | Lancer (F5) + recette complète | 45 min |
| 4 | Produire les Flags A1→E2 | 1 h |
| | **TOTAL (obligatoire)** | **~2 h 15** |
| B1–B4 | Bonus (bcrypt, détail, modif ordo, PDF) | +2 h 30 si tout fait |

---

## Ordre conseillé
1. **Étape 1 → 2** : que ça compile et que la base tourne (~30 min).
2. **Étape 3** : F5, login en bypass d'abord, déroule la checklist écran par écran.
3. Remets le login, refais un tour complet propre.
4. **Étape 4** : produis les preuves (Flags).
5. Bonus si le temps le permet.
