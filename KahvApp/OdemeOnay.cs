using KahvApp.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
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
            
            string command = "insert into Odenen_Fisler (Tarih, Fis_No, Masa, Tutar) values ( @Date, @FisNo, @MasaNo, @Tutar)";
            SQLiteCommand Command = new SQLiteCommand(command);
            Command.Parameters.Add("@Date", DbType.String);
            Command.Parameters["@Date"].Value = DateTime.Today.ToShortDateString();

            Command.Parameters.Add("@FisNo", DbType.Int32);
            Command.Parameters["@FisNo"].Value = this.fisNo;

            Command.Parameters.Add("@MasaNo", DbType.Int32);
            Command.Parameters["@MasaNo"].Value = this.masaNo;

            Command.Parameters.Add("@Tutar", DbType.Decimal);
            Command.Parameters["@Tutar"].Value = this.tutar;

            dbOper.ExecuteSqlQueryWithParameters(Command);

            this.Close();
        }

        public void Borc_Button_Clicked(object Sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            this.odendi = false;

            string command = "insert into Odenmeyen_Fisler (Tarih, Fis_No, Masa, Tutar) values ( @Date, @FisNo, @MasaNo, @Tutar)";

            SQLiteCommand Command = new SQLiteCommand(command);
            Command.Parameters.Add("@Date", DbType.String);
            Command.Parameters["@Date"].Value = date.ToShortDateString();

            Command.Parameters.Add("@FisNo", DbType.Int32);
            Command.Parameters["@FisNo"].Value = this.fisNo;

            Command.Parameters.Add("@MasaNo", DbType.Int32);
            Command.Parameters["@MasaNo"].Value = this.masaNo;

            Command.Parameters.Add("@Tutar", DbType.Decimal);
            Command.Parameters["@Tutar"].Value = this.tutar;

            dbOper.ExecuteSqlQueryWithParameters(Command);
            this.Close();

            decimal tutar = (parent as Fis).checkSum;
            Borc b = new Borc(tutar, date, (grandParent as Form1));
            b.Show();

        }
    }
}