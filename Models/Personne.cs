using System;

namespace GSB_Ordonnances.Models
{
    /// <summary>
    /// Classe abstraite factorisant ce qui est commun à un Patient et à un Medecin
    /// (nom, prénom, date de naissance). Le monde relationnel n'a pas d'héritage :
    /// PATIENT et MEDECIN dupliquent ces colonnes, mais en POO on factorise ici.
    /// </summary>
    public abstract class Personne
    {
        // --- Champs privés ---
        private int id;
        private string nom;
        private string prenom;
        private DateTime dateNaissance;

        // --- Constructeurs ---

        /// <summary>Constructeur vide : requis par les contrôleurs (new + setters) et le binding WinForms.</summary>
        public Personne()
        {
        }

        /// <summary>Constructeur principal : initialise les trois propriétés communes.</summary>
        public Personne(string nom, string prenom, DateTime dateNaissance)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.dateNaissance = dateNaissance;
        }

        // --- Getters / setters Java-style (exigence du prof) ---
        public int getId() { return id; }
        public void setId(int value) { id = value; }

        public string getNom() { return nom; }
        public void setNom(string value) { nom = value; }

        public string getPrenom() { return prenom; }
        public void setPrenom(string value) { prenom = value; }

        public DateTime getDateNaissance() { return dateNaissance; }
        public void setDateNaissance(DateTime value) { dateNaissance = value; }

        // --- Propriétés C# (exigence du DataGridView et du binding) ---

        /// <summary>Identifiant, mappé sur la PK SQL (numPatient / numMedecin) dans le contrôleur.</summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        public DateTime DateNaissance
        {
            get { return dateNaissance; }
            set { dateNaissance = value; }
        }

        /// <summary>
        /// Propriété d'affichage pour les ComboBox : le DisplayMember ne fonctionne
        /// qu'avec une PROPRIÉTÉ, jamais avec une méthode comme Presentation().
        /// </summary>
        public string NomComplet
        {
            get { return prenom + " " + (nom == null ? "" : nom.ToUpper()); }
        }

        // --- Comportement ---

        /// <summary>
        /// Retourne l'âge en années à partir de la date de naissance, en tenant
        /// compte du mois et du jour (pas seulement de l'année).
        /// </summary>
        public int CalculerAge()
        {
            DateTime aujourdhui = DateTime.Today;
            int age = aujourdhui.Year - dateNaissance.Year;
            if (dateNaissance.Date > aujourdhui.AddYears(-age))
            {
                age--;
            }
            return age;
        }

        /// <summary>Présentation textuelle, redéfinie par les classes filles.</summary>
        public virtual string Presentation()
        {
            return prenom + " " + (nom == null ? "" : nom.ToUpper());
        }

        public override string ToString()
        {
            return Presentation();
        }
    }
}
