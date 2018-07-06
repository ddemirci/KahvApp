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
    public partial class OdemeOnay : Form
    {
        public bool odendi;
        private string successMessage;
        private string failureMessage;
        private Form parent;
        private Form grandParent;
        private decimal tutar;

        public OdemeOnay(string Text, string Success, Form Parent, Form GrandParent, decimal Tutar)
        {
            InitializeComponent();
            this.parent = Parent;
            this.grandParent = GrandParent;
            this.successMessage = Success;
            this.tutar = Tutar;

            this.label1.Text = Text;
            label1.Show();

            this.button1.Click += new EventHandler(Odendi_Button_Clicked);
            this.button2.Click += new EventHandler(Borc_Button_Clicked);


        }

        public void Odendi_Button_Clicked(object Sender, EventArgs e)
        {
            this.odendi = true;
            MessageBox.Show(this.successMessage, "Ödeme gerçekleştirildi");

            (grandParent as Form1).fisler.Add(this.successMessage);
            (grandParent as Form1).hasılat += tutar;
        }

        public void Borc_Button_Clicked(object Sender, EventArgs e)
        {
            this.odendi = false;
            MessageBox.Show("Borcunuz kaydedildi.");

        }
    }
}