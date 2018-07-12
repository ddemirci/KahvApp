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
    public partial class OdemeOnay : Form
    {
        public bool odendi;
        private Form parent;
        private Form grandParent;
        private decimal tutar;
        private int masaNo;
        private int fisNo;
        private DatabaseOperations dbOper;

        public OdemeOnay(string Text, int FisNo, int MasaNo, Form Parent, Form GrandParent, decimal Tutar)
        {
            InitializeComponent();
            this.parent = Parent;
            this.grandParent = GrandParent;
            this.tutar = Tutar;
            this.fisNo = FisNo;
            this.masaNo = MasaNo;
            this.label1.Text = Text;
            label1.Show();

            this.button1.Click += new EventHandler(Odendi_Button_Clicked);
            this.button2.Click += new EventHandler(Borc_Button_Clicked);
            dbOper = new DatabaseOperations();

        }

        public void Odendi_Button_Clicked(object Sender, EventArgs e)
        {
            this.odendi = true;
            MessageBox.Show("Ödeme yapıldı", "Ödeme gerçekleştirildi");
            this.Close();

            //string success = "Fiş No: " + this.fisNo + ", Masa: "
            //   + tableNumber + ", Ödeme: " + checkSum + "TL, Tarih: " + DateTime.Now;
            string command = "insert into Odenen_Fisler (Tarih, Fis_No, Masa, Tutar) values (" + DateTime.Now.ToShortDateString() + ", " + this.fisNo + ", " + this.masaNo + ", " + this.tutar + ")";
            dbOper.ExecuteSqlQuery(command);

            //(grandParent as Form1).odenenFisler.Add(this.successMessage);
            //(grandParent as Form1).hasılat += tutar;
        }

        public void Borc_Button_Clicked(object Sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            this.odendi = false;
            MessageBox.Show("Borç", "Borcunuz kaydedildi.");
            this.Close();
            //(grandParent as Form1).odenmeyenFisler.Add(this.failureMessage);

            decimal tutar = (parent as Fis).checkSum;
            Borc b = new Borc(tutar, date, (grandParent as Form1));
            b.Show();

        }
    }
}