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
    public partial class Borc : Form
    {
        public decimal Borç;
        public DateTime Date;

        public Borc(decimal borc, DateTime date)
        {
            this.Borç = borc;
            this.Date = date;
            InitializeComponent();
            this.button1.Enabled = false;
        }

        public void Tamam_Button_Clicked()
        {
            string Name = this.textBox1.Text.Split(' ')[0].ToString();
            string Surname = this.textBox1.Text.Split(' ')[1].ToString();

            Customer debtor = new Customer(Name, Surname, this.Borç, this.Date);
            
        }
    }
}
