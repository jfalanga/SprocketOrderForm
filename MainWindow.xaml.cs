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

namespace SprocketOrderForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChkPickup_Checked(object sender, RoutedEventArgs e)
        {
            VisibleOrNot(Visibility.Hidden);
        }

        private void ChkPickup_Unchecked(object sender, RoutedEventArgs e)
        {
            VisibleOrNot(0);
        }

        private void VisibleOrNot(Visibility v)
        {
            LblStreet.Visibility = v;
            TxtStreet.Visibility = v;
            GrdComplicated1.Visibility = v;
            GrdComplicated2.Visibility = v;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            SprocketForm sfDebris = new SprocketForm();
            sfDebris.Show();
        }
    }
}
