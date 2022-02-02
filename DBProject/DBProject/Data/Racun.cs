using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DBProject.Data
{
    public class Racun
    {
        public int Id {get; set;}
        public string Datum {get; set;}
        public int Nalog_id {get; set;}
        public Racun()
        {            
            Datum = DateTime.Today.ToString("yyyy-mm-dd");           
        }
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


        public void Dodaj()
        {
            Database.InitializeDB();

            try
            {
                String query = string.Format("INSERT INTO racun SET " +
                    "datum = '{0}', nalog_id = (SELECT id FROM nalog WHERE id = '{1}')" ,Datum, LoginWindow.IDNalog);

                MySqlCommand cmd = new MySqlCommand(query, Database.dbConn);

                Database.dbConn.Open();

                cmd.ExecuteNonQuery();

                Id = (int)cmd.LastInsertedId;
                Database.dbConn.Close();               
            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom unosa racuna u bazu.\nRazlog: " + ex.Message); }
        }

        public void PretraziRacun(int id)
        {
            try
            {
                String query = string.Format("SELECT * from racun where `id` = {0}" , id);

                MySqlCommand cmd = new MySqlCommand(query, Database.dbConn);                
                
                Database.dbConn.Open();
                
                MySqlDataReader reader = cmd.ExecuteReader();   

                if(reader.Read())
                {
                     Id = Convert.ToInt32(reader["id"]);                   
                     Datum = reader["datum"].ToString();                    
                     Nalog_id = Convert.ToInt32(reader["nalog_id"]);    
                }

                          


                Database.dbConn.Close();               
            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom ucitavanja racuna iz baze.\nRazlog: " + ex.Message); }
        }

         public void Sacuvaj()
        {
            Database.InitializeDB();

            try
            {
                String query = string.Format("INSERT INTO racun SET " +
                    "datum = '{0}', nalog_id = (SELECT id FROM nalog WHERE id = '{1}')" , DateTime.Today.ToString("yyyy-mm-dd"), LoginWindow.IDNalog);

                MySqlCommand cmd = new MySqlCommand(query, Database.dbConn);

                Database.dbConn.Open();

                cmd.ExecuteNonQuery();

                Id = (int)cmd.LastInsertedId;
                Database.dbConn.Close();               
            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom unosa racuna u bazu.\nRazlog: " + ex.Message); }
        }

    }
}
