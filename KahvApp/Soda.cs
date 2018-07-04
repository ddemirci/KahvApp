using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahvApp
{
    class Soda : Drink
    {
        public Soda(DrinkUnit Unit, int Count)
        {
            this.Name = "Soda";
            this.Unit = Unit;
            this.UnitPrice = PriceList.Soda;
            this.Count = Count;
        }
    }
}
