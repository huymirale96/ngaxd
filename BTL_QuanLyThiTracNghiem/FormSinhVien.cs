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
//sua tren git nga
//sua local1pok

namespace BTL_QuanLyThiTracNghiem
{
    public partial class FormSinhVien : Form
    {
        string cnnstr = @"Data Source=DESKTOP-4TI11EU\SQLEXPRESS;Initial Catalog=quanLyThiTracNghiem;Integrated Security=True";
        public FormSinhVien()
        {
            InitializeComponent();
            loadData();



        }
    private void loadData()
    {
        using (SqlConnection conn = new SqlConnection(cnnstr))
        {
            conn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("select * from tblsinhvien", conn);
            DataTable table = new DataTable();
            dap.Fill(table);
            dataGridView1.DataSource = table;
        }
            textBoxMSV.Text = "";
            textBoxMK.Text = "";
            textBoxNS.Text = "";
            textBoxQueQuan.Text = "";
            textBoxTen.Text = "";
    }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormSinhVien_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxMSV.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxTen.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxQueQuan.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxNS.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBoxMK.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxMSV.Text = "";
            textBoxTen.Text = "";
            textBoxQueQuan.Text = "";
            textBoxNS.Text = "";
            textBoxMK.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(cnnstr))
            {
                String query1 = "delete from tblSinhVien where smasinhvien = '"+textBoxMSV + "'";
                SqlCommand cmd = new SqlCommand(query1, conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if(i==0)
                {
                    MessageBox.Show("Xóa Thất Bại.", "Thông Báo", MessageBoxButtons.OK);
                }
                loadData();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxMSV.Text == "" || textBoxTen.Text == "" || textBoxQueQuan.Text == "" || textBoxMK.Text == "")
            {
                MessageBox.Show("Phải Nhập Đủ Thông Tin", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                if (kTraMsv())
                {
                    MessageBox.Show("MSV Phù Hợp", "Thông Báo");
                    using (SqlConnection conn = new SqlConnection(cnnstr))
                    {
                        SqlCommand cmd = new SqlCommand("themSinhVien", conn);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@msv", textBoxMSV.Text);
                        cmd.Parameters.AddWithValue("@ten", textBoxTen.Text);
                        cmd.Parameters.AddWithValue("@que", textBoxQueQuan.Text);
                        cmd.Parameters.AddWithValue("@ngaysinh", textBoxNS.Text);
                        cmd.Parameters.AddWithValue("@matkhau", textBoxMK.Text);
                        // cmd.Parameters.AddWithValue("@dapan4", textBoxD.Text);
                        //cmd.Parameters.AddWithValue("@dapandung", textBoxDeBai.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    MessageBox.Show("MSV k Phù Hợp", "Thông Báo");
                    
                }
            }
            loadData();
        }
        private bool kTraMsv()
        {
            using (SqlConnection conn = new SqlConnection(cnnstr))
            {
                String query1 = "select * from tblSinhVien where smasinhvien = '" + textBoxMSV.Text + "'";
             
                SqlDataAdapter dap = new SqlDataAdapter(query1, conn);
                DataTable table = new DataTable();
                conn.Open();
                dap.Fill(table);

                if (table.Rows.Count > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
             
            }
           
        }
        private void buttonSua_Click(object sender, EventArgs e)
        {
            if (textBoxMSV.Text == "" || textBoxTen.Text == "" || textBoxQueQuan.Text == "" || textBoxMK.Text == "")
            {
                MessageBox.Show("Phải Nhập Đủ Thông Tin", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                if (kTraMsv())
                {
                    
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(cnnstr))
                    {
                        SqlCommand cmd = new SqlCommand("suaSinhVien", conn);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@msv", textBoxMSV.Text);
                        cmd.Parameters.AddWithValue("@ten", textBoxTen.Text);
                        cmd.Parameters.AddWithValue("@que", textBoxQueQuan.Text);
                        cmd.Parameters.AddWithValue("@ngaysinh", textBoxNS.Text);
                        cmd.Parameters.AddWithValue("@matkhau", textBoxMK.Text);
                        // cmd.Parameters.AddWithValue("@dapan4", textBoxD.Text);
                        //cmd.Parameters.AddWithValue("@dapandung", textBoxDeBai.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            loadData();
        }
    }
}
