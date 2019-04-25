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
    public partial class FormChinh : Form
    {
        string tenSV, maSV;
        public FormChinh()
        {
            InitializeComponent();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 formDN = new Form1();
            formDN.dataSent += trangThai;
            formDN.MdiParent = this;
            formDN.Show();
        }
        private void trangThai(string sMSV, string stenSV, string quyen)
        {
            //label1.Text = sMSV;
            tenSV = stenSV;
            maSV = sMSV;
            if (quyen == "admin")
                {
                giaoDienAdmin();
                }
            else
            {
                giaoDienSV();
            }

        }
        private void FormChinh_Load(object sender, EventArgs e)
        {
            quảnLýBàiThiToolStripMenuItem.Enabled = false;
            quảnLýCâuHỏiThiToolStripMenuItem.Enabled = false;
            quảnLýSinhViênToolStripMenuItem1.Enabled = false;
            làmBàiThiTrắcNghiệmToolStripMenuItem.Enabled = false;
            toolStripMenuItem1.Enabled = false;
        }
        public void giaoDienAdmin()
        {
            quảnLýBàiThiToolStripMenuItem.Enabled = true;
            quảnLýCâuHỏiThiToolStripMenuItem.Enabled = true;
            quảnLýSinhViênToolStripMenuItem1.Enabled = true;
            làmBàiThiTrắcNghiệmToolStripMenuItem.Enabled = false;
            toolStripMenuItem1.Enabled = true;
        }
        public void giaoDienSV()
        {
            quảnLýBàiThiToolStripMenuItem.Enabled = false;
            quảnLýCâuHỏiThiToolStripMenuItem.Enabled = false;
            quảnLýSinhViênToolStripMenuItem1.Enabled = false;
            làmBàiThiTrắcNghiệmToolStripMenuItem.Enabled = true;
            toolStripMenuItem1.Enabled = false;
        }
        private void quảnLýBàiThiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBaiThi f1 = new FormBaiThi();
            f1.MdiParent = this;
            f1.Show();
        }

        private void quảnLýCâuHỏiThiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCauHoiThi f2 = new FormCauHoiThi();
            f2.MdiParent = this;
            f2.Show();
        }

        private void quảnLýSinhViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormSinhVien f3 = new FormSinhVien();
            f3.MdiParent = this;
            f3.Show();
        }

        private void báoCáoSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBaoCaoTheoDiem fd = new FormBaoCaoTheoDiem(); ///////
            fd.MdiParent = this;
            fd.Show();
        }

        private void báoCáoTopCácBàiThiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //FormBaoCaoTopDiem1 form = new FormBaoCaoTopDiem1();
            //form.MdiParent = this;
            //form.Show();

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void làmBàiThiTrắcNghiệmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLamBai fLamBai = new FormLamBai();
            fLamBai.tenSV = tenSV;
            fLamBai.maSV = maSV;
            fLamBai.MdiParent = this;
            fLamBai.Show();
        }
    }
}
