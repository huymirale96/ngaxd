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
            DataTable tbl;
            string cnnstr = ConfigurationManager.ConnectionStrings["test"].ConnectionString;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Phải Nhập Số Điểm Cận Dưới.", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                if(textBox2.Text == "")
                {
                    
                    using (SqlConnection cnn = new SqlConnection(cnnstr))
                    {
                        cnn.Open();
                        using (SqlCommand cmd = new SqlCommand("thongke_theodiem", cnn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@diemcao", 10);
                            cmd.Parameters.AddWithValue("@diemthap", textBox1.Text);
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                tbl = new DataTable();
                                da.Fill(tbl);
                            }
                        }
                        cnn.Close();
                    }

                    // MessageBox.Show("Bạn có muốn thoát khỏi chương trình không ?", "Xác nhận", MessageBoxButtons.OK);
                    BaoCaoTheoDiem report = new BaoCaoTheoDiem();
                    report.SetDataSource(tbl);
                    crystalReportViewer1.ReportSource = report;
                }
                else
                {
                    using (SqlConnection cnn = new SqlConnection(cnnstr))
                    {
                        cnn.Open();
                        using (SqlCommand cmd = new SqlCommand("thongke_theodiem", cnn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@diemcao",textBox2.Text);
                            cmd.Parameters.AddWithValue("@diemthap", textBox1.Text);
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                tbl = new DataTable();
                                da.Fill(tbl);
                            }
                        }
                        cnn.Close();
                    }

                    // MessageBox.Show("Bạn có muốn thoát khỏi chương trình không ?", "Xác nhận", MessageBoxButtons.OK);
                    BaoCaoTheoDiem report = new BaoCaoTheoDiem();
                    report.SetDataSource(tbl);
                    crystalReportViewer1.ReportSource = report;
                }
            }
        }

        private void FormBaoCaoTheoDiem_Load(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
