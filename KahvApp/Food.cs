using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahvApp
{
    enum FoodUnit
    {
        Ceyrek,
        Yarim,
        Tam
    };

    class Food : Product
    {
        public FoodUnit Unit;
    }
}
