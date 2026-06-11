namespace GSB_Ordonnances.Models
{
    /// <summary>
    /// Medicament : classe simple, sans héritage.
    /// Table SQL associée : MEDICAMENT (codeMedicament, nom, dosage).
    /// </summary>
    public class Medicament
    {
        // --- Champs privés ---
        private int id;
        private string nom;
        private string dosage;

        // --- Constructeurs ---

        /// <summary>Constructeur vide : requis par les contrôleurs et le binding.</summary>
        public Medicament()
        {
        }

        /// <summary>Constructeur principal.</summary>
        public Medicament(string nom, string dosage)
        {
            this.nom = nom;
            this.dosage = dosage;
        }

        // --- Getters / setters Java-style ---
        public int getId() { return id; }
        public void setId(int value) { id = value; }

        public string getNom() { return nom; }
        public void setNom(string value) { nom = value; }

        public string getDosage() { return dosage; }
        public void setDosage(string value) { dosage = value; }

        // --- Propriétés C# ---

        /// <summary>Identifiant, mappé sur la colonne SQL codeMedicament.</summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Dosage
        {
            get { return dosage; }
            set { dosage = value; }
        }

        /// <summary>
        /// Libellé d'affichage "Nom dosage" pour les ComboBox (DisplayMember sur une PROPRIÉTÉ).
        /// </summary>
        public string Libelle
        {
            get { return nom + " " + dosage; }
        }

        public override string ToString()
        {
            return Libelle;
        }
    }
}
