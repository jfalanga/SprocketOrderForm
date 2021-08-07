using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprocketOrderForm
{
    //NFCM
    class SprocketOrder
    {
        private List<Sprocket> items;
        private decimal priceInTotal;

        public Adress Adress {get;set;}

        public string CustomerName { get; set; }

        public List<Sprocket> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
            }
        }

        public decimal TotalPrice
        {
            get
            {
                Calc();     //This will garantee that I get
                            //the right total price!
                return priceInTotal;
            }
            private set
            {
                priceInTotal = value;
            }
        }



        private void Calc()
        {
            decimal moneys = 0.0M;
            foreach (Sprocket sprocket in Items)
            {
                moneys += sprocket.Price;
            }
            TotalPrice = moneys;
        }

        public void Add(Sprocket spr)
        {
            items.Add(spr);
        }


        public void Remove(int ix)
        {
            items.RemoveAt(ix);
        }

        public SprocketOrder()
        {
            items = new List<Sprocket>();
        }
        
        public SprocketOrder(Adress adress, string customerName, List<Sprocket> sprockets, bool isLocal)
        {
            if (!isLocal)
            {
                Adress = adress;
            }
            
            this.CustomerName = customerName;
            Items = sprockets;

        }

        public override string ToString()
        {
            //Making a string for whether we have an adress or not
            string adressing;
            if (Adress == null)
            {
                adressing = "Local Pickup";
            }
            else
            {
                adressing = "Adress: " + Adress.ToString();
            }

            //So happens that we want the complete number of ITEMS- not of orders
            //(That's each individual sprocket, not each individual Sprocket instance!)
            int sprNum = 0;
            foreach (Sprocket item in items)
            {
                sprNum += item.NumItems;
            }
            string bean = $"{sprNum} Sprockets, at ${TotalPrice}, ";
            bean += $"to {CustomerName}. {adressing}.";
            return bean;
        }
    }
}
