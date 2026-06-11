namespace GSB_Ordonnances.Models
{
    /// <summary>
    /// Ligne de prescription : composition d'un Medicament avec une posologie et une durée.
    /// Une ligne n'existe pas sans son médicament.
    /// Table SQL associée : CONTENIR (numOrdonnance, codeMedicament, posologie, dureeJours).
    /// </summary>
    public class LignePrescription
    {
        // --- Champs privés ---
        private Medicament medicament;
        private string posologie;
        private int dureeJours;

        // --- Constructeurs ---

        /// <summary>Constructeur vide : requis par les contrôleurs et le binding.</summary>
        public LignePrescription()
        {
        }

        /// <summary>Constructeur principal.</summary>
        public LignePrescription(Medicament medicament, string posologie, int dureeJours)
        {
            this.medicament = medicament;
            this.posologie = posologie;
            this.dureeJours = dureeJours;
        }

        // --- Getters / setters Java-style ---
        public Medicament getMedicament() { return medicament; }
        public void setMedicament(Medicament value) { medicament = value; }

        public string getPosologie() { return posologie; }
        public void setPosologie(string value) { posologie = value; }

        public int getDureeJours() { return dureeJours; }
        public void setDureeJours(int value) { dureeJours = value; }

        // --- Propriétés C# ---

        public Medicament Medicament
        {
            get { return medicament; }
            set { medicament = value; }
        }

        public string Posologie
        {
            get { return posologie; }
            set { posologie = value; }
        }

        public int DureeJours
        {
            get { return dureeJours; }
            set { dureeJours = value; }
        }

        /// <summary>
        /// Libellé d'affichage du médicament ("Nom dosage") pour la colonne texte de la grille
        /// des lignes (on n'affiche pas l'objet Medicament directement).
        /// </summary>
        public string NomMedicament
        {
            get { return medicament == null ? "" : medicament.Libelle; }
        }
    }
}
