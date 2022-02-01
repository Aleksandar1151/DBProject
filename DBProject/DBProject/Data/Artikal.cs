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
    public class Artikal
    {
        public int Id { get; set;}
        public string Naziv { get; set;}
        public double Cijena { get; set;}
        public int Kolicina { get; set;}
        public string Kod { get; set;}

        public Artikal(){}
        public Artikal(int id, string naziv, double cijena, int kolicina, string kod)
        {
            Id = id;
            Naziv = naziv;
            Cijena = cijena;
            Kolicina = kolicina;
            Kod = kod;
        }
        public Artikal(string naziv, double cijena, int kolicina, string kod)
        {           
            Naziv = naziv;
            Cijena = cijena;
            Kolicina = kolicina;
            Kod = kod;
        }

         public static ObservableCollection<Artikal> Ucitaj()
        {
            ObservableCollection<Artikal> KolekcijaArtikal = new ObservableCollection<Artikal>();
            Database.InitializeDB();

            try
            {
                String query = "SELECT * FROM artikal;";
                
                MySqlCommand cmd = new MySqlCommand(query, Database.dbConn);
                
                
                Database.dbConn.Open();
                
                MySqlDataReader reader = cmd.ExecuteReader();
                

                while (reader.Read())
                {
                    
                    int idArtikal = Convert.ToInt32(reader["id"]);
                    string naziv = reader["naziv"].ToString();
                    double cijena = Convert.ToDouble(reader["cijena"]);
                    int kolicina = Convert.ToInt32( reader["kolicina"]);
                    string barkod = reader["barkod"].ToString();
                    Artikal element = new Artikal(idArtikal, naziv, cijena, kolicina,barkod);

                    
                    KolekcijaArtikal.Add(element);
                    
                    
                   
                }
                Database.dbConn.Close();
            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom preuzimanja artikala iz baze!!!!!\nRazlog: " + ex.Message); }

            return KolekcijaArtikal;
        }

        public static void Dodaj(Artikal noviArtikal)
        {
            try
            {
                 String query = string.Format("INSERT INTO artikal SET " +
                        "barkod = (SELECT kod FROM barkod WHERE kod = '{0}')," +                        
                        " naziv = '{1}', cijena = '{2}', kolicina = '{3}'" , noviArtikal.Kod, noviArtikal.Naziv, noviArtikal.Cijena, noviArtikal.Kolicina);

                    

                    MySqlCommand cmd = new MySqlCommand(query, Database.dbConn);
                    Database.dbConn.Open();
                    cmd.ExecuteNonQuery();
                    Database.dbConn.Close();       
              


                        
            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom mijenjanja artikla u bazi.\nRazlog: " + ex.Message); }
        }
    
    
         public static void Azuriraj(ObservableCollection<Artikal> KolekcijaArtikal)
        {
            try
            {

                foreach(Artikal artikal in KolekcijaArtikal)
                {
                    String query = string.Format("UPDATE artikal SET " +
                   "kolicina='{0}' WHERE id = '{1}'"
                   ,artikal.Kolicina, artikal.Id);

                    MySqlCommand cmd = new MySqlCommand(query, Database.dbConn);
                    Database.dbConn.Open();
                    cmd.ExecuteNonQuery();
                    Database.dbConn.Close();       
                }


                        
            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom mijenjanja artikla u bazi.\nRazlog: " + ex.Message); }
        }
        
    }
}
