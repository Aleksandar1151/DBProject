using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DBProject.Data
{
    public class Zahtjev
    {
        public int Id { set; get;}
        public string Korisnicko_ime { set; get;}
        public string Broj_telefona { set; get;}
        public string Model  { set; get;}
        public string Opis_kvara  { set; get;}
        public string Napomena  { set; get;}
        public double Za_uplatu { set; get;}
        public double Placeno  { set; get;}
        public double Ostalo  { set; get;}
        public string Stanje  { set; get;}
        public string Datum  { set; get;}
        public string Kod  { set; get;}
        public int Nalog_id  { set; get;}
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
    
        
        public void Dodaj()
        {
            try
            {
                 String query = string.Format("INSERT INTO zahtjev SET " +
                        "barkod = (SELECT kod FROM barkod WHERE kod = '{0}')," +         
                        "nalog_id = (SELECT id FROM nalog WHERE id = '{1}')," +
                        " korisnickoIme = '{2}', brojTelefona = '{3}', model = '{4}', opisKvara = '{5}', napomena = '{6}', zaUplatu = '{7}', placeno = '{8}', ostalo = '{9}', stanje = '{10}', datum = '{11}'" 
                        , Kod, Nalog_id, Korisnicko_ime, Broj_telefona, Model, Opis_kvara, Napomena, Za_uplatu, Placeno, Ostalo, Stanje, Datum);

                    

                    MySqlCommand cmd = new MySqlCommand(query, Database.dbConn);
                    Database.dbConn.Open();
                    cmd.ExecuteNonQuery();
                    Id = (int)cmd.LastInsertedId;
                    Database.dbConn.Close();       
              


                        
            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom dodavanja zahtjeva u bazi.\nRazlog: " + ex.Message); }
        }
        
        public static ObservableCollection<Zahtjev> Ucitaj()
        {
            ObservableCollection<Zahtjev> kolekcija = new ObservableCollection<Zahtjev>();
            Database.InitializeDB();

            try
            {
                String query = "SELECT * FROM zahtjev;";
                
                MySqlCommand cmd = new MySqlCommand(query, Database.dbConn);
                
                
                Database.dbConn.Open();
                
                MySqlDataReader reader = cmd.ExecuteReader();
                

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string ime = reader["korisnickoIme"].ToString();
                    string broj = reader["brojTelefona"].ToString();
                    string model = reader["model"].ToString();
                    string opis = reader["opisKvara"].ToString();
                    string napomena = reader["napomena"].ToString();

                    double uplata = Convert.ToDouble(reader["zaUplatu"]); 
                    double placeno = Convert.ToDouble(reader["placeno"]);
                    double ostalo = Convert.ToDouble(reader["ostalo"]);

                    string stanje = reader["stanje"].ToString();
                    string datum = reader["datum"].ToString();
                    string barkod = reader["barkod"].ToString();

                    int nalog_id = Convert.ToInt32(reader["nalog_id"]);

                    
                   
                    if(stanje != "naplacen")
                    {
                        Zahtjev element = new Zahtjev(id,ime,broj,model,opis,napomena,uplata,placeno,ostalo,stanje,datum,barkod,nalog_id);
                        kolekcija.Add(element);
                    }
                    
                   
                }
                Database.dbConn.Close();
            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom preuzimanja zahtjeva iz baze!\nRazlog: " + ex.Message); }

            return kolekcija;
        }

         public  void Azuriraj()
        {
            try
            {


                    String query = string.Format("UPDATE zahtjev SET " +
                   "stanje='{0}' WHERE id = '{1}'"
                   ,Stanje, Id);

                    MySqlCommand cmd = new MySqlCommand(query, Database.dbConn);
                    Database.dbConn.Open();
                    cmd.ExecuteNonQuery();
                    Database.dbConn.Close();       
                

                        
            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom mijenjanja materijala u bazi.\nRazlog: " + ex.Message); }
        }


         public static ObservableCollection<Zahtjev> UcitajNaplacene()
        {
            ObservableCollection<Zahtjev> kolekcija = new ObservableCollection<Zahtjev>();
            Database.InitializeDB();

            try
            {
                String query = "CALL stanje_procedura;";
                
                MySqlCommand cmd = new MySqlCommand(query, Database.dbConn);
                
                
                Database.dbConn.Open();
                
                MySqlDataReader reader = cmd.ExecuteReader();
                

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string ime = reader["korisnickoIme"].ToString();
                    string broj = reader["brojTelefona"].ToString();
                    string model = reader["model"].ToString();
                    string opis = reader["opisKvara"].ToString();
                    string napomena = reader["napomena"].ToString();

                    double uplata = Convert.ToDouble(reader["zaUplatu"]); 
                    double placeno = Convert.ToDouble(reader["placeno"]);
                    double ostalo = Convert.ToDouble(reader["ostalo"]);

                    string stanje = reader["stanje"].ToString();
                    string datum = reader["datum"].ToString();
                    string barkod = reader["barkod"].ToString();

                    int nalog_id = Convert.ToInt32(reader["nalog_id"]);

                    
                   
                   
                        Zahtjev element = new Zahtjev(id,ime,broj,model,opis,napomena,uplata,placeno,ostalo,stanje,datum,barkod,nalog_id);
                        kolekcija.Add(element);
                                        
                   
                }
                Database.dbConn.Close();
            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom preuzimanja zahtjeva iz baze!\nRazlog: " + ex.Message); }

            return kolekcija;
        }
        
    }
}
