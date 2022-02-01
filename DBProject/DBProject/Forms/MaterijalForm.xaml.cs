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
    /// Interaction logic for MaterijalForm.xaml
    /// </summary>
    public partial class MaterijalForm : UserControl
    {
         public static ObservableCollection<Materijal> KolekcijaMaterijal { get;set;}

        int izabranID = 0;
        public MaterijalForm()
        {
            InitializeComponent();
            KolekcijaMaterijal = Materijal.Ucitaj();

            MaterijalListView.ItemsSource = KolekcijaMaterijal;
            
        }

        private void Dodaj_Klik(object sender, RoutedEventArgs e)
        {
            Materijal materijal = new Materijal(NazivBox.Text,Convert.ToDouble(CijenaBox.Text),Convert.ToInt32(KolicinaBox.Text));
            materijal.Dodaj();
            KolekcijaMaterijal.Add(materijal);

            NazivBox.Text =null;
            CijenaBox.Text = null;
            KolicinaBox.Text = null;
        }

        private void Azuriraj_Klik(object sender, RoutedEventArgs e)
        {
            MaterijalListView.ItemsSource = null;            

            int index = KolekcijaMaterijal.ToList().FindIndex(num => num.Id == izabranID);
            KolekcijaMaterijal[index].Kolicina = Convert.ToInt32(AzurirajBox.Text); 

            Materijal.Azuriraj(KolekcijaMaterijal);

            KolekcijaMaterijal = Materijal.Ucitaj();

            MaterijalListView.ItemsSource = KolekcijaMaterijal;

            AzurirajBox.Text = null;
            
        }

        private void ListElement_Click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var item = (sender as ListView).SelectedItem; 
                if (item != null)
                {
                    System.Windows.Controls.ListView list = (System.Windows.Controls.ListView)sender;
                    Materijal izabran = (Materijal)list.SelectedItem;
                    izabranID = izabran.Id;                  

                    

                }
              
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void RefreshTable()
        {
            MaterijalListView.ItemsSource = null;
            MaterijalListView.ItemsSource = KolekcijaMaterijal;
        }
    }
}
