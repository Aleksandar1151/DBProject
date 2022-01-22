using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Data
{
    public class Otpis
    {
        public int Nalog_id {get; set;}
        public int Artikal_id {get; set;}
        public int Kolicina {get; set;}
        public Otpis(){}
        public Otpis(int nalog, int artikal, int kolicina)
        {
            Nalog_id = nalog;
            Artikal_id = artikal;
            Kolicina = kolicina;
        }
    }
}
