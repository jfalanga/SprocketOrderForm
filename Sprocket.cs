using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprocketOrderForm
{
    public abstract class Sprocket
    {
        private int numItems;
        private int numTeeth;
        private int itemID;

        public Sprocket(int itemID, int numItems, int numTeeth)
        {
            this.itemID = itemID;
            NumTeeth = numItems;
            NumItems = numItems;
        }

        public Sprocket(): this(0, 1, 1)
        {

        }
        

        public int NumItems
        {
            get
            {
                return numItems;
            }
            set
            {
                //I don't think you can have a NEGATIVE number of items!
                if (value>0)
                {
                    numItems = value;
                }
                Calc();
            }
        }

        public int NumTeeth
        {
            get
            {
                return numTeeth;

            }
            set
            {
                if (value >= 0)
                {
                    numTeeth = value;
                }
                Calc();
            }
        }

        
        public int ItemID
        {
            get
            {
                return itemID;
            }
        }
        
        //I didn't see a way- at least not a very GOOD way- of making Price
        //a read-only property... (The only way you COULD do it would be
        //to make a field variable that was proected, rather than private...
        //that's not good STYLE!)
        public decimal Price {  get; protected set; }

        protected abstract void Calc();

        public override string ToString()
        {
            //I add the Material Type in the subclasses
            string strung = ($"; order number {ItemID}, {NumItems} of them with {NumTeeth} teeth each");
            return strung + ($". It costs ${Price}");
        }


    }
}
