using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahvApp
{
    enum DrinkUnit
    {
        KucukBardak,
        BuyukBardak,
        Fincan
    };
    class Drink : Product
    {
        public DrinkUnit Unit;
    }
}
