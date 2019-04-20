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
using System.Configuration;

namespace BTL_QuanLyThiTracNghiem
{
    public delegate void DataSent(String msg1, String msg2, String msg3);
    public partial class Form1 : Form
    {
        //string cnnstr = @"Data Source=DESKTOP-4TI11EU\SQLEXPRESS;Initial Catalog=quanLyThiTracNghiem;Integrated Security=True";
        string cnnstr = ConfigurationManager.ConnectionStrings["test"].ConnectionString;
        public event DataSent dataSent;

        //this.dataSent();
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_MouseClick(object sender, MouseEventArgs e)
        {
            //using (SqlConnection conn = new SqlConnection(cnnstr))
            //{
            //    // String query1 = "select * from tblSinhVien where smasinhvien = '" + textBoxTen + ' and smatkhau = ' + textBoxMK + "'";
            //    SqlDataAdapter dap = new SqlDataAdapter("select * from tblSinhVien where smasinhvien = '" + textBoxTen + "' and smatkhau = '" + textBoxMK + "'", conn);
            //    DataTable table = new DataTable();
            //    conn.Open();
            //    dap.Fill(table);
            //    if (table.Rows.Count > 0)
            //    {
            //        MessageBox.Show("Tai Khoan Dung.", "Thong Bao Loi", MessageBoxButtons.OK);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Tai Khoan Khong Phu Hop.", "Thong Bao Loi", MessageBoxButtons.OK);
            //    }

            //}
        }

        private bool ktra()
        {
            bool x = true;
            using (SqlConnection conn = new SqlConnection(cnnstr))
            {
                // String query1 = "select * from tblSinhVien where smasinhvien = '" + textBoxTen + ' and smatkhau = ' + textBoxMK + "'";
                SqlDataAdapter dap = new SqlDataAdapter("select * from tblbaithi where smasinhvien = '" + textBoxTen.Text + "'", conn);
                DataTable table1 = new DataTable();
                conn.Open();
                dap.Fill(table1);
                if (table1.Rows.Count > 0)
                {
                    x = false;
                }
                
            }
            return x;
        }

        private void btn_Click(object sender, EventArgs e)
        {







            if (textBoxTen.Text == "admin" && textBoxMK.Text == "admin")
            {
                this.Close();
                // FormChinh f = this.MdiParent as FormChinh;
                //f.setNut();
                // ((FormChinh)this.MdiParent).setNut();
               this.dataSent("","","admin");
            }
            else
            {
                if (ktra())
                //MessageBox.Show("Tai Khoan" + textBoxMK.Text + textBoxTen.Text, "Thong Bao Loi", MessageBoxButtons.OK);
                {
                    using (SqlConnection conn = new SqlConnection(cnnstr))
                    {
                        // String query1 = "select * from tblSinhVien where smasinhvien = '" + textBoxTen + ' and smatkhau = ' + textBoxMK + "'";
                        SqlDataAdapter dap = new SqlDataAdapter("select * from tblSinhVien where smasinhvien = '" + textBoxTen.Text + "' and smatkhau = '" + textBoxMK.Text + "'", conn);
                        DataTable table1 = new DataTable();
                        conn.Open();
                        dap.Fill(table1);
                        if (table1.Rows.Count > 0)
                        {
                            MessageBox.Show("Tai Khoan Dung.", "Thong Bao Loi", MessageBoxButtons.OK);
                            //FormLamBai fr = new FormLamBai();
                            String ten = table1.Rows[0]["stensinhvien"].ToString();
                            String msv = textBoxTen.Text.ToString();
                            this.dataSent(msv, ten , "sv");
                          ///  fr.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Tai Khoan Khong Phu Hop.", "Thong Bao Loi", MessageBoxButtons.OK);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Sinh Vien Da Lam Bai Thi.", "Thong Bao Loi", MessageBoxButtons.OK);
                }
            }
            /////////
        }
    }
}
