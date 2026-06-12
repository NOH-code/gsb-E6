using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB.Models
{
    public class Ordonnance
    {
        // Identifiant, mappé sur la colonne SQL numOrdonnance
        public int Id { get; set; }

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

        /// <summary>
        /// Constructeur "métier" : relie un médecin et un patient,
        /// initialise une liste de lignes vide et la date à maintenant.
        /// </summary>
        public Ordonnance(Doctor medecin, Patient patient)
        {
            this.medecin = medecin;
            this.patient = patient;
            this.prescriptions = new List<Prescription>();
            this.dateOrdonnance = DateTime.Now;
        }

        // MÉTHODES

        /// <summary>
        /// Ajoute une ligne de prescription à la liste interne (composition).
        /// </summary>
        public void AjouterLigne(Prescription ligne)
        {
            if (prescriptions == null)
            {
                prescriptions = new List<Prescription>();
            }
            prescriptions.Add(ligne);
        }


    }
}