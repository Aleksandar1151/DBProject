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
        public ZahtjevForm()
        {
            InitializeComponent();
            KolekcijaMaterijal = Materijal.Ucitaj();

            foreach(Materijal materijal in KolekcijaMaterijal)
            {
                ComboBoxItem item = new ComboBoxItem();  
                item.Content = materijal.Naziv;  
                MaterijalCombo.Items.Add(item);
            }
        }

        private void StampaButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Barkod bk = new Barkod();
                //Zahtjev zahtjev = new Zahtjev(ImeBox.Text,TelefonBox.Text,ModelBox.Text,OpisBox.Text,NapomenaBox.Text,Convert.ToDouble(UplataBox.Text),Convert.ToDouble(PlacenoBox.Text),Convert.ToDouble(OstaloBox.Text),"primljen",DateTime.Today.ToString("yyyy-mm-dd"),bk.Kod,LoginWindow.IDNalog);

                int index = MaterijalCombo.SelectedIndex;

                MessageBox.Show(KolekcijaMaterijal[index].Id + KolekcijaMaterijal[index].Naziv);
               // zahtjev.Dodaj();
            }
            catch (Exception ex) { MessageBox.Show("Greška prilikom kreiranja zahtjeva. Provjerite format."); }
        }
    }
}
