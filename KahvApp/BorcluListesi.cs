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
    public partial class BorcluListesi : Form
    {
        private DatabaseOperations dbOper;
        public BorcluListesi()
        {
            InitializeComponent();
            this.button1.Click += new EventHandler(borcluEkle_Button_Clicked);
            this.button2.Click += new EventHandler(borcuDegistir_Button_Clicked);
            this.button3.Click += new EventHandler(borcluSil_Button_Clicked);
            dbOper = new DatabaseOperations();
            showDebtorList();
            listView1.View = View.Details;
            //this.listView1.Show();
        }

        private void showDebtorList()
        {
            DataTable Borclular = dbOper.ExecuteSqlQueryToDataSet("select Ad, Soyad, Tarih, Tutar from Borclular");
            if (Borclular != null)
            {
                foreach (DataRow dataRow in Borclular.Rows)
                {
                    string[] arr = new string[4];
                    arr[0] = dataRow.ItemArray[0].ToString();
                    arr[1] = dataRow.ItemArray[1].ToString();
                    arr[2] = dataRow.ItemArray[2].ToString();
                    arr[3] = dataRow.ItemArray[3].ToString();

                    ListViewItem itm = new ListViewItem(arr);
                    this.listView1.Items.Add(itm);

                    //ListViewItem lvi = new ListViewItem(dataRow["Ad"].ToString());
                    //lvi.SubItems.Add(dataRow["Soyad"].ToString());
                    //lvi.SubItems.Add(dataRow["Tarih"].ToString());
                    //lvi.SubItems.Add(dataRow["Tutar"].ToString());
                    //this.listView1.Items.Add(lvi);
                }
            }

        }

        private void borcluEkle_Button_Clicked(object Sender, EventArgs e)
        {

        }

        private void borcuDegistir_Button_Clicked(object Sender, EventArgs e)
        {

        }

        private void borcluSil_Button_Clicked(object Sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Selected)
                {
                    string Name = item.SubItems[0].Text.ToString();
                    string Surname = item.SubItems[1].Text.ToString();
                    string Date = item.SubItems[2].Text.ToString();
                    decimal Amount = Convert.ToDecimal(item.SubItems[3].Text);

                    string command = "delete from Borclular where Ad = @Ad and Soyad = @Soyad and Tarih = @Tarih and Tutar = @Tutar";
                    SQLiteCommand Command = new SQLiteCommand(command);
                    Command.Parameters.AddWithValue("@Ad", Name);
                    Command.Parameters.AddWithValue("@Soyad", Surname);
                    Command.Parameters.AddWithValue("@Tarih", Date);
                    Command.Parameters.AddWithValue("@Tutar", Amount);

                    dbOper.ExecuteSqlQueryWithParameters(Command);
                    listView1.Items.Remove(item);
                    MessageBox.Show(Name + " " + Surname + " adlı müşteriye ait "
                        + Date + " tarihli " + Amount + " TL borç silinmiştir.");
                }
            }
        }
    }
}
