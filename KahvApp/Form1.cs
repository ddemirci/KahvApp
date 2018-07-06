﻿using System;
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
    public partial class Form1 : Form
    {
        public decimal hasılat;
        private List<Product> kasa = new List<Product>();
        public List<string> fisler = new List<string>();

        public Form1()
        {
            InitializeComponent();
            hasılat = decimal.Zero;
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
            this.TopLevel = true;
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
            MessageBox.Show(DateTime.Today + " tarihinde " + fisler.Count
                            + " adet fişin toplamı " + hasılat + " TL");
        }
    }
}
