using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Data
{
    public class Stavka_zahtjev
    {
        public int Zahtjev_id { get; set;}
        public int Materijal_id { get; set;}
        public double Cijena { get; set;}
        public int Kolicina { get; set;}

        public Stavka_zahtjev()
        { }

        public Stavka_zahtjev(int zahtjev_id, int materijal_id, double cijena, int kolicina )
        {
            this.Zahtjev_id = zahtjev_id;
            this.Materijal_id = materijal_id;
            this.Cijena = cijena;
            this.Kolicina = kolicina;
        }
    }
}
