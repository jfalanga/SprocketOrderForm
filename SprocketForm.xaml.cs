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
using System.Windows.Shapes;

namespace SprocketOrderForm
{
    /// <summary>
    /// Interaction logic for SprocketForm.xaml
    /// </summary>
    public partial class SprocketForm : Window
    {
        //THIS is this Window's Sprocket
        public Sprocket Sprocked;
        string shdBeInt;


        
        public SprocketForm() //: this(new SteelSprockets())
        {
            InitializeComponent();
        }

        public SprocketForm(Sprocket sprocket)
        { 
            
            Sprocked = sprocket;
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //Sprocket Sprocked; --keeping this here to show how I was
            //struggling with how to deal with how to get sprocket back to MainWindow!
            if (TxtID.Text == "") TxtID.Text = "0";
            switch (CmbType.Text)
            {
                case "":
                    MessageBox.Show("Please select something in Item Type");
                    return;
                case "Steel Sprockets":
                    Sprocked = new SteelSprockets(Int32.Parse(TxtID.Text),0,0);
                    break;
                case "Plastic Sprockets":
                    Sprocked = new PlasticSprockets(int.Parse(TxtID.Text), 0, 0);
                    break;
                case "Aluminum Sprockets":
                    Sprocked = new AluminumSprocket(Int32.Parse(TxtID.Text), 0, 0);
                    break;
                default:
                    throw new Exception("Combobox for Item Type has unexpected value!");
            }
            //this.Sprocked = Sprocked;

            //just make all those empty textboxes parsable!
            if (TxtNumOfStuff.Text == "")
            {
                TxtNumOfStuff.Text = "0";
            }
            if (TxtTeethNum.Text == "")
            {
                TxtTeethNum.Text = "0";
            }
            this.Sprocked.NumItems = int.Parse(TxtNumOfStuff.Text);
            this.Sprocked.NumTeeth = int.Parse(TxtTeethNum.Text);
            this.DialogResult = true;
            this.Close();
        }

        //This is NOT the best way of doing this- making a
        //string that can only look like an integer! But it works, so hey!
        //(Still not DRY enough!)
        public string StringIsIntOr_
        {
            get
            {
                return shdBeInt;
            }
            set
            {
                if (value == "")
                {
                    shdBeInt= "";
                    return;
                }
                int ix;
                if (Int32.TryParse(value, out ix))
                {
                    shdBeInt = value;
                } else
                {
                    shdBeInt = "";
                }
            }
        }
        private void TxtTeethNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            StringIsIntOr_ = TxtTeethNum.Text;
            TxtTeethNum.Text = StringIsIntOr_;
        }

        private void TxtNumOfStuff_TextChanged(object sender, TextChangedEventArgs e)
        {
            StringIsIntOr_ = TxtNumOfStuff.Text;
            TxtNumOfStuff.Text = StringIsIntOr_;
        }

        private void TxtID_Changed(object sender, TextChangedEventArgs e)
        {
            StringIsIntOr_ = TxtID.Text;
            TxtID.Text = StringIsIntOr_;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
