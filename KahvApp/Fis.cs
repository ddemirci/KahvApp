using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KahvApp
{
    public partial class Fis : Form
    {
        private int tableNumber;
        private List<Product> productList;
        private decimal checkSum;

        public Fis(string TableNumber)
        {
            InitializeComponent();

            this.tableNumber = Convert.ToInt32(Regex.Replace(TableNumber, "[^0-9]", ""));
            this.textBox1.Text = this.tableNumber.ToString();
            this.textBox1.ReadOnly = true;
            comboBox2.Enabled = false;
            comboBox3.Hide();

            comboBox1.Items.Add("Küçük Çay");
            comboBox1.Items.Add("Büyük Çay");
            comboBox1.Items.Add("Türk Kahvesi");
            comboBox1.Items.Add("Küçük Nescafe");
            comboBox1.Items.Add("Fincan Nescafe");
            comboBox1.Items.Add("Soda");
            comboBox1.Items.Add("Kola");
            comboBox1.Items.Add("Sprite");
            comboBox1.Items.Add("Gazoz");
            comboBox1.Items.Add("Kaşarlı Tost");
            comboBox1.Items.Add("Karışık Tost");

            this.comboBox1.SelectedIndexChanged += 
                new System.EventHandler(comboBox1_SelectedIndexChanged);
        }

        private void comboBox1_SelectedIndexChanged(object Sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString().Trim().Equals("Kaşarlı Tost") ||
               comboBox1.SelectedItem.ToString().Trim().Equals("Karışık Tost"))
            {
                comboBox3.Items.Add("Çeyrek");
                comboBox3.Items.Add("Yarım");
                comboBox3.Items.Add("Tam");
                comboBox3.Show();
            }

            else
            {
                comboBox2.Items.Add(1);
                comboBox2.Items.Add(2);
                comboBox2.Items.Add(3);
                comboBox2.Items.Add(4);
                comboBox2.Items.Add(5);
                comboBox2.Items.Add(6);
                comboBox2.Items.Add(7);
                comboBox2.Items.Add(8);

                comboBox2.Enabled = true;
            }

            this.comboBox3.SelectedIndexChanged +=  new System.EventHandler(comboBox3_SelectedIndexChanged);
        }

        private void comboBox3_SelectedIndexChanged(object Sender, EventArgs e)
        {
            if(comboBox3.SelectedItem != null)
            {
                comboBox2.Items.Add(1);
                comboBox2.Items.Add(2);
                comboBox2.Items.Add(3);
                comboBox2.Items.Add(4);
                comboBox2.Items.Add(5);
                comboBox2.Items.Add(6);
                comboBox2.Items.Add(7);
                comboBox2.Items.Add(8);

                comboBox2.Enabled = true;
            }
        }

        

        //KucukCay = 
        //BuyukCay = 
        //TurkKahvesi
        //KucukNescaf
        //FincanNesca
        //Soda = 2;
        //Mesrubat = 
        //KasarliTost
        //KarisikTost
    }
}
