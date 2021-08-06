using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
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
        List<Sprocket> sprockets;
        public MainWindow()
        {
            InitializeComponent();
            sprockets = new List<Sprocket>();
            LstItems.ItemsSource = sprockets;
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
            //Sprocket sprack = null;
            SprocketForm formal = new SprocketForm();
            formal.ShowDialog();
            Sprocket sprack = formal.Sprocked;
            sprockets.Add(sprack);
            LstItems.Items.Refresh();
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            DialogResult yesOrNo= System.Windows.Forms.MessageBox.Show($"Are you sure you really want to remove the following item:\n{LstItems.SelectedItem.ToString()}?",
                "You sure?", (MessageBoxButtons)MessageBoxButton.YesNo);
            if (yesOrNo == System.Windows.Forms.DialogResult.Yes)
            {
                int ix = LstItems.SelectedIndex;
                sprockets.RemoveAt(ix);
                LstItems.Items.Refresh();
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
