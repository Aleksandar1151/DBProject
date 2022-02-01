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
    /// Interaction logic for NaloziForm.xaml
    /// </summary>
    public partial class NaloziForm : UserControl
    {
        public static ObservableCollection<Nalog> KolekcijaNalog {get;set;}
        public NaloziForm()
        {
            InitializeComponent();
            KolekcijaNalog = Nalog.Ucitaj();
            NalogListView.ItemsSource = KolekcijaNalog;
        }

        private void NoviNalog_Click(object sender, RoutedEventArgs e)
        {
            Nalog noviNalog = new Nalog(NazivBox.Text,LozinkaBox.Text);            
            noviNalog.Sacuvaj();
        }

        
    }
}
