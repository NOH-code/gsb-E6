using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB.Models
{
    public class Doctor : Person
    {
        
        private String email;
        private String rpps;
        private String password;

        // ACCESSEURS
        public String getRpps() { return rpps; }
        public String getEmail() { return email; }
        public String getPassword() { return password; }

        ///MUTATEURS
        public void setRpps(String newrpps) { this.rpps = newrpps; }
        public void setPassword(String newpassword) { this.password = newpassword; }
        public void setEmail(String newemail) { this.email = newemail; }

        // CONSTRUCTEUR

        public Doctor(string email, String rpps, String password, string name, string firstname, DateTime birthdate)
            : base(name, firstname, birthdate)
        {

            this.email = email;
            this.rpps = rpps;
            this.password = password;
           
        
        }
    }
}