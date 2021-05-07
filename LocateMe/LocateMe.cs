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
    public partial class labelLocateMe : Form
    {
        public labelLocateMe()
        {
            InitializeComponent();
                        
        }



        private void button1_Click(object sender, EventArgs e)
        {

            this.InitializeComponent();
        }

        private void labelLocateMe_Load(object sender, EventArgs e)
        {
            ExternalApi FreeApi = new ExternalApi();
            string result = FreeApi.Call();

            textBox1.Text = result;

            LocationData lc = new LocationData();
            lc.Parse(result);


            labelIp.Text = lc.Ip;
            labelCity.Text = lc.City;
            labelCountryName.Text = lc.CountryName;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
