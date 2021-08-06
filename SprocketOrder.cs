using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprocketOrderForm
{
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
                Calc();
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

        

        //I wanted to include a remove for particular sprockets-
        //but that'd mean making a Equals(obj)- and that obj is
        //too complicated for now!
        public void Remove(int ix)
        {
            items.RemoveAt(ix);
        }

        public SprocketOrder()
        {
            items = new List<Sprocket>();
        }
        
        public SprocketOrder(Adress adress, string name, List<Sprocket> sprockets, bool isLocal)
        {
            if (isLocal)
            {
                Adress = adress;
            }
            
            CustomerName = name;
            Items = sprockets;

        }

        public override string ToString()
        {
            string adressing;
            if (Adress == null)
            {
                adressing = "Local Pickup";
            }
            else
            {
                adressing = "Adress: " + Adress.ToString();
            }
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
