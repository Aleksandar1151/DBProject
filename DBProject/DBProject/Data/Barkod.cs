using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Data
{
    public class Barkod
    {
        public string Kod {get; set;}

        public Barkod(){}

        public Barkod(string kod)
        {
            this.Kod = kod;
        }
    }
}
