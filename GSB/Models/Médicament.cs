using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB.Models
{
    public class Medoc
    {
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

        // CONSTRUCTEUR
        public Medoc() { }

        public Medoc(string name, string unite, double dosage)
        {
            this.name = name;
            this.unite = unite;
            this.dosage = dosage;
        }
    }
}
