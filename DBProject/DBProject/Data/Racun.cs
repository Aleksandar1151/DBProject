using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Data
{
    public class Racun
    {
        public int Id {get; set;}
        public string Datum {get; set;}
        public int Nalog_id {get; set;}
        public Racun(){}
        public Racun(int id, string datum, int nalog)
        {
            Id = id;
            Datum = datum;
            Nalog_id = nalog;
        }
        public Racun(string datum, int nalog)
        {            
            Datum = datum;
            Nalog_id = nalog;
        }
    }
}
