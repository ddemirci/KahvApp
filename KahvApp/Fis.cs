using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KahvApp
{
    public partial class Fis : Form
    {
        private int tableNumber;
        private List<string> productList;
        private decimal checkSum;

        public Fis(int TableNumber)
        {
            InitializeComponent();
        }
    }
}
