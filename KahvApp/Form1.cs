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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
        }

        private void masa_click(object sender, EventArgs e)
        {

            throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
