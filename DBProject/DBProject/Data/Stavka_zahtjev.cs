using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

         public void Dodaj()
        {
            Database.InitializeDB();

            try
            {
                String query = string.Format("INSERT INTO stavka_zahtjev SET " +
                    "zahtjev_id = (SELECT id FROM zahtjev WHERE id = '{0}')," +
                    "materijal_id = (SELECT id FROM materijal WHERE id = '{1}')," +
                    "cijena = '{2}', kolicina = '{3}'"
                    ,Zahtjev_id, Materijal_id, Cijena, Kolicina);

                MySqlCommand cmd = new MySqlCommand(query, Database.dbConn);

                Database.dbConn.Open();

                cmd.ExecuteNonQuery();

                
                Database.dbConn.Close();               
            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom unosa stavke zahtjeva u bazu.\nRazlog: " + ex.Message); }
        }
    }
}
