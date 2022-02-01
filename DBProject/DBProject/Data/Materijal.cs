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

          public static ObservableCollection<Materijal> Ucitaj()
        {
            ObservableCollection<Materijal> kolekcija = new ObservableCollection<Materijal>();
            Database.InitializeDB();

            try
            {
                String query = "SELECT * FROM materijal;";
                
                MySqlCommand cmd = new MySqlCommand(query, Database.dbConn);
                
                
                Database.dbConn.Open();
                
                MySqlDataReader reader = cmd.ExecuteReader();
                

                while (reader.Read())
                {
                    
                    int idNalog = Convert.ToInt32(reader["id"]);
                    string ime = reader["naziv"].ToString();
                    double cijena = Convert.ToDouble(reader["cijena"]); 
                    int kolicina = Convert.ToInt32(reader["kolicina"]);
                    Materijal element = new Materijal(idNalog, ime, cijena, kolicina);
                    kolekcija.Add(element);
                   
                }
                Database.dbConn.Close();
            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom preuzimanja naloga iz baze!\nRazlog: " + ex.Message); }

            return kolekcija;
        }

         public void Dodaj()
        {
            try
            {
                 String query = string.Format("INSERT INTO materijal SET " +                                               
                        " naziv = '{0}', cijena = '{1}', kolicina = '{2}'" , Naziv, Cijena, Kolicina);                    

                    MySqlCommand cmd = new MySqlCommand(query, Database.dbConn);
                    Database.dbConn.Open();
                    cmd.ExecuteNonQuery();
                    Database.dbConn.Close();       
              


                        
            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom mijenjanja artikla u bazi.\nRazlog: " + ex.Message); }
        }

        public static void Azuriraj(ObservableCollection<Materijal> KolekcijaArtikal)
        {
            try
            {

                foreach(Materijal materijal in KolekcijaArtikal)
                {
                    String query = string.Format("UPDATE materijal SET " +
                   "kolicina='{0}' WHERE id = '{1}'"
                   ,materijal.Kolicina, materijal.Id);

                    MySqlCommand cmd = new MySqlCommand(query, Database.dbConn);
                    Database.dbConn.Open();
                    cmd.ExecuteNonQuery();
                    Database.dbConn.Close();       
                }


                        
            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom mijenjanja materijala u bazi.\nRazlog: " + ex.Message); }
        }

          public static ObservableCollection<Materijal> UcitajNabavku()
        {
            ObservableCollection<Materijal> kolekcija = new ObservableCollection<Materijal>();
            Database.InitializeDB();

            try
            {
                String query = "SELECT * FROM nabavkapogled;";
                
                MySqlCommand cmd = new MySqlCommand(query, Database.dbConn);
                
                
                Database.dbConn.Open();
                
                MySqlDataReader reader = cmd.ExecuteReader();
                

                while (reader.Read())
                {
                    
                    int idNalog = Convert.ToInt32(reader["id"]);
                    string ime = reader["naziv"].ToString();
                    double cijena = Convert.ToDouble(reader["cijena"]); 
                    int kolicina = Convert.ToInt32(reader["kolicina"]);
                    Materijal element = new Materijal(idNalog, ime, cijena, kolicina);
                    kolekcija.Add(element);
                   
                }
                Database.dbConn.Close();
            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom preuzimanja naloga iz baze!\nRazlog: " + ex.Message); }

            return kolekcija;
        }

    }
}
