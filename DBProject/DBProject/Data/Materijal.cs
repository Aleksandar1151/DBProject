using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Data
{
    public class Materijal
    {
        public int Id {get; set;}
        public string Naziv {get; set;}
        public double Cijena {get; set;}
        public int Kolicina {get; set;}

        public Materijal(){}

        public Materijal(int id, string naziv, double cijena, int kolicina)
        {
            Id = id;
            Naziv = naziv;
            Cijena = cijena;
            Kolicina = kolicina;
        }
        public Materijal(string naziv, double cijena, int kolicina)
        {           
           Naziv = naziv;
           Cijena = cijena;
           Kolicina = kolicina;
        }

    }
}
