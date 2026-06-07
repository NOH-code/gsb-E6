using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB.Models
{
    public class Prescription
    {
        // ATTRIBUTS
        private Medoc medicament;
        private string posologie;
        private double durée;

        // ACCESSEURS/MUTATEURS
        public Medoc getMedicament() { return medicament; }
        public string getName() { return posologie; }
        public double getDurée() { return durée; }

        public void setMedicament(Medoc newMedicament) { this.medicament = newMedicament; }
        public void setDurée(double newDurée) { this.durée = newDurée; }
        public void setName(string newName) { this.posologie = newName; }

        // CONSTRUCTEUR
        public Prescription() { }

        public Prescription(Medoc medicament, string posologie, double durée)
        {
            this.medicament = medicament;
            this.posologie = posologie;
            this.durée = durée;
        }
    }
}
