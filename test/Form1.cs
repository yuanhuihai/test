using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using comWithPlc;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        getPlcValues opplc = new getPlcValues();

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = opplc.readPlcDbwValue("10.228.140.46", 0, 3, 298, 2).ToString();
            textBox2.Text = opplc.readPlcDbdValue("10.228.140.46", 0, 3, 298, 4).ToString();

        }
    }
}
