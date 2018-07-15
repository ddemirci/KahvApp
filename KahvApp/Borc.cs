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
    public partial class Borc : Form
    {
        public decimal Borç;
        public DateTime Date;
        private Form parent;
        private DatabaseOperations dbOper;

        public Borc(decimal borc, DateTime date, Form Parent)
        {
            this.Borç = borc;
            this.Date = date;
            this.parent = Parent;
            InitializeComponent();
            //this.button1.Enabled = false;
            this.button1.Click += new EventHandler(Tamam_Button_Clicked);
            //this.textBox1.LostFocus += new EventHandler(Textbox1_TextChanged);a
            dbOper = new DatabaseOperations();

        }

        public void Textbox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = !string.IsNullOrEmpty(textBox1.Text);
        }

        public void Tamam_Button_Clicked(object Sender, EventArgs e)
        {
            string Name = this.textBox1.Text.Split(' ')[0].ToString();
            string Surname = this.textBox1.Text.Split(' ')[1].ToString();

            //var splitted = this.textBox1.Text.Split(' ');
            //string Name = splitted[0];
            //string Surname = splitted[1];

            this.Close();

            Customer debtor = new Customer(Name, Surname, this.Borç, this.Date);

            string command = "insert into Borclular (Ad, Soyad, Tarih, Tutar) values ( @Ad, @Soyad, @Tarih, @Tutar)";
            SQLiteCommand Command = new SQLiteCommand(command);

            Command.Parameters.AddWithValue("@Ad", Name);
            Command.Parameters.AddWithValue("Soyad", Surname);
            Command.Parameters.AddWithValue("@Tarih", this.Date.ToShortDateString());
            Command.Parameters.AddWithValue("@Tutar", this.Borç);

            //Command.Parameters.Add("@Ad", DbType.String);
            //Command.Parameters["@Ad"].Value = Name;

            //Command.Parameters.Add("@Soyad", DbType.String);
            //Command.Parameters["@Soyad"].Value = Surname;

            //Command.Parameters.Add("@Tarih", DbType.String);
            //Command.Parameters["@Tarih"].Value = DateTime.Today.ToShortDateString();

            //Command.Parameters.Add("@Tutar", DbType.Decimal);
            //Command.Parameters["@Tutar"].Value = this.Borç;



            dbOper.ExecuteSqlQueryWithParameters(Command);

            (parent as Form1).borclular.Add(debtor); // Borçlu ekleme
        }
    }
}
