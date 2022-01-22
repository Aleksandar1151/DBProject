using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Data
{
    public class Zahtjev
    {
        int Id { set; get;}
        string Korisnicko_ime { set; get;}
        string Broj_telefona { set; get;}
        string Model  { set; get;}
        string Opis_kvara  { set; get;}
        string Napomena  { set; get;}
        double Za_uplatu { set; get;}
        double Placeno  { set; get;}
        double Ostalo  { set; get;}
        string Stanje  { set; get;}
        string Datum  { set; get;}
        string Kod  { set; get;}
        int Nalog_id  { set; get;}

        public Zahtjev() {}

        public Zahtjev(int id, string korisnicko_ime, string broj_telefona, string model,
            string opis_kvara, string napomena, double za_uplatu, double placeno,
            double ostalo, string stanje, string datum, string barkod, int nalog_id)
        {
            this.Id = id;
            this.Korisnicko_ime = korisnicko_ime;
            this.Broj_telefona= broj_telefona;
            this.Model = model;
            this.Opis_kvara = opis_kvara;
            this.Napomena = napomena;
            this.Za_uplatu = za_uplatu;
            this.Placeno = placeno;
            this.Ostalo = ostalo;
            this.Stanje = stanje;
            this.Datum = datum;
            this.Kod = barkod;
            this.Nalog_id = nalog_id;
        }
        public Zahtjev(string korisnicko_ime, string broj_telefona, string model,
            string opis_kvara, string napomena, double za_uplatu, double placeno,
            double ostalo, string stanje, string datum, string barkod, int nalog_id)
        {           
            this.Korisnicko_ime = korisnicko_ime;
            this.Broj_telefona= broj_telefona;
            this.Model = model;
            this.Opis_kvara = opis_kvara;
            this.Napomena = napomena;
            this.Za_uplatu = za_uplatu;
            this.Placeno = placeno;
            this.Ostalo = ostalo;
            this.Stanje = stanje;
            this.Datum = datum;
            this.Kod = barkod;
            this.Nalog_id = nalog_id;
        }
    }
}
