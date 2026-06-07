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
    }
}