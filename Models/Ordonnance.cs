using System;
using System.Collections.Generic;

namespace GSB_Ordonnances.Models
{
    /// <summary>
    /// Ordonnance : relie un médecin (prescripteur) et un patient, et possède une liste
    /// de lignes de prescription (composition).
    /// Table SQL associée : ORDONNANCE (numOrdonnance, dateEmission, numMedecin, numPatient).
    /// </summary>
    public class Ordonnance
    {
        // --- Champs privés ---
        private int id;
        private DateTime dateEmission;
        private Medecin prescripteur;
        private Patient patient;
        private List<LignePrescription> lignes;

        // --- Constructeurs ---

        /// <summary>Constructeur vide : requis par les contrôleurs et le binding. Initialise la liste.</summary>
        public Ordonnance()
        {
            lignes = new List<LignePrescription>();
            dateEmission = DateTime.Now;
        }

        /// <summary>Constructeur principal : liste vide et DateEmission = maintenant.</summary>
        public Ordonnance(Medecin prescripteur, Patient patient)
        {
            this.prescripteur = prescripteur;
            this.patient = patient;
            this.lignes = new List<LignePrescription>();
            this.dateEmission = DateTime.Now;
        }

        // --- Getters / setters Java-style ---
        public int getId() { return id; }
        public void setId(int value) { id = value; }

        public DateTime getDateEmission() { return dateEmission; }
        public void setDateEmission(DateTime value) { dateEmission = value; }

        public Medecin getPrescripteur() { return prescripteur; }
        public void setPrescripteur(Medecin value) { prescripteur = value; }

        public Patient getPatient() { return patient; }
        public void setPatient(Patient value) { patient = value; }

        public List<LignePrescription> getLignes() { return lignes; }
        public void setLignes(List<LignePrescription> value) { lignes = value; }

        // --- Propriétés C# ---

        /// <summary>Identifiant, mappé sur la colonne SQL numOrdonnance.</summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime DateEmission
        {
            get { return dateEmission; }
            set { dateEmission = value; }
        }

        public Medecin Prescripteur
        {
            get { return prescripteur; }
            set { prescripteur = value; }
        }

        public Patient Patient
        {
            get { return patient; }
            set { patient = value; }
        }

        /// <summary>Lignes de prescription. En lecture seule de l'extérieur (on passe par AjouterLigne).</summary>
        public List<LignePrescription> Lignes
        {
            get { return lignes; }
        }

        // --- Comportement ---

        /// <summary>Ajoute une ligne à la liste interne.</summary>
        public void AjouterLigne(LignePrescription ligne)
        {
            if (lignes == null)
            {
                lignes = new List<LignePrescription>();
            }
            lignes.Add(ligne);
        }
    }
}
