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
    /// Interaction logic for ZahtjevForm.xaml
    /// </summary>
    public partial class ZahtjevForm : UserControl
    {
        public static ObservableCollection<Materijal> KolekcijaMaterijal { get;set;}
        public static ObservableCollection<Zahtjev> KolekcijaZahtjeva { get;set;}
        public ZahtjevForm()
        {
            InitializeComponent();
            KolekcijaMaterijal = Materijal.Ucitaj();
            KolekcijaZahtjeva = Zahtjev.Ucitaj();

            foreach(Materijal materijal in KolekcijaMaterijal)
            {
                ComboBoxItem item = new ComboBoxItem();  
                item.Content = materijal.Naziv;  
                MaterijalCombo.Items.Add(item);
            }

            ZahtjevListView.ItemsSource = KolekcijaZahtjeva;

            
        }

        private void StampaButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Barkod bk = new Barkod();
                

                int index = MaterijalCombo.SelectedIndex;                

                Zahtjev zahtjev = new Zahtjev(ImeBox.Text,TelefonBox.Text,ModelBox.Text,OpisBox.Text,NapomenaBox.Text,Convert.ToDouble(UplataBox.Text),Convert.ToDouble(PlacenoBox.Text),Convert.ToDouble(OstaloBox.Text),"primljen",DateTime.Today.ToString("yyyy-mm-dd"),bk.Kod,LoginWindow.IDNalog);
                zahtjev.Dodaj();

                Stavka_zahtjev stavka = new Stavka_zahtjev(zahtjev.Id,KolekcijaMaterijal[index].Id, KolekcijaMaterijal[index].Cijena, 1 );

                stavka.Dodaj();
                KolekcijaMaterijal[index].Kolicina -= 1;

                Materijal.Azuriraj(KolekcijaMaterijal);

    
                ImeBox.Text = null;
                TelefonBox.Text = null;
                ModelBox.Text = null;
                OpisBox.Text = null;
                NapomenaBox.Text = null;
                UplataBox.Text = null;
                PlacenoBox.Text = null;
                OstaloBox.Text = null;
                ZahtjevListView.ItemsSource = null;
                ZahtjevListView.ItemsSource = KolekcijaZahtjeva;
            }
            catch(Exception) { MessageBox.Show("Greška prilikom kreiranja zahtjeva. Provjerite format."); }

            
        }

        private void ListElement_Click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var item = (sender as ListView).SelectedItem; 
                if (item != null)
                {
                    System.Windows.Controls.ListView list = (System.Windows.Controls.ListView)sender;
                    Zahtjev izabran = (Zahtjev)list.SelectedItem;
                    var stanjeWindow = new StanjeWindow(izabran);   
                    stanjeWindow.Show();

                    

                }
              
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
