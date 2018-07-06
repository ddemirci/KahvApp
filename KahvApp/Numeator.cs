using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahvApp
{
    class Numerator
    {
        private int orderNo = 1;
        private int fisNo = 1;
        private static Numerator num;

        private Numerator()
        {

        }

        public int OrderNo()
        {
            return orderNo++;
        }

        public int FisNo()
        {
            return fisNo++;
        }

        public void ResetNumerator()
        {
            this.orderNo = 1;
        }

        public static Numerator GetInstance()
        {
            if (num == null)
                num = new Numerator();
            return num;
        }
    }
}
