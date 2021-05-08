using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LocateMe
{
    public partial class LocateMe : Form
    {
        public LocateMe()
        {
            InitializeComponent();
        }

        private void refresh()
        {
            refresh("");
        }

        private void refresh(string host)
        {
            string result = ExternalApi.Call(host);

            textBox1.Text = result;

            LocationData lc = new LocationData();
            lc.Parse(result);

            textBoxIP.Text = lc.Ip;         
            labelCity.Text = lc.City;
            labelCountryName.Text = lc.CountryName;
            button2.Visible = false;
        }


        private void LocateMe_Load(object sender, EventArgs e)
        {
            refresh();
            button1.Click += Button1_Click;
            textBoxIP.TextChanged += TextBoxIP_TextChanged;
        }

        private void TextBoxIP_TextChanged(object sender, EventArgs e)
        {
            button2.Visible = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxIP.Text))
                textBoxIP.Text = "N/A";
            else
            {
                refresh(textBoxIP.Text);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Point lastPoint;

        private void LocateMe_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void LocateMe_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
    }
}
