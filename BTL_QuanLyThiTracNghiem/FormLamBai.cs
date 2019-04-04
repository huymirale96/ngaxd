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
    public partial class FormLamBai : Form
    {
        string cnnstr = @"Data Source=DESKTOP-4TI11EU\SQLEXPRESS;Initial Catalog=quanLyThiTracNghiem;Integrated Security=True";
        DataTable table3 = new DataTable();
        int stt = 0;
        public String maSV = "";
        public String tenSV = "";
        String dapAn;
        int diem = 0;
        String tenBaiThi = "";
        DateTime today = DateTime.Now;
        int maCauHoi;
        public FormLamBai()
        {
            InitializeComponent();
        }

        private void FormLamBai_Load(object sender, EventArgs e)
        {
            taoBaiThi();
            btnKT.Enabled = false;
            labelMSV.Text = maSV;
            labelSV.Text = tenSV;
            labelTG.Text = today.ToString();
            labelDiem.Text = "";
            using (SqlConnection conn = new SqlConnection(cnnstr))
            {
                conn.Open();
                SqlDataAdapter dap3 = new SqlDataAdapter("select top 10 * from tblcauhoithi order by newid()", conn);  
                dap3.Fill(table3);
                //labelDB.Text = 
                //DataRow row = table3.Rows[stt];
                maCauHoi = Int32.Parse(table3.Rows[stt]["iMaCauHoiThi"].ToString());
                labelDB.Text = table3.Rows[stt]["sdethi"].ToString();
                labelA.Text = table3.Rows[stt]["sdapan1"].ToString();
                labelB.Text = table3.Rows[stt]["sdapan2"].ToString();
                labelC.Text = table3.Rows[stt]["sdapan3"].ToString();
                labelD.Text = table3.Rows[stt]["sdapan4"].ToString();
                dapAn = table3.Rows[stt]["sdapandung"].ToString();
                labelCau.Text = "Câu "+(stt+1).ToString() + ":";
                //char[] array1 = { 's', 'a', 'm' };
                //char[] array2 = { 'a', 's', 'm' };
                //if (array1.SequenceEqual(array2))
                
                //if (.Contains(array1))
                //{
                //    //labelTG.Text = "dung";
                //}
            }
            using (SqlConnection conn = new SqlConnection(cnnstr))
            {
                // String query1 = "select * from tblSinhVien where smasinhvien = '" + textBoxTen + ' and smatkhau = ' + textBoxMK + "'";
                SqlDataAdapter dap = new SqlDataAdapter("select sMaGiangVien, stenGiangvien from tblgiangvien ", conn);
                DataTable table1 = new DataTable();
                conn.Open();
                dap.Fill(table1);
                comboBox1.DataSource = table1;
                comboBox1.DisplayMember = "stengiangvien";
                comboBox1.ValueMember = "smagiangvien";
            }
        }

       private void taoBaiThi()
        {
            
            tenBaiThi = "BT" + maSV;
            using (SqlConnection conn = new SqlConnection(cnnstr))
            {
                String query1 = "insert into tblbaithi values ('" + tenBaiThi + "','" + maSV + "','" + today.ToString() + "','" + "gv1" + "',"+ "0)";
                SqlCommand cmd = new SqlCommand(query1, conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.ExecuteNonQuery();
               
            }
        }

        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            //int n = dapAn.Length;
            //char[] mangDapAn = dapAn.ToCharArray();
            //for (int i = 0; i < n; i++)
            //{
            //   if (strArr[i] == )
            //}
            
            String temp = "";
            if(checkBoxA.Checked==true)
            {
                temp = temp + "A";
            }
            if (checkBoxB.Checked == true)
            {
                temp = temp + "B";
            }
            if (checkBoxC.Checked == true)
            {
                temp = temp + "C";
            }
            if (checkBoxD.Checked == true)
            {
                temp = temp + "D";
            }
           
            if(temp == dapAn)
            {
                diem++;
            }
            labelDiem.Text = diem.ToString();

            themChiTietBaiThi(tenBaiThi, maCauHoi, temp);
            if (stt <9)
            {
                stt++;
                maCauHoi = Int32.Parse(table3.Rows[stt]["iMaCauHoiThi"].ToString());
                labelDB.Text = table3.Rows[stt]["sdethi"].ToString();
                labelA.Text = table3.Rows[stt]["sdapan1"].ToString();
                labelB.Text = table3.Rows[stt]["sdapan2"].ToString();
                labelC.Text = table3.Rows[stt]["sdapan3"].ToString();
                labelD.Text = table3.Rows[stt]["sdapan4"].ToString();
                dapAn = table3.Rows[stt]["sdapandung"].ToString();
                labelCau.Text = "Câu :"+ (stt+1).ToString()+" :";
                //themChiTietBaiThi(tenBaiThi, maCauHoi, temp);
            }
            else
            {
                
                btnTiepTuc.Enabled= false;
                btnKT.Enabled = true;
            }
            
            checkBoxA.Checked = false;
            checkBoxB.Checked = false;
            checkBoxC.Checked = false;
            checkBoxD.Checked = false;

        }

        private void themChiTietBaiThi(String baiThi, int cauHoi,String cauTraLoi)
        {
            using (SqlConnection conn = new SqlConnection(cnnstr))
            {
                SqlCommand cmd = new SqlCommand("insert_chiTietBaiThi", conn);
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maBaiThi", baiThi);
                cmd.Parameters.AddWithValue("@maCauHoi", cauHoi);
                cmd.Parameters.AddWithValue("@cauTraloi", cauTraLoi);
              
                cmd.ExecuteNonQuery();
            }
        }
        private void btnKT_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection conn = new SqlConnection(cnnstr))
            {
                String query1 = "update tblbaithi set idiem = '" + diem.ToString() + "' , smagiangvien = '" + comboBox1.SelectedValue.ToString() + "' where smabaithi = '" + tenBaiThi + "'";
                SqlCommand cmd = new SqlCommand(query1, conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.ExecuteNonQuery();

            }
            MessageBox.Show("Điểm của bạn là: " + diem.ToString(), "Thông báo kết quả.", MessageBoxButtons.OK);
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void labelTG_Click(object sender, EventArgs e)
        {

        }

        private void labelMSV_Click(object sender, EventArgs e)
        {

        }
    }
    }
