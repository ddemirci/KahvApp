using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahvApp
{
    class Tea : Drink
    {
        public Tea(DrinkUnit Unit)
        {
            this.Name = "Cay";
            this.Unit = Unit;
            this.UnitPrice = Unit.Equals(DrinkUnit.KucukBardak) ? PriceList.KucukCay :
                            /*Unit.Equals(DrinkUnit.BuyukBardak) ?*/ PriceList.BuyukCay;
        }
    }
}
