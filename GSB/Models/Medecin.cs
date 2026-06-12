using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB.Models
{
    public class Doctor : Person
    {
        // Identifiant, mappé sur la colonne SQL numMedecin
        public int Id { get; set; }

        // Spécialité du médecin (colonne SQL specialite)
        public string Specialite { get; set; } = "";

        // Email du médecin (colonne SQL email), utilisable comme identifiant
        // de connexion au même titre que le numéro RPPS.
        public string Email { get; set; } = "";

        private String rpps;
        private String password;

        // ACCESSEURS
        public String getRpps() { return rpps; }
        public String getEmail() { return Email; }
        public String getPassword() { return password; }

        ///MUTATEURS
        public void setRpps(String newrpps) { this.rpps = newrpps; }
        public void setPassword(String newpassword) { this.password = newpassword; }
        public void setEmail(String newemail) { this.Email = newemail; }

        // CONSTRUCTEURS

        public Doctor() : base() { }

        public Doctor(string email, String rpps, String password, string name, string firstname, DateTime birthdate)
            : base(name, firstname, birthdate)
        {

            this.Email = email;
            this.rpps = rpps;
            this.password = password;


        }

        // MÉTHODES

        /// <summary>
        /// Présentation adaptée au médecin : "Dr NOM, Specialite".
        /// </summary>
        public override string Presentation()
        {
            return string.IsNullOrEmpty(Specialite)
                ? $"Dr {Name?.ToUpper()}"
                : $"Dr {Name?.ToUpper()}, {Specialite}";
        }
    }
}
