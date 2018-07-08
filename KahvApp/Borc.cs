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
        private Form parent;
        public Borc(decimal borc, DateTime date, Form Parent)
        {
            this.Borç = borc;
            this.Date = date;
            this.parent = Parent;
            InitializeComponent();
            this.button1.Enabled = false;
            this.button1.Click += new EventHandler(Tamam_Button_Clicked);
            this.textBox1.LostFocus += new EventHandler(Textbox1_TextChanged);

         }

        public void Textbox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = !string.IsNullOrEmpty(textBox1.Text);
        }

        public void Tamam_Button_Clicked(object Sender, EventArgs e)
        {
            this.Close();
            string Name = this.textBox1.Text.Split(' ')[0].ToString();
            string Surname = this.textBox1.Text.Split(' ')[1].ToString();

            Customer debtor = new Customer(Name, Surname, this.Borç, this.Date);
            (parent as Form1).borclular.Add(debtor); // Borçlu ekleme
        }
    }
}
