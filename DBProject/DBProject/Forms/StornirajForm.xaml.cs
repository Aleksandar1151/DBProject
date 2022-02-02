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
    /// Interaction logic for StornirajForm.xaml
    /// </summary>
    public partial class StornirajForm : UserControl
    {
         public static ObservableCollection<Stavka_artikal> RacunStavke { get;set;}
        public static ObservableCollection<Stavka_artikal> KolekcijaStorniran { get;set;}
         public static ObservableCollection<Artikal> KolekcijaArtikal { get;set;}
        Racun racun = new Racun(); 
        int kliknutIdStavka;
        public StornirajForm()
        {
            InitializeComponent();
             KolekcijaStorniran = new ObservableCollection<Stavka_artikal>();

            RacunStavke = new ObservableCollection<Stavka_artikal>();

            KolekcijaArtikal = Artikal.Ucitaj();
        }

        private void ListElement_Click(object sender, MouseButtonEventArgs e)
        { 
            try
            {
                var item = (sender as ListView).SelectedItem; 
                if (item != null)
                {
                    System.Windows.Controls.ListView list = (System.Windows.Controls.ListView)sender;
                    Stavka_artikal izabranaStavka = (Stavka_artikal)list.SelectedItem;
                    Stavka_artikal novaStavka = new Stavka_artikal(izabranaStavka);
                    kliknutIdStavka = izabranaStavka.Artikal_id;

                    int index = RacunStavke.ToList().FindIndex(num => num.Artikal_id == kliknutIdStavka);
                    RacunStavke[index].Kolicina -= 1;

                    int i = KolekcijaStorniran.ToList().FindIndex(num2 => num2.Artikal_id == kliknutIdStavka);
                    if(i != -1)
                    {
                       KolekcijaStorniran[i].Kolicina += 1;                        
                       StorniranListView.ItemsSource = null;
                    }
                    else
                    {
                         novaStavka.Kolicina = 1;
                         KolekcijaStorniran.Add(novaStavka);
                    }                    
                    
                    if(RacunStavke[index].Kolicina == 0)
                    {
                        RacunStavke.RemoveAt(index);
                    }

                }
               (sender as ListView).SelectedItem = null;
                RacunListView.ItemsSource = null;
                StorniranListView.ItemsSource = null;

                RacunListView.ItemsSource = RacunStavke;
                StorniranListView.ItemsSource = KolekcijaStorniran;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void Stampa_Click(object sender, RoutedEventArgs e)
        {
            Storniran_racun storniranRacun = new Storniran_racun();
            racun.Sacuvaj();
            storniranRacun.Sacuvaj(racun.Id);
            
            

            List<Stavka_artikal> ListStavke = new List<Stavka_artikal>();

            foreach(Stavka_artikal kliknuta_stavka in KolekcijaStorniran)
            {
                Stavka_artikal stavka = new Stavka_artikal(kliknuta_stavka.Artikal_id,racun.Id,kliknuta_stavka.Naziv,kliknuta_stavka.Cijena,kliknuta_stavka.Kolicina);
                ListStavke.Add(stavka);
            }

            Stavka_artikal.Sacuvaj(ListStavke);
            AzurirajArtikle();

            RacunStavke.Clear();
            KolekcijaStorniran.Clear();

            RacunListView.ItemsSource = null;
            StorniranListView.ItemsSource = null;

            RacunListView.ItemsSource = RacunStavke;
            StorniranListView.ItemsSource = KolekcijaStorniran;

            RacunBox.Text = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            racun.PretraziRacun(Convert.ToInt32(RacunBox.Text));
            //racun.PretraziRacun(Convert.ToInt32(5));

            RacunStavke = Stavka_artikal.UcitajStavkeRacuna(racun.Id);

           MessageBox.Show(""+racun.Id);
            
            RacunListView.ItemsSource = null;
            RacunListView.ItemsSource = RacunStavke;
        }

        private void AzurirajArtikle()
        {
            KolekcijaArtikal = Artikal.Ucitaj();

            foreach(Stavka_artikal stornirana_stavka in KolekcijaStorniran)
            { 
                int index = KolekcijaArtikal.ToList().FindIndex(num => num.Id == stornirana_stavka.Artikal_id);
                KolekcijaArtikal[index].Kolicina += stornirana_stavka.Kolicina;
                Console.WriteLine("Stavka stornirana količina: "+stornirana_stavka.Kolicina);
            }

            Artikal.Azuriraj(KolekcijaArtikal);
        }
    }
}
