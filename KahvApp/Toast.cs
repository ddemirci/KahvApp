using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahvApp
{
    enum ToastType
    {
        Kasarli,
        Karisik
    }

    class Toast : Food
    {
        ToastType Type;
        public Toast(FoodUnit Unit, ToastType Type)
        {
            this.Name = "Tost";
            this.Unit = Unit;
            this.Type = Type;
            decimal TypePrice = Type.Equals(ToastType.Kasarli) ? PriceList.KasarliTost :
                                                              PriceList.KarisikTost;
            this.UnitPrice = Unit.Equals(FoodUnit.Ceyrek) ? TypePrice / 4 :
                             Unit.Equals(FoodUnit.Yarim)  ? TypePrice / 2 :
                                                            TypePrice;
           
        }
    }
}
