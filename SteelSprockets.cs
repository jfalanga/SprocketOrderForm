using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprocketOrderForm
{
    public class SteelSprockets: Sprocket
    {
        //No further comments required!
        public SteelSprockets(): base()
        {

        }

        public SteelSprockets(int itemID, int numItems, int numTeeth) :
            base(itemID, numItems, numTeeth)
        {

        }

        protected override void Calc()
        {
            Price = .05M * NumItems * NumTeeth;
        }

        public override string ToString()
        {
            return "Steel Sprocket(s)" + base.ToString();
        }
    }
}
