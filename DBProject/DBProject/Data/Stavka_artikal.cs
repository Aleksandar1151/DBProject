using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DBProject.Data
{
    public class Stavka_artikal
    {
        public int Artikal_id {get; set;}
        public int Racun_id  {get; set;}
        public string Naziv {get; set;}
        public double Cijena {get; set;}
        public int Kolicina {get; set;}
        public Stavka_artikal(){}
         public Stavka_artikal(int artikal, string naziv, double cijena, int kolicina)
        {
            Artikal_id = artikal;     
            Naziv = naziv;

            Cijena = cijena;
            Kolicina = kolicina;
        }
        public Stavka_artikal(int artikal, int racun, double cijena, int kolicina)
        {
            Artikal_id = artikal;
            Racun_id = racun;
            Cijena = cijena;
            Kolicina = kolicina;
        }

         public static void Sacuvaj(List<Stavka_artikal> ListStavka)
        {
            Database.InitializeDB();

            try
            {
                foreach(Stavka_artikal stavka in ListStavka)
                {
                    

                    //Čuvanje u bazi Stavke
                    String query = string.Format("INSERT INTO stavka_artikal SET " +
                        "racun_id = (SELECT id FROM racun WHERE id = '{0}')," +
                        "artikal_id = (SELECT id FROM artikal where id = '{1}'), " +
                        "cijena = '{2}', kolicina = '{3}'" , stavka.Racun_id, stavka.Artikal_id, stavka.Cijena, stavka.Kolicina);

                    MySqlCommand cmd = new MySqlCommand(query, Database.dbConn);

                    Database.dbConn.Open();
                    cmd.ExecuteNonQuery();                
                    Database.dbConn.Close();  
                }


                           
            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom unosa stavke artikla u bazu.\nRazlog: " + ex.Message); }
        }
    }
}
