using KahvApp.DAL;
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
    public partial class WelcomePage : Form
    {
        public List<string> GunlukGelirListesi = new List<string>();
        Form1 form;
        private DatabaseOperations dbOper;

        public WelcomePage()
        {
            InitializeComponent();
            label2.Text = DateTime.Today.ToShortDateString();
            this.button1.Click += new EventHandler(Masalar_Button_Click);
            this.button2.Click += new EventHandler(AylikGelir_Button_Click);
            this.button3.Click += new EventHandler(Borclular_Button_Click);
            form = new Form1(this);
            dbOper = new DatabaseOperations();
        }

        public void Masalar_Button_Click(object Sender, EventArgs e)
        {
            form.Show();
        }

        public void AylikGelir_Button_Click(object Sender, EventArgs e)
        {

        }

        public void Borclular_Button_Click(object Sender, EventArgs e)
        {
            BorcluListesi liste = new BorcluListesi();
            liste.Show();
        }

    }
}
