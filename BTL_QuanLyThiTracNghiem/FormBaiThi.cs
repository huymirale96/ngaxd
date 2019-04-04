using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BTL_QuanLyThiTracNghiem
{
    public partial class FormBaiThi : Form
    {
        string cnnstr = @"Data Source=DESKTOP-4TI11EU\SQLEXPRESS;Initial Catalog=quanLyThiTracNghiem;Integrated Security=True";
        public FormBaiThi()
        {
            InitializeComponent();
        }
        private void loadData()
        {
            using (SqlConnection conn = new SqlConnection(cnnstr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("thongTinBaiThi", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dap2 = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                dap2.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void FormBaiThi_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void aadataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String maBaiThi;
            maBaiThi = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            using (SqlConnection conn = new SqlConnection(cnnstr))
            {
                conn.Open();
                SqlCommand cmd1 = new SqlCommand("select * from tblChitietbaithi where smabaithi ='" + maBaiThi + "'", conn);
                cmd1.CommandType = CommandType.Text;
                SqlDataAdapter dap3 = new SqlDataAdapter(cmd1);
                DataTable table2 = new DataTable();
                dap3.Fill(table2);
                dataGridView2.DataSource = table2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cảnh Báo Xóa Toàn Bộ Bài Thi", "Warming", MessageBoxButtons.OKCancel);
            using (SqlConnection conn = new SqlConnection(cnnstr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("xoaBaiThi", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                int i = cmd.ExecuteNonQuery();
                if(i==1)
                {
                    MessageBox.Show("Đã Xóa Hết Bài Thi", "THông Báo", MessageBoxButtons.OK);
                }
            }
            loadData();
        }
    }
}
