namespace GSB_Ordonnances.Models
{
    /// <summary>
    /// Allergie : classe simple, sans héritage.
    /// Table SQL associée : ALLERGIE (codeAllergie, libelle).
    /// </summary>
    public class Allergie
    {
        // --- Champs privés ---
        private int id;
        private string libelle;

        // --- Constructeurs ---

        /// <summary>Constructeur vide : requis par les contrôleurs et le binding.</summary>
        public Allergie()
        {
        }

        /// <summary>Constructeur principal.</summary>
        public Allergie(string libelle)
        {
            this.libelle = libelle;
        }

        // --- Getters / setters Java-style ---
        public int getId() { return id; }
        public void setId(int value) { id = value; }

        public string getLibelle() { return libelle; }
        public void setLibelle(string value) { libelle = value; }

        // --- Propriétés C# ---

        /// <summary>Identifiant, mappé sur la colonne SQL codeAllergie.</summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Libelle
        {
            get { return libelle; }
            set { libelle = value; }
        }

        public override string ToString()
        {
            return libelle;
        }
    }
}
