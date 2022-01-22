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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DBProject.Forms;

namespace DBProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainGrid.Children.Clear();
            ZahtjevForm form = new ZahtjevForm();
            MainGrid.Children.Add(form);       
        }

        private void Tranzicija_Klik(object sender, RoutedEventArgs e)
        {
            var pressedButton = (Button)sender;
            int index = int.Parse(pressedButton.Uid);

            string lightColor = "#E0FBFC";
            string darkColor = "#3D5A80";

            ChangeButtonColors(ButtonTab1,darkColor,lightColor);
            ChangeButtonColors(ButtonTab2,darkColor,lightColor);
            ChangeButtonColors(ButtonTab3,darkColor,lightColor);
            ChangeButtonColors(ButtonTab4,darkColor,lightColor);
            ChangeButtonColors(ButtonTab5,darkColor,lightColor);
            ChangeButtonColors(ButtonTab6,darkColor,lightColor);

            MainGrid.Children.Clear();

             switch (index)
            {
                 case 1:
                    {
                        ZahtjevForm form = new ZahtjevForm();
                        MainGrid.Children.Add(form);          
                        break;
                    }
                    case 2:
                    {
                        MaterijalForm form = new MaterijalForm();
                        MainGrid.Children.Add(form);                        
                        break;
                    }
                    case 3:
                    {                       
                        RobaForm form = new RobaForm();
                        MainGrid.Children.Add(form);                        
                        break;
                    }
                    case 4:
                    {
                        StornirajForm form = new StornirajForm();
                        MainGrid.Children.Add(form);                        
                        break;
                    }
                    case 5:
                    {
                        NaloziForm form = new NaloziForm();
                        MainGrid.Children.Add(form);                        
                        break;
                    }
                    case 6:
                    {
                        NabavkaForm form = new NabavkaForm();
                        MainGrid.Children.Add(form);
                        break;
                    }

             }
            ChangeButtonColors(pressedButton,lightColor,darkColor);


        }

        private void ChangeButtonColors(Button button, string foreColor, string backColor)
        {
            BrushConverter bc = new BrushConverter(); 
            button.Background = (Brush)bc.ConvertFrom(backColor); 
            button.Foreground = (Brush)bc.ConvertFrom(foreColor); 
            

        }
    }
}
