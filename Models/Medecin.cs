using System;

namespace GSB_Ordonnances.Models
{
    /// <summary>
    /// Medecin : hérite de Personne et ajoute RPPS, spécialité et mot de passe (haché).
    /// Table SQL associée : MEDECIN (numMedecin, nom, prenom, dateNaissance,
    /// numeroRPPS, specialite, motDePasse).
    /// </summary>
    public class Medecin : Personne
    {
        // --- Champs privés ---
        private string numeroRPPS;
        private string specialite;
        private string motDePasse;

        // --- Constructeurs ---

        /// <summary>Constructeur vide : requis par les contrôleurs et le binding.</summary>
        public Medecin()
        {
        }

        /// <summary>Constructeur principal : appelle base(...) puis initialise le reste.</summary>
        public Medecin(string nom, string prenom, DateTime dateNaissance,
                       string numeroRPPS, string specialite, string motDePasse)
            : base(nom, prenom, dateNaissance)
        {
            this.numeroRPPS = numeroRPPS;
            this.specialite = specialite;
            this.motDePasse = motDePasse;
        }

        // --- Getters / setters Java-style ---
        public string getNumeroRPPS() { return numeroRPPS; }
        public void setNumeroRPPS(string value) { numeroRPPS = value; }

        public string getSpecialite() { return specialite; }
        public void setSpecialite(string value) { specialite = value; }

        public string getMotDePasse() { return motDePasse; }
        public void setMotDePasse(string value) { motDePasse = value; }

        // --- Propriétés C# ---

        /// <summary>Identifiant ordinal du médecin (11 caractères).</summary>
        public string NumeroRPPS
        {
            get { return numeroRPPS; }
            set { numeroRPPS = value; }
        }

        public string Specialite
        {
            get { return specialite; }
            set { specialite = value; }
        }

        /// <summary>Stocke un hash bcrypt, jamais un mot de passe en clair.</summary>
        public string MotDePasse
        {
            get { return motDePasse; }
            set { motDePasse = value; }
        }

        // --- Comportement ---

        public override string Presentation()
        {
            return "Dr " + (Nom == null ? "" : Nom.ToUpper()) + ", " + specialite;
        }
    }
}
