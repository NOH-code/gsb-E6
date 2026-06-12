using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB.Models
{
    public class Patient : Person
    {
        // PROPRIÉTÉS C# (Auto-Properties)
        public int Id { get; set; }
        public double Poids { get; set; }
        public double Taille { get; set; }
        public bool Sexe { get; set; }          // true = Homme, false = Femme
        public string Pathologie { get; set; } = "";
        public string NumeroSecu { get; set; } = "";

        // Libellé du sexe pour l'affichage (dérivé du booléen Sexe)
        public string SexeLibelle => Sexe ? "Homme" : "Femme";

        // CONSTRUCTEURS

        // 1. Constructeur vide
        public Patient() : base() { }

        // 2. Constructeur requis par PatientController (ajoute la compatibilité avec la BDD)
        public Patient(string name, string firstname, DateTime birthdate, string numeroSecu)
            : base(name, firstname, birthdate)
        {
            this.NumeroSecu = numeroSecu;
        }

        // 3. Constructeur complet
        public Patient(double poids, double taille, bool sexe, string pathologie, string numeroSecu, string name, string firstname, DateTime birthdate)
            : base(name, firstname, birthdate)
        {
            // CORRECTION : Utilisation de la majuscule pour cibler les propriétés
            this.Poids = poids;
            this.Taille = taille;
            this.Sexe = sexe;
            this.Pathologie = pathologie;
            this.NumeroSecu = numeroSecu;
        }

        // MÉTHODES

        /// <summary>
        /// true à partir de 18 ans (réutilise CalculerAge de Person).
        /// </summary>
        public bool EstMajeur()
        {
            return CalculerAge() >= 18;
        }

        /// <summary>
        /// Présentation adaptée au patient : "Prenom NOM".
        /// </summary>
        public override string Presentation()
        {
            return $"{Firstname} {Name?.ToUpper()}";
        }
    }
}