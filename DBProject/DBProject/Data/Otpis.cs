using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

         public static void Sacuvaj(List<Otpis> ListOtpis)
        {
            Database.InitializeDB();
            try
            {
                foreach(Otpis otpis in ListOtpis)
                {
                    String query = string.Format("INSERT INTO otpis SET " +
                        "nalog_id = (SELECT id FROM nalog WHERE id = '{0}')," +
                        "artikal_id = (SELECT id FROM artikal where id = '{1}'), " +
                        "kolicina = '{2}'" , otpis.Nalog_id, otpis.Artikal_id, otpis.Kolicina);

                    MySqlCommand cmd = new MySqlCommand(query, Database.dbConn);

                    Database.dbConn.Open();
                    cmd.ExecuteNonQuery();                
                    Database.dbConn.Close();  
                }      
            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom unosa otpisa u bazu.\nRazlog: " + ex.Message); }
        }
    }
}
