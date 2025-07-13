using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppMJV
{
    internal class Itemcpl
    {
        private int id;
        private string nom;

        public Itemcpl(int id, string nom)
        {
            this.id = id;
            this.nom = nom;
        }

        public int getId() { 
            return id; 
        }
        public string getNom() { 
            return nom;
        }

        public override string ToString()
        {
            return this.nom;
        }

    }
}
