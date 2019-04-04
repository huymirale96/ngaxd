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
    public partial class FormBaoCaoTopDiem : Form
    {
        public FormBaoCaoTopDiem()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(@"C:\Users\Huy dzz\documents\visual studio 2015\Projects\BTL_QuanLyThiTracNghiem\BTL_QuanLyThiTracNghiem\BaoCaoTopDiem.rpt");
            crystalReportViewer1.ReportSource = rd;

        }
    }
}
