using System;
using System.Collections.Generic;

namespace GSB_Ordonnances.Models
{
    /// <summary>
    /// Patient : hérite de Personne et ajoute le numéro de sécurité sociale.
    /// Table SQL associée : PATIENT (numPatient, nom, prenom, dateNaissance, numeroSecu).
    /// </summary>
    public class Patient : Personne
    {
        // --- Champs privés ---
        private string numeroSecu;
        private List<Allergie> allergies;

        // --- Constructeurs ---

        /// <summary>Constructeur vide : requis par les contrôleurs et le binding.</summary>
        public Patient()
        {
            allergies = new List<Allergie>();
        }

        /// <summary>Constructeur principal : appelle base(...) puis initialise NumeroSecu.</summary>
        public Patient(string nom, string prenom, DateTime dateNaissance, string numeroSecu)
            : base(nom, prenom, dateNaissance)
        {
            this.numeroSecu = numeroSecu;
            this.allergies = new List<Allergie>();
        }

        // --- Getters / setters Java-style ---
        public string getNumeroSecu() { return numeroSecu; }
        public void setNumeroSecu(string value) { numeroSecu = value; }

        public List<Allergie> getAllergies() { return allergies; }
        public void setAllergies(List<Allergie> value) { allergies = value; }

        // --- Propriétés C# ---

        /// <summary>Numéro de sécurité sociale (13 caractères dans ce projet).</summary>
        public string NumeroSecu
        {
            get { return numeroSecu; }
            set { numeroSecu = value; }
        }

        /// <summary>Allergies connues du patient (chargées via ETRE_ALLERGIQUE / ALLERGIE).</summary>
        public List<Allergie> Allergies
        {
            get { return allergies; }
            set { allergies = value; }
        }

        // --- Comportement ---

        /// <summary>true à partir de 18 ans (réutilise CalculerAge).</summary>
        public bool EstMajeur()
        {
            return CalculerAge() >= 18;
        }

        public override string Presentation()
        {
            return Prenom + " " + (Nom == null ? "" : Nom.ToUpper());
        }
    }
}
