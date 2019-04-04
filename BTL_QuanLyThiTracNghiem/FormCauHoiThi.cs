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
    public partial class FormCauHoiThi : Form
    {
        string cnnstr = @"Data Source=DESKTOP-4TI11EU\SQLEXPRESS;Initial Catalog=quanLyThiTracNghiem;Integrated Security=True";
        public FormCauHoiThi()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void FormCauHoiThi_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            using (SqlConnection conn = new SqlConnection(cnnstr))
            {
                SqlDataAdapter dap = new SqlDataAdapter("select * from tblcauhoithi", conn);
                DataTable table = new DataTable();
                conn.Open();
                dap.Fill(table);
                dataGridView1.DataSource = table;
            }
            textBoxMCH.Text = "";
            textBoxDeBai.Text = "";
            textBoxA.Text = "";
            textBoxB.Text = "";
            textBoxC.Text = "";
            textBoxD.Text = "";
            checkBoxA.Checked = false;
            checkBoxB.Checked = false;
            checkBoxC.Checked = false;
            checkBoxD.Checked = false;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            checkBoxA.Checked = false;
            checkBoxB.Checked = false;
            checkBoxC.Checked = false;
            checkBoxD.Checked = false;
            textBoxMCH.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxDeBai.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxA.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxB.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBoxC.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBoxD.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            string dapAn_ = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            char[] mangDapAn = dapAn_.ToCharArray();
           
            for (int i = 0; i < mangDapAn.Length; i++)
            {
                if (mangDapAn[i] == 'A')
                    {
                    checkBoxA.Checked = true;
                }
                if (mangDapAn[i] == 'B')
                {
                    checkBoxB.Checked = true;
                }
                if (mangDapAn[i] == 'C')
                {
                    checkBoxC.Checked = true;
                }
                if (mangDapAn[i] == 'D')
                {
                    checkBoxD.Checked = true;
                }
            }


            //textBoxDapAn.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnXoaTrang_Click(object sender, EventArgs e)
        {
            textBoxMCH.Text = "";
            textBoxDeBai.Text = "";
            textBoxA.Text = "";
            textBoxB.Text = "";
            textBoxC.Text = "";
            textBoxD.Text = "";
            checkBoxA.Checked = false;
            checkBoxB.Checked = false;
            checkBoxC.Checked = false;
            checkBoxD.Checked = false;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(cnnstr))
            {
                SqlCommand cmd = new SqlCommand("delete from tblcauhoithi where imacauhoithi = '" + textBoxMCH.Text + "'",conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.ExecuteNonQuery();

            }
            loadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            bool x = true;
            using (SqlConnection conn = new SqlConnection(cnnstr))
            {
                // String query1 = "select * from tblSinhVien where smasinhvien = '" + textBoxTen + ' and smatkhau = ' + textBoxMK + "'";
                SqlDataAdapter dap = new SqlDataAdapter("select * from tblcauhoithi where imacauhoithi = '" + textBoxMCH.Text + "'", conn);
                DataTable table1 = new DataTable();
                conn.Open();
                dap.Fill(table1);
                if (table1.Rows.Count > 0)
                {
                    x = false;
                }

            }
            if (x)
            {
                String temp1 = "";
                if (checkBoxA.Checked == true)
                {
                    temp1 = temp1 + "A";
                }
                if (checkBoxB.Checked == true)
                {
                    temp1 = temp1 + "B";
                }
                if (checkBoxC.Checked == true)
                {
                    temp1 = temp1 + "C";
                }
                if (checkBoxD.Checked == true)
                {
                    temp1 = temp1 + "D";
                }
                using (SqlConnection conn = new SqlConnection(cnnstr))
                {
                    SqlCommand cmd = new SqlCommand("themCauHoiThi", conn);
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mch", textBoxMCH.Text);
                    cmd.Parameters.AddWithValue("@dethi", textBoxDeBai.Text);
                    cmd.Parameters.AddWithValue("@dapan1", textBoxA.Text);
                    cmd.Parameters.AddWithValue("@dapan2", textBoxB.Text);
                    cmd.Parameters.AddWithValue("@dapan3", textBoxC.Text);
                    cmd.Parameters.AddWithValue("@dapan4", textBoxD.Text);
                    cmd.Parameters.AddWithValue("@dapandung", temp1);
                    cmd.ExecuteNonQuery();
                }
                loadData();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            String temp1 = "";
            if (checkBoxA.Checked == true)
            {
                temp1 = temp1 + "A";
            }
            if (checkBoxB.Checked == true)
            {
                temp1 = temp1 + "B";
            }
            if (checkBoxC.Checked == true)
            {
                temp1 = temp1 + "C";
            }
            if (checkBoxD.Checked == true)
            {
                temp1 = temp1 + "D";
            }
            using (SqlConnection conn = new SqlConnection(cnnstr))
            {
                SqlCommand cmd = new SqlCommand("capNhatCauHoiThi", conn);
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mch", textBoxMCH.Text);
                cmd.Parameters.AddWithValue("@dethi", textBoxDeBai.Text);
                cmd.Parameters.AddWithValue("@dapan1", textBoxA.Text);
                cmd.Parameters.AddWithValue("@dapan2", textBoxB.Text);
                cmd.Parameters.AddWithValue("@dapan3", textBoxC.Text);
                cmd.Parameters.AddWithValue("@dapan4", textBoxD.Text);
                cmd.Parameters.AddWithValue("@dapandung", temp1);
                cmd.ExecuteNonQuery();
            }
            loadData();
        }
  }
}
