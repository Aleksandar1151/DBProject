﻿using DBProject.Data;
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
    /// Interaction logic for NabavkaForm.xaml
    /// </summary>
    public partial class NabavkaForm : UserControl
    {
        public static ObservableCollection<Materijal> KolekcijaMaterijal { get;set;}
        public NabavkaForm()
        {
            InitializeComponent();

            KolekcijaMaterijal = Materijal.UcitajNabavku();
            NabavkaListView.ItemsSource = KolekcijaMaterijal;
        }
    }
}
