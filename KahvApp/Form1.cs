using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KahvApp
{
    public partial class Form1 : Form
    {
        public decimal hasılat;
        public List<string> odenenFisler = new List<string>();
        public List<string> odenmeyenFisler = new List<string>();
        public List<Customer> borclular = new List<Customer>();
        private Form parent;
        public SQLiteConnection KahvAppDBConnection;

        public Form1(Form Parent)
        {
            InitializeComponent();
            hasılat = decimal.Zero;
            this.parent = Parent;
            this.masa1.Click += new EventHandler(masa_click);
            this.masa2.Click += new EventHandler(masa_click);
            this.masa3.Click += new EventHandler(masa_click);
            this.masa4.Click += new EventHandler(masa_click);
            this.masa5.Click += new EventHandler(masa_click);
            this.masa6.Click += new EventHandler(masa_click);
            this.masa7.Click += new EventHandler(masa_click);
            this.masa8.Click += new EventHandler(masa_click);
            this.masa9.Click += new EventHandler(masa_click);
            this.masa10.Click += new EventHandler(masa_click);
            this.masa11.Click += new EventHandler(masa_click);
            this.masa12.Click += new EventHandler(masa_click);
            this.masa13.Click += new EventHandler(masa_click);
            this.masa14.Click += new EventHandler(masa_click);
            this.masa15.Click += new EventHandler(masa_click);
            this.masa16.Click += new EventHandler(masa_click);
            this.masa17.Click += new EventHandler(masa_click);
            this.button1.Click += new EventHandler(GunsonuAl_Button_Clicked);
            this.TopLevel = true;
            ConnectToDatabase();
            CreateTables();
        }

        private void masa_click(object sender, EventArgs e)
        {
            Fis f = new Fis((sender as Button).Name, this);
            //f.TopLevel = false;
            //this.Controls.Add(f);
            f.Show();



            //throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void GunsonuAl_Button_Clicked(object Sender, EventArgs e)
        {
            MessageBox.Show(DateTime.Today.ToShortDateString() + " tarihinde " + odenenFisler.Count
                            + " adet fişin toplamı " + hasılat + " TL");

            string text = DateTime.Today.ToShortDateString() + " ==> " + hasılat + " TL.";

            //DB Deneme
            SQLiteCommand command = new SQLiteCommand(KahvAppDBConnection);
            DateTime date = DateTime.Today;
            int fisSayisi = odenenFisler.Count;
            decimal para = hasılat;
            //string commandText = "insert into `Gunluk Gelir Listesi` (Tarih, `Fiş Sayısı`, Toplam) values (@date, @fisSayisi, @para)";
            command.CommandText = "insert into `Gunluk Gelir Listesi` (Tarih, `Fiş Sayısı`, Toplam) values (@date, @fisSayisi, @para)";
            command.Parameters.Add(new SQLiteParameter("@date", date));
            command.Parameters.Add(new SQLiteParameter("@fisSayisi", fisSayisi));
            command.Parameters.Add(new SQLiteParameter("@para", para));
            //SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            (parent as WelcomePage).GunlukGelirListesi.Add(text);
        }

        public void ConnectToDatabase()
        {
            KahvAppDBConnection = new SQLiteConnection("Data Source=KahvAppDatabase.sqlite;Version=3;");
            KahvAppDBConnection.Open();
        }

        public void CreateTables()
        {
            string sql = "create table `Gunluk Gelir Listesi` (Tarih date, `Fiş Sayısı` int, Toplam decimal(6,3))";
            SQLiteCommand command = new SQLiteCommand(sql, KahvAppDBConnection);
            command.ExecuteNonQuery();

            //public List<string> odenenFisler = new List<string>();
            //string success = " ", Masa: "
            //    + tableNumber + ", Ödeme: " + checkSum + "TL, 

            sql = "create table `Odenen Fisler` (Tarih date, `Fiş No` int, Masa int, Tutar decimal(6,3))";
            command = new SQLiteCommand(sql, KahvAppDBConnection);
            command.ExecuteNonQuery();

            //public List<string> odenmeyenFisler = new List<string>();
            //string failure = "Fiş No: " + this.fisNo + ", Masa: "
            //    + tableNumber + ", Ödeme: " + checkSum + "TL YAPILMAMIŞTIR, Tarih: " + DateTime.Now;

            sql = "create table `Odenmeyen Fisler` (Tarih date, `Fiş No` int, Masa int, Tutar decimal(6,3))";
            command = new SQLiteCommand(sql, KahvAppDBConnection);
            command.ExecuteNonQuery();


            //public List<Customer> borclular = new List<Customer>();
            //Customer debtor = new Customer(Name, Surname, this.Borç, this.Date);
            //(parent as Form1).borclular.Add(debtor); // Borçlu ekleme

            sql = "create table `Borclular` (Ad varchar(20), Soyad varchar(20), Tarih date,  Tutar decimal(6,3))";
            command = new SQLiteCommand(sql, KahvAppDBConnection);
            command.ExecuteNonQuery();
        }
    }
}
