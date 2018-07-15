using KahvApp.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KahvApp
{
    public partial class Form1 : Form
    {
        public decimal hasilat;
        public List<Customer> borclular = new List<Customer>();
        private Form parent;
        private DatabaseOperations dbOper;
        private DateTime date;
        public Form1(Form Parent)
        {
            InitializeComponent();
            hasilat = decimal.Zero;
            this.parent = Parent;
            dbOper = new DatabaseOperations();
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
            this.timer1.Tick += new EventHandler(timer1_Tick);
            this.TopLevel = true;

            date = DateTime.Today; /*("{}");*/
            label1.Text = String.Format("{0:dd/MM/yyyy ,dddd}", date);

        }

        private void timer1_Tick(object Sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void masa_click(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.Red;
            Fis f = new Fis((sender as Button).Name, this, (sender as Button));

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
            string today = DateTime.Today.ToShortDateString();

            // For grand total
            string commandForGrandTotal = "select sum(Tutar) from Odenen_Fisler where Tarih = @Today";
            SQLiteCommand GrandTotal = new SQLiteCommand(commandForGrandTotal);
            GrandTotal.Parameters.AddWithValue("@Today", today);

            var result = dbOper.ExecuteSqlQueryForResult(GrandTotal);
            this.hasilat = Convert.ToDecimal(result);

            //For the number of bills.
            string commandForNumOfBills = "select count(*) from Odenen_Fisler where Tarih = @Today";
            SQLiteCommand CommandForNumOfBills = new SQLiteCommand(commandForNumOfBills);
            CommandForNumOfBills.Parameters.AddWithValue("@Today", today);

            result = dbOper.ExecuteSqlQueryForResult(CommandForNumOfBills);
            int fisSayisi = Convert.ToInt32(result);


            //MessageBox.Show(DateTime.Today.ToShortDateString() + " tarihinde " + fisSayisi
            //                + " adet fişin toplamı " + hasilat + " TL");

            //string text = DateTime.Today.ToShortDateString() + " ==> " + hasilat + " TL.";


            //INSERT OR UPDATE

            string exist = "select * from Gunluk_Gelir_Listesi where Tarih = @Today";
            SQLiteCommand Exist = new SQLiteCommand(exist);
            Exist.Parameters.AddWithValue("@Today", today);

            string command;
            SQLiteCommand Command;
            var isExist = dbOper.ExecuteSqlQueryForResult(Exist);
            if (isExist == null) // insert
            {
                command = "insert into Gunluk_Gelir_Listesi (Tarih, Fiş_Sayısı, Toplam) values ( @Today, @FisSayisi, @Toplam)";
                Command = new SQLiteCommand(command);
                Command.Parameters.AddWithValue("@Today", today);
                Command.Parameters.AddWithValue("@FisSayisi", fisSayisi);
                Command.Parameters.AddWithValue("@Toplam", this.hasilat);

            }
            else
            {
                command = "update Gunluk_Gelir_Listesi set Toplam = @Toplam, Fiş_Sayısı = @FisSayisi where Tarih = @Today";
                Command = new SQLiteCommand(command);
                Command.Parameters.AddWithValue("@Toplam", this.hasilat);
                Command.Parameters.AddWithValue("@FisSayisi", fisSayisi);
                Command.Parameters.AddWithValue("@Today", today);
            }
                dbOper.ExecuteSqlQueryWithParameters(Command);
        }
        
    }
}
