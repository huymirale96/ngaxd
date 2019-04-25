using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace BTL_QuanLyThiTracNghiem
{
    public partial class FormBaoCaoTopDiem1 : Form
    {
        public FormBaoCaoTopDiem1()
        {
            InitializeComponent();
           // public CrystalDecisions crystalReportViewer1;
        }


        private void FormBaoCaoTopDiem1_Load(object sender, EventArgs e)
        {
            
        }
         public void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            DataTable tbl;
            string cnnstr = ConfigurationManager.ConnectionStrings["test"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(cnnstr))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("topsinhvien_diem1", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        tbl = new DataTable();
                        da.Fill(tbl); 
                    }
                }
                cnn.Close();
            }

           // MessageBox.Show("Bạn có muốn thoát khỏi chương trình không ?", "Xác nhận", MessageBoxButtons.OK);
            BaoCaoTopDiem report = new BaoCaoTopDiem();
            report.SetDataSource(tbl);
            crystalReportViewer1.ReportSource = report;
        }
    }
}
