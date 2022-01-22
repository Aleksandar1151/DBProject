using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Data
{
    public class Artikal
    {
        public int Id { get; set;}
        public string Naziv { get; set;}
        public string Cijena { get; set;}
        public int Kolicina { get; set;}
        public string Kod { get; set;}

        public Artikal(){}
        public Artikal(int id, string naziv, string cijena, int kolicina, string kod)
        {
            Id = id;
            Naziv = naziv;
            Cijena = cijena;
            Kolicina = kolicina;
            Kod = kod;
        }
        public Artikal(string naziv, string cijena, int kolicina, string kod)
        {           
            Naziv = naziv;
            Cijena = cijena;
            Kolicina = kolicina;
            Kod = kod;
        }
    }
}
