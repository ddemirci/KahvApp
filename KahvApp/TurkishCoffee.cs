using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahvApp
{
    class TurkishCoffee : Drink
    {
        public TurkishCoffee(DrinkUnit Unit, int Count)
        {
            this.Name = "Türk Kahvesi";
            this.Unit = Unit;
            this.UnitPrice = PriceList.TurkKahvesi;
            this.Count = Count;
        }
    }
}
