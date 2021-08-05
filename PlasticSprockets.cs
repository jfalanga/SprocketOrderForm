using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprocketOrderForm
{
    class PlasticSprockets: Sprocket
    {
        public PlasticSprockets(): base()
        {

        }

        public PlasticSprockets(int itemID, int numItems, int numTeeth) :
            base(itemID, numItems, numTeeth)
        {

        }
        protected override void Calc()
        {
            Price = .02M * NumItems * NumTeeth;
        }

        public override string ToString()
        {
            return "Plastic Sprocket(s)"+base.ToString();
        }
    }
}
