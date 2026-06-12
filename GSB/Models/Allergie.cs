using System;

namespace GSB.Models
{
    /// <summary>
    /// Allergie référencée en base (table ALLERGIE).
    /// Classe simple, sans héritage.
    /// </summary>
    public class Allergie
    {
        // Identifiant, mappé sur la colonne SQL codeAllergie
        public int Id { get; set; }

        // Libellé de l'allergie (colonne SQL libelle)
        public string Libelle { get; set; } = "";

        public Allergie() { }

        public Allergie(string libelle)
        {
            this.Libelle = libelle;
        }

        // Permet l'affichage direct dans les CheckedListBox / ComboBox
        public override string ToString()
        {
            return Libelle;
        }
    }
}
