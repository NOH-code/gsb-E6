using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB.Models
{
    public class Medoc
    {
        // Identifiant, mappé sur la colonne SQL codeMedicament
        public int Id { get; set; }

        // Dosage tel que stocké en base (ex : "500 mg") — colonne SQL dosage
        public string DosageLibelle { get; set; } = "";

        // ATTRIBUTS
        private string name;
        private string unite;
        private double dosage;

        // ACCESSEURS/MUTATEURS
        public string getunite() { return unite; }
        public string getName() { return name; }
        public double getdosage() { return dosage; }

        public void setUnite(string newUnite) { this.unite = newUnite; }
        public void setDosage(double newDosage) { this.dosage = newDosage; }
        public void setName(string newName) { this.name = newName; }

        // CONSTRUCTEURS
        public Medoc() { }

        public Medoc(string name, string unite, double dosage)
        {
            this.name = name;
            this.unite = unite;
            this.dosage = dosage;
        }

        /// <summary>
        /// Constructeur aligné sur la table MEDICAMENT (nom + dosage texte).
        /// </summary>
        public Medoc(string name, string dosageLibelle)
        {
            this.name = name;
            this.DosageLibelle = dosageLibelle;
        }

        // MÉTHODES

        /// <summary>
        /// Présentation du médicament : "Nom Dosage" (ex : "Doliprane 500 mg").
        /// </summary>
        public string Presentation()
        {
            return string.IsNullOrEmpty(DosageLibelle) ? name : $"{name} {DosageLibelle}";
        }

        // Permet l'affichage direct dans les ComboBox / DataGridView
        public override string ToString()
        {
            return Presentation();
        }
    }
}
