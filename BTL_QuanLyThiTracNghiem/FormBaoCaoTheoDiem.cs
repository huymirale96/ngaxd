using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
namespace BTL_QuanLyThiTracNghiem
{
    public partial class FormBaoCaoTheoDiem : Form
    {
        public FormBaoCaoTheoDiem()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Phải Nhập Số Điểm Cận Dưới.", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                if(textBox2.Text == "")
                {
                    ReportDocument rd = new ReportDocument();
                    //rd.Load(@"D:\BT1\Bt2mian\BTL_QuanLyThiTracNghiem\FormBaoCaoTopDiem.cs");
                    rd.Load(@"D:\Nga\BTL_QuanLyThiTracNghiem\BaoCaoTheoDiem.rpt");
                    rd.SetParameterValue("@diemThap", textBox1.Text);
                    rd.SetParameterValue("@diemCao", 10);
                    crystalReportViewer1.ReportSource = rd;
                }
                else
                {
                    ReportDocument rd = new ReportDocument();
                    rd.Load(@"D:\Nga\BTL_QuanLyThiTracNghiem\BaoCaoTheoDiem.rpt");
                    rd.SetParameterValue("@diemThap", textBox1.Text);
                    rd.SetParameterValue("@diemCao", textBox2.Text);
                    crystalReportViewer1.ReportSource = rd;
                }
            }
        }

        private void FormBaoCaoTheoDiem_Load(object sender, EventArgs e)
        {

        }
    }
}
