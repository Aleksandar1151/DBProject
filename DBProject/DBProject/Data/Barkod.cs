using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DBProject.Data
{
    public class Barkod
    {
        public string Kod {get; set;}

        public Barkod()
        {
            NapraviBarkod();
        }

        public Barkod(string kod)
        {
            this.Kod = kod;
        }

        public void NapraviBarkod()
        {
            String Date = DateTime.Now.ToString("ddMMyyyy");
            String generatedBarcode = Date;
            try
            {
                String Zeros = "";
                String BarcodeIteratorString = Properties.Settings.Default.Iterator.ToString();

                if (BarcodeIteratorString.Length == 1) Zeros = "000";
                if (BarcodeIteratorString.Length == 2) Zeros = "00";
                if (BarcodeIteratorString.Length == 3) Zeros = "0";
                generatedBarcode += Zeros;
                generatedBarcode += BarcodeIteratorString;
                Properties.Settings.Default.Iterator++;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom generisanja Barkoda.\nRazlog: " + ex.Message); }

            Kod = generatedBarcode;

            try
            {
                    String query = string.Format("INSERT INTO barkod SET " +
                        "kod = '{0}'" , generatedBarcode );

                    MySqlCommand cmd = new MySqlCommand(query, Database.dbConn);
                    Database.dbConn.Open();
                    cmd.ExecuteNonQuery();
                    Database.dbConn.Close();
                  
            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom unosa barkoda u bazu.\nRazlog: " + ex.Message); }



        }
    }
}
