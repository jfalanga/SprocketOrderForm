using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprocketOrderForm
{
    class AluminumSprocket: Sprocket
    {
        public AluminumSprocket(): base()
        {

        }
        public AluminumSprocket(int itemID, int numItems, int numTeeth): 
            base(itemID,numItems,numTeeth)
        {

        }

        protected override void Calc()
        {
            Price = NumItems * NumTeeth * .04M;
        }

        public override string ToString()
        {
            return "Aluminum sprockets"+base.ToString();
        }
    }
}
