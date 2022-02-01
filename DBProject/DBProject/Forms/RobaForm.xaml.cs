using DBProject.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DBProject.Forms
{
    /// <summary>
    /// Interaction logic for RobaForm.xaml
    /// </summary>
    public partial class RobaForm : UserControl
    {
        public static ObservableCollection<Artikal> KolekcijaArtikal { get;set;}
         int kliknutIdArtikal;
        public RobaForm()
        {
            InitializeComponent();
            RefreshTable();
        }

        private void Dodaj_Klik(object sender, RoutedEventArgs e)
        {
            Barkod barkod = new Barkod();
            Artikal artikal= new Artikal(NazivBox.Text,Convert.ToDouble(CijenaBox.Text), Convert.ToInt32(KolicinaBox.Text),barkod.Kod);
            
            KolekcijaArtikal.Add(artikal);
            Artikal.Dodaj(artikal);

            

            RefreshTable();
        }

        private void Azuriraj_Klik(object sender, RoutedEventArgs e)
        {
               

            int index = KolekcijaArtikal.ToList().FindIndex(num => num.Id == kliknutIdArtikal);
            KolekcijaArtikal[index].Kolicina += Convert.ToInt32(AzurirajBox.Text); 

            Artikal.Azuriraj(KolekcijaArtikal);

            RefreshTable();
        }

        public void RefreshTable()
        {

            NazivBox.Text = null;
            CijenaBox.Text = null;
            KolicinaBox.Text = null;

            KolekcijaArtikal = Artikal.Ucitaj();
            RobaListView.ItemsSource = null;

            RobaListView.ItemsSource = KolekcijaArtikal;
        }

        private void ListElement_Click(object sender, MouseButtonEventArgs e)
        {
             try
             {
                var item = (sender as ListView).SelectedItem; 
                if (item != null)
                {
                    
                    System.Windows.Controls.ListView list = (System.Windows.Controls.ListView)sender;
                  

                    Artikal izabranArtikal = (Artikal)list.SelectedItem;
                    kliknutIdArtikal = izabranArtikal.Id;


                }
                //(sender as ListView).SelectedItem = null;
             }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
