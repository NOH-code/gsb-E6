using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB.Models
{
    public class Person
    {
        // PROPRIÉTÉS C# (Auto-Properties)
        public string Name { get; set; }
        public string Firstname { get; set; }
        public DateTime Birthdate { get; set; }

        // CONSTRUCTEURS

        // 1. Constructeur vide
        public Person() { }

        // 2. Constructeur complet
        public Person(string name, string firstname, DateTime birthdate)
        {
            this.Name = name;
            this.Firstname = firstname;
            this.Birthdate = birthdate;
        }

        // MÉTHODES

        /// <summary>
        /// Retourne l'âge en années, en tenant compte du mois et du jour
        /// (un simple écart d'années compterait trop vieux avant l'anniversaire).
        /// </summary>
        public int CalculerAge()
        {
            DateTime aujourdHui = DateTime.Today;
            int age = aujourdHui.Year - Birthdate.Year;
            if (Birthdate.Date > aujourdHui.AddYears(-age))
            {
                age--;
            }
            return age;
        }

        /// <summary>
        /// Présentation par défaut : "Prenom NOM".
        /// virtual pour être redéfinie par les classes filles (polymorphisme).
        /// </summary>
        public virtual string Presentation()
        {
            return $"{Firstname} {Name?.ToUpper()}";
        }

        // Permet l'affichage direct dans les ComboBox / DataGridView
        public override string ToString()
        {
            return Presentation();
        }
    }
}
