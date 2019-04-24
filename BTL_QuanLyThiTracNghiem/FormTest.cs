using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QuanLyThiTracNghiem
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          //  string x1 = textBox1.ToString();


            int result;
            string myString = textBox1.Text;
            if (Int32.TryParse(myString , out result))
            {
                label1.Text = "String is numeric";
                label2.Text = textBox1.Text;

            }
            else
            {
                label1.Text = "String isnot numeric";
            }
        }
    }
}
