using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahvApp
{
    enum SoftDrinkType
    {
        Kola,
        Fanta,
        Gazoz,
        LimonluSoda,
        Ayran
    };
    
    //Mesrubat
    class SoftDrink : Drink
    {
        public SoftDrink(SoftDrinkType DrinkName)
        {
            this.Name = DrinkName.ToString();
            this.Unit = DrinkName.Equals(SoftDrinkType.Ayran) ? DrinkUnit.Kutu :
                                                                DrinkUnit.Sise;
            this.UnitPrice = PriceList.Mesrubat;
        }                       
    }
}
