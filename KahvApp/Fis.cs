using KahvApp.DAL;
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
        private int fisNo;
        private List<Product> productList;
        public decimal checkSum;
        private Form parent;
        

        public Fis(string TableNumber, Form Parent)
        {
            InitializeComponent();

            this.parent = Parent;
            this.tableNumber = Convert.ToInt32(Regex.Replace(TableNumber, "[^0-9]", ""));

           
            #region FisInit
            comboBox1.Items.Add("Küçük Çay");
            comboBox1.Items.Add("Büyük Çay");
            comboBox1.Items.Add("Türk Kahvesi");
            comboBox1.Items.Add("Küçük Nescafe");
            comboBox1.Items.Add("Fincan Nescafe");
            comboBox1.Items.Add("Soda");
            comboBox1.Items.Add("Kola");
            comboBox1.Items.Add("Fanta");
            comboBox1.Items.Add("Sprite");
            comboBox1.Items.Add("Gazoz");
            comboBox1.Items.Add("Limonlu Soda");
            comboBox1.Items.Add("Ayran");
            comboBox1.Items.Add("Kaşarlı Tost");
            comboBox1.Items.Add("Karışık Tost");

            comboBox2.Items.Add(1);
            comboBox2.Items.Add(2);
            comboBox2.Items.Add(3);
            comboBox2.Items.Add(4);
            comboBox2.Items.Add(5);
            comboBox2.Items.Add(6);
            comboBox2.Items.Add(7);
            comboBox2.Items.Add(8);

            comboBox3.Items.Add("Çeyrek");
            comboBox3.Items.Add("Yarım");
            comboBox3.Items.Add("Tam");
            #endregion

            #region ButtonAndTextBoxInit

            this.textBox1.Text = this.tableNumber.ToString();
            this.textBox1.ReadOnly = true;
            this.textBox3.ReadOnly = true;
            comboBox2.Enabled = false;
            comboBox3.Hide();

            this.button1.Enabled = false;  //Ekle butonu
            this.button2.Enabled = false;  //Sil butonu


            this.button1.Click += new System.EventHandler(Ekle_Button_Click);
            this.button2.Click += new System.EventHandler(Sil_Button_Click);
            this.button3.Click += new System.EventHandler(FisiKes_Button_Clicked);

            this.comboBox1.SelectedIndexChanged += new System.EventHandler(ComboBox1_SelectedIndexChanged);
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(ComboBox2_SelectedIndexChanged);
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(ComboBox3_SelectedIndexChanged);
            this.FormClosing += Fis_FormClosing;

            listView1.View = View.Details;
            listView1.Columns[1].Width = 150; // Ürün adı sütunu
            #endregion

            
            var exist = TableContainer.GetInstance().Where(x => x.MasaNo == this.tableNumber && x.MasaAktif == true).FirstOrDefault();
            //Masa Dolu
            if (exist != null)
            {
                this.fisNo = exist.FisNo;

                foreach (ListViewItem itm in exist.Urunler)
                {
                    listView1.Items.Add(itm);
                }

                this.checkSum = exist.Bakiye;
                textBox2.Text = checkSum.ToString();
            }
            else
            {

                fisNo = Numerator.GetInstance().FisNo();
                Numerator.GetInstance().ResetNumerator(); //sıra Numeratörünü başa döndür.
            }

            this.textBox3.Text = fisNo.ToString();
        }

        private void ComboBox1_SelectedIndexChanged(object Sender, EventArgs e)
        {
            AddButtonAvailability();

            if (comboBox1.SelectedItem.ToString().Trim().Equals("Kaşarlı Tost") ||
               comboBox1.SelectedItem.ToString().Trim().Equals("Karışık Tost"))
            {
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                comboBox3.Show();
            }

            else
            {
                comboBox2.Enabled = true;
                comboBox2.SelectedIndex = -1;
                comboBox3.Hide();
            }

        }

        private void ComboBox3_SelectedIndexChanged(object Sender, EventArgs e)
        {
            AddButtonAvailability();

            if (comboBox3.SelectedItem != null)
            {
                comboBox2.Enabled = true;
            }

        }

        private void ComboBox2_SelectedIndexChanged(object Sender, EventArgs e)
        {
            AddButtonAvailability();
        }

        public void AddButtonAvailability()
        {
            if ((comboBox2.SelectedIndex == -1) || (comboBox1.SelectedItem.ToString().Trim().Equals("Kaşarlı Tost") ||
                                                         comboBox1.SelectedItem.ToString().Trim().Equals("Karışık Tost")) && comboBox3.SelectedIndex == -1)
                button1.Enabled = false;
            else
                button1.Enabled = true;
        }

        public void Ekle_Button_Click(object Sender, EventArgs e)
        {

            try
            {
                string[] arr = new string[5];
                ListViewItem itm;
                arr[0] = Numerator.GetInstance().OrderNo().ToString();

                string product = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
                arr[1] = product;
                int count = Convert.ToInt32(this.comboBox2.GetItemText(this.comboBox2.SelectedItem));
                if (product.Equals("Küçük Çay"))
                {
                    Tea tea = new Tea(DrinkUnit.KucukBardak, count);
                    arr[2] = tea.UnitPrice.ToString();
                    arr[3] = count.ToString();
                    arr[4] = (tea.UnitPrice * count).ToString();
                }
                else if (product.Equals("Büyük Çay"))
                {
                    Tea tea = new Tea(DrinkUnit.BuyukBardak, count);
                    arr[2] = tea.UnitPrice.ToString();
                    arr[3] = count.ToString();
                    arr[4] = (tea.UnitPrice * count).ToString();
                }
                else if (product.Equals("Türk Kahvesi"))
                {
                    TurkishCoffee turkishCoffee = new TurkishCoffee(DrinkUnit.Fincan, count);
                    arr[2] = turkishCoffee.UnitPrice.ToString();
                    arr[3] = count.ToString();
                    arr[4] = (turkishCoffee.UnitPrice * count).ToString();
                }

                else if (product.Equals("Küçük Nescafe"))
                {
                    Nescafe nescafe = new Nescafe(DrinkUnit.KucukBardak, count);
                    arr[2] = nescafe.UnitPrice.ToString();
                    arr[3] = count.ToString();
                    arr[4] = (nescafe.UnitPrice * count).ToString();
                }
                else if (product.Equals("Fincan Nescafe"))
                {
                    Nescafe nescafe = new Nescafe(DrinkUnit.Fincan, count);
                    arr[2] = nescafe.UnitPrice.ToString();
                    arr[3] = count.ToString();
                    arr[4] = (nescafe.UnitPrice * count).ToString();
                }
                else if (product.Equals("Soda"))
                {
                    Soda soda = new Soda(DrinkUnit.Sise, count);
                    arr[2] = soda.UnitPrice.ToString();
                    arr[3] = count.ToString();
                    arr[4] = (soda.UnitPrice * count).ToString();
                }
                else if (product.Equals("Kola") ||
                    product.Equals("Fanta") ||
                    product.Equals("Sprite") ||
                    product.Equals("Gazoz") ||
                    product.Equals("Limonlu Soda") ||
                    product.Equals("Ayran"))
                {
                    SoftDrinkType type = product.Equals("Kola") ? SoftDrinkType.Kola :
                                         product.Equals("Fanta") ? SoftDrinkType.Fanta :
                                         product.Equals("Sprite") ? SoftDrinkType.Sprite :
                                         product.Equals("Gazoz") ? SoftDrinkType.Gazoz :
                                         product.Equals("Limonlu Soda") ? SoftDrinkType.LimonluSoda :
                                                                          SoftDrinkType.Ayran;

                    SoftDrink mesrubat = new SoftDrink(type, count);
                    arr[2] = mesrubat.UnitPrice.ToString();
                    arr[3] = count.ToString();
                    arr[4] = (mesrubat.UnitPrice * count).ToString();
                }

                else if (product.Equals("Kaşarlı Tost") || product.Equals("Karışık Tost"))
                {
                    FoodUnit unit = comboBox3.GetItemText(this.comboBox3.SelectedItem)
                                             .Equals("Çeyrek") ? FoodUnit.Ceyrek :
                                    comboBox3.GetItemText(this.comboBox3.SelectedItem)
                                             .Equals("Yarım") ? FoodUnit.Yarim :
                                                                FoodUnit.Tam;

                    ToastType type = comboBox1.GetItemText(this.comboBox1.SelectedItem)
                                              .Equals("Kaşarlı Tost") ? ToastType.Kasarli :
                                                                        ToastType.Karisik;
                    Toast tost = new Toast(unit, type, count);
                    arr[1] = unit + "  " + product;
                    arr[2] = tost.UnitPrice.ToString();
                    arr[3] = count.ToString();
                    arr[4] = (tost.UnitPrice * count).ToString();

                }
                else
                {

                }
                checkSum += Convert.ToDecimal(arr[4]);
                textBox2.Text = checkSum.ToString();
                itm = new ListViewItem(arr);
                listView1.Items.Add(itm);
                
                this.button2.Enabled = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Fis_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown)
            {

            }
            else if (e.CloseReason == CloseReason.UserClosing)
            {
                //Varolan fişi ekle
                List<ListViewItem> urunler = new List<ListViewItem>();
                foreach(ListViewItem itm in listView1.Items)
                {
                    urunler.Add(itm);
                }

                TableHistory Hist = new TableHistory(this.tableNumber, this.checkSum, this.fisNo, urunler);
                TableContainer.GetInstance().Add(Hist);
            }
        }
        public void Sil_Button_Click(object Sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Selected)
                {
                    checkSum -= Convert.ToDecimal(item.SubItems[4].Text);
                    textBox2.Text = checkSum.ToString();
                    listView1.Items.Remove(item);
                }
            }

            if (listView1.Items.Count == 0) button2.Enabled = false;
        }

        public void FisiKes_Button_Clicked(object Sender, EventArgs e)
        {
            this.button1.Enabled = false;
            this.button2.Enabled = false;
            this.button3.Enabled = false;

            string info = "Ödemeniz " + checkSum + " TL.";
            string success = "Fiş No: " + this.fisNo + ", Masa: "
                + tableNumber + ", Ödeme: " + checkSum + "TL, Tarih: " + DateTime.Now;

            string failure = "Fiş No: " + this.fisNo + ", Masa: "
                + tableNumber + ", Ödeme: " + checkSum + "TL YAPILMAMIŞTIR, Tarih: " + DateTime.Now;

            var exist = TableContainer.GetInstance().Where(x => x.MasaNo == this.tableNumber && x.MasaAktif == true).FirstOrDefault();

            //var control1 = TableContainer.GetInstance();
            //Listeden çıkarılma
            if (exist != null)
                TableContainer.GetInstance().Remove(exist);

            //var control2 = TableContainer.GetInstance();
            this.Close();
            OdemeOnay onay = new OdemeOnay(info, this.fisNo,this.tableNumber, this, parent, checkSum);
            onay.Show();
        }


    }
}

