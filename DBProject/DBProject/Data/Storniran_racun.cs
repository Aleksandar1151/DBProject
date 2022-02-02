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

         public static ObservableCollection<Storniran_racun> Ucitaj()
        {
            ObservableCollection<Storniran_racun> KolekcijaStorniranRacun = new ObservableCollection<Storniran_racun>();
            Database.InitializeDB();

            try
            {
                String query = "SELECT * FROM storniran_racun;";
                
                MySqlCommand cmd = new MySqlCommand(query, Database.dbConn);                
                
                Database.dbConn.Open();
                
                MySqlDataReader reader = cmd.ExecuteReader();                

                while (reader.Read())
                {
                    
                    int idStorniranRacun = Convert.ToInt32(reader["id"]);
                    int idRacun = Convert.ToInt32(reader["racun_id"]);
                    
                    

                    Storniran_racun element = new Storniran_racun(idStorniranRacun,idRacun);

                    KolekcijaStorniranRacun.Add(element);
                   
                }
                Database.dbConn.Close();
            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom preuzimanja storniranih racuna iz baze!\nRazlog: " + ex.Message); }

            return KolekcijaStorniranRacun;
        }

        public void Sacuvaj(int id_racun)
        {
            Database.InitializeDB();

            try
            {
                String query = string.Format("INSERT INTO storniran_racun SET " +
                    "racun_id = (SELECT id FROM racun WHERE id = '{0}')" ,id_racun);

                MySqlCommand cmd = new MySqlCommand(query, Database.dbConn);

                Database.dbConn.Open();

                cmd.ExecuteNonQuery();

                Id = (int)cmd.LastInsertedId;
                Database.dbConn.Close();               
            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom unosa Storniranog racuna u bazu.\nRazlog: " + ex.Message); }
             

        }

    }
}
