using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KahvApp
{

    public class TableHistory
    {
        public int MasaNo;
        public bool MasaAktif;
        public decimal Bakiye;
        public int FisNo;
        public List<ListViewItem> Urunler;

        public TableHistory(int masaNo, decimal bakiye, int fisNo, List<ListViewItem> urunler )
        {
            this.MasaAktif = true;
            this.MasaNo = masaNo;
            this.Bakiye = bakiye;
            this.FisNo = fisNo;
            this.Urunler = urunler;
        }

    }

    public class TableContainer
    {
        public static List<TableHistory> TumFisler;

        private TableContainer()
        {

        }

        public static List<TableHistory> GetInstance()
        {
            if (TumFisler == null)
                TumFisler =new List<TableHistory>();
            return TumFisler;
        }
            
    }
}
