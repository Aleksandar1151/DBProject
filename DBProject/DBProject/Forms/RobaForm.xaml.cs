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
        public static ObservableCollection<Stavka_artikal> RacunStavke {get;set;}
         int kliknutIdArtikal;
        public RobaForm()
        {
            InitializeComponent();
            RacunStavke = new ObservableCollection<Stavka_artikal>();
            RacunListView.ItemsSource = RacunStavke;
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


            

            try
            {
                if(Convert.ToInt32(AzurirajBox.Text)>0)
                {
                    int index = KolekcijaArtikal.ToList().FindIndex(num => num.Id == kliknutIdArtikal);
                    KolekcijaArtikal[index].Kolicina = Convert.ToInt32(AzurirajBox.Text); 
    
                    Artikal.Azuriraj(KolekcijaArtikal);

                    RefreshTable();

                    AzurirajBox.Text = null;
                }
                else
                {
                    MessageBox.Show("Količina ne može biti negativna.");
                }

                 
                
            }catch{}
               

           
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

                    if(izabranArtikal.Kolicina == 0) return;

                    izabranArtikal.Kolicina-=1;

                    Stavka_artikal stavka = new Stavka_artikal(izabranArtikal.Id,izabranArtikal.Naziv,izabranArtikal.Cijena,1);
                    //RacunStavke.Add(stavka);


                     if(RacunStavke.Count == 0)
                     {
                         RacunStavke.Add(stavka);
                     }
                     else
                     {
                         int i = RacunStavke.ToList().FindIndex(itemX => itemX.Artikal_id == kliknutIdArtikal);

                         if(i != -1)
                         {
                             RacunStavke[i].Kolicina += 1;
                             
                         }
                         else
                         {
                             RacunStavke.Add(stavka);
                         }

                     }    


                    RacunListView.ItemsSource = null;
                    RacunListView.ItemsSource = RacunStavke;

                    RobaListView.ItemsSource = null;
                    RobaListView.ItemsSource = KolekcijaArtikal;

                }
                //(sender as ListView).SelectedItem = null;
             }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Stampaj_Click(object sender, RoutedEventArgs e)
        {
            Racun racun = new Racun();
            racun.Dodaj();            

            List<Stavka_artikal> ListStavke = new List<Stavka_artikal>();

            foreach(Stavka_artikal kliknuta_stavka in RacunStavke)
            {
                Stavka_artikal stavka = new Stavka_artikal(kliknuta_stavka.Artikal_id, racun.Id,kliknuta_stavka.Cijena,kliknuta_stavka.Kolicina);
                ListStavke.Add(stavka);
            }

            Stavka_artikal.Sacuvaj(ListStavke);
            OsvjeziRacun();
            MessageBox.Show("Uspješno otštampan račun.");
        }

        private void Otpisi_Klik(object sender, RoutedEventArgs e)
        {
            List<Otpis> ListOtpis = new List<Otpis>();

            foreach(Stavka_artikal kliknuta_stavka in RacunStavke)
            { 
                Otpis otpis = new Otpis(LoginWindow.IDNalog, kliknuta_stavka.Artikal_id, kliknuta_stavka.Kolicina);
                ListOtpis.Add(otpis);
            }

            Otpis.Sacuvaj(ListOtpis);            
           
            OsvjeziRacun();
            MessageBox.Show("Uspješno otpisan račun.");
        }

         private void OsvjeziRacun()
        {
            Artikal.Azuriraj(KolekcijaArtikal);
            RacunStavke.Clear();
            RacunListView.ItemsSource = null;
            RacunListView.ItemsSource = RacunStavke;
        }

        private void RightMouse_Click(object sender, MouseButtonEventArgs e)
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
