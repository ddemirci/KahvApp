using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahvApp
{
    class Nescafe : Drink
    {
        public Nescafe(DrinkUnit Unit, int Count)
        {
            this.Name = "Nescafe";
            this.Unit = Unit;
            this.UnitPrice = Unit.Equals(DrinkUnit.Fincan) ? PriceList.FincanNescafe :
                                                             PriceList.KucukNescafe;
            this.Count = Count;
        }
    }
}
