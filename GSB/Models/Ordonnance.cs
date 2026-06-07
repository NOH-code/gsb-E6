using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB.Models
{
    public class Ordonnance
    {
        // ATTRIBUTS
        private Doctor medecin;
        private Patient patient;
        private List<Prescription> prescriptions; 
        private DateTime dateOrdonnance;
       

        // ACCESSEURS (Getters)
        public Doctor getMedecin() { return medecin; }
        public Patient getPatient() { return patient; }
        public List<Prescription> getPrescriptions() { return prescriptions; }
        public DateTime getDateOrdonnance() { return dateOrdonnance; }

        // MUTATEURS (Setters)
        public void setMedecin(Doctor newMedecin) { this.medecin = newMedecin; }
        public void setPatient(Patient newPatient) { this.patient = newPatient; }
        public void setPrescriptions(List<Prescription> newPrescriptions) { this.prescriptions = newPrescriptions; }
        public void setDateOrdonnance(DateTime newDate) { this.dateOrdonnance = newDate; }

        // CONSTRUCTEUR
        public Ordonnance() { }

        public Ordonnance(Doctor medecin, List<Prescription> prescriptions, Patient patient, DateTime dateOrdonnance)
        {
            this.medecin = medecin;
            this.prescriptions = prescriptions;
            this.patient = patient;
            this.dateOrdonnance = dateOrdonnance;
        }


    }
}