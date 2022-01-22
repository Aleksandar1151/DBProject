using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Data
{
    public class Storniran_racun
    {
        public int Id {get; set;}
        public int Racun_id {get; set;}
        public Storniran_racun(){}
        public Storniran_racun(int id, int racun)
        {
            Id = id;
            Racun_id = racun;
        }

    }
}
