using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Data
{
    public class Stavka_artikal
    {
        public int Artikal_id {get; set;}
        public int Racun_id  {get; set;}
        public string Cijena {get; set;}
        public string Kolicina {get; set;}
        public Stavka_artikal(){}
        public Stavka_artikal(int artikal, int racun, string cijena, string kolicina)
        {
            Artikal_id = artikal;
            Racun_id = racun;
            Cijena = cijena;
            Kolicina = kolicina;
        }
    }
}
