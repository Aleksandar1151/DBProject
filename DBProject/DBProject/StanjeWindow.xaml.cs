using DBProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DBProject
{
    /// <summary>
    /// Interaction logic for StanjeWindow.xaml
    /// </summary>
    public partial class StanjeWindow : Window
    {
        Zahtjev zahtjev;
        public StanjeWindow(Zahtjev zahtjevIn)
        {
            InitializeComponent();

            zahtjev = zahtjevIn;
            LabelIme.Content = zahtjev.Korisnicko_ime;
            LabelModel.Content = zahtjev.Model;
            LabelTelefon.Content = zahtjev.Broj_telefona;
            string stanje = zahtjev.Stanje;

            if (stanje == "primljen") RB_Primljen.IsChecked = true;
            if (stanje == "na cekanju") RB_NaCekanju.IsChecked = true;
            if (stanje == "zavrsen") RB_Zavrsen.IsChecked = true;
            if (stanje == "realizovan") RB_Realizovan.IsChecked = true;
            if (stanje == "naplacen") RB_Naplacen.IsChecked = true;


                
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(RB_Primljen.IsChecked == true) zahtjev.Stanje = "primljen";
            if(RB_NaCekanju.IsChecked == true) zahtjev.Stanje = "na cekanju";
            if(RB_Zavrsen.IsChecked == true) zahtjev.Stanje = "zavrsen";
            if(RB_Realizovan.IsChecked == true) zahtjev.Stanje = "realizovan";
            if(RB_Naplacen.IsChecked == true) zahtjev.Stanje = "naplacen";

            zahtjev.Azuriraj();
        }
    }
}
