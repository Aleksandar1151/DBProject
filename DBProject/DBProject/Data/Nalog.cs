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
    public class Nalog
    {
        public int Id {get; set;}
        public string Ime {get; set;}
        public string Lozinka {get; set;}

        public Nalog(string ime, string lozinka)
        {
            Ime = ime;
            Lozinka = lozinka;
        }

         public Nalog(int id, string ime, string lozinka)
        {
            Id = id;
            Ime = ime;
            Lozinka = lozinka;
        }

         public static ObservableCollection<Nalog> Ucitaj()
        {
            ObservableCollection<Nalog> KolekcijaNalog = new ObservableCollection<Nalog>();
            Database.InitializeDB();

            try
            {
                String query = "SELECT * FROM nalog;";
                
                MySqlCommand cmd = new MySqlCommand(query, Database.dbConn);
                
                
                Database.dbConn.Open();
                
                MySqlDataReader reader = cmd.ExecuteReader();
                

                while (reader.Read())
                {
                    
                    int idNalog = Convert.ToInt32(reader["id"]);
                    string ime = reader["ime"].ToString();
                    string lozinka = reader["lozinka"].ToString();                    
                    Nalog element = new Nalog(idNalog, ime, lozinka);
                    KolekcijaNalog.Add(element);
                   
                }
                Database.dbConn.Close();
            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom preuzimanja naloga iz baze!\nRazlog: " + ex.Message); }

            return KolekcijaNalog;
        }

        public void Sacuvaj()
        {
            Database.InitializeDB();
            try
            {                         

                    String query = string.Format("INSERT INTO nalog SET " +
                        "ime = '{0}', lozinka = '{1}'" , Ime, Lozinka);

                    MySqlCommand cmd = new MySqlCommand(query, Database.dbConn);

                    Database.dbConn.Open();
                    cmd.ExecuteNonQuery();                
                    Database.dbConn.Close();  
                  
            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom unosa naloga u bazu.\nRazlog: " + ex.Message); }
        }

    }
}
