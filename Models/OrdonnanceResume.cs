using System;

namespace GSB_Ordonnances.Models
{
    /// <summary>
    /// Vue allégée d'une ordonnance pour les listes/historiques (chargement léger,
    /// SANS les lignes de prescription). On ne charge les lignes que dans le détail.
    /// Alimentée par un JOIN ORDONNANCE / MEDECIN / PATIENT.
    /// </summary>
    public class OrdonnanceResume
    {
        // --- Champs privés ---
        private int id;
        private DateTime dateEmission;
        private string nomMedecin;
        private string nomPatient;

        // --- Constructeurs ---

        /// <summary>Constructeur vide : requis par les contrôleurs et le binding.</summary>
        public OrdonnanceResume()
        {
        }

        public OrdonnanceResume(int id, DateTime dateEmission, string nomMedecin, string nomPatient)
        {
            this.id = id;
            this.dateEmission = dateEmission;
            this.nomMedecin = nomMedecin;
            this.nomPatient = nomPatient;
        }

        // --- Getters / setters Java-style ---
        public int getId() { return id; }
        public void setId(int value) { id = value; }

        public DateTime getDateEmission() { return dateEmission; }
        public void setDateEmission(DateTime value) { dateEmission = value; }

        public string getNomMedecin() { return nomMedecin; }
        public void setNomMedecin(string value) { nomMedecin = value; }

        public string getNomPatient() { return nomPatient; }
        public void setNomPatient(string value) { nomPatient = value; }

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

        public string NomMedecin
        {
            get { return nomMedecin; }
            set { nomMedecin = value; }
        }

        public string NomPatient
        {
            get { return nomPatient; }
            set { nomPatient = value; }
        }
    }
}
