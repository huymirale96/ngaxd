namespace BTL_QuanLyThiTracNghiem
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTen = new System.Windows.Forms.TextBox();
            this.textBoxMK = new System.Windows.Forms.TextBox();
            this.btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Đăng Nhập:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật Khẩu:";
            // 
            // textBoxTen
            // 
            this.textBoxTen.Location = new System.Drawing.Point(126, 77);
            this.textBoxTen.Name = "textBoxTen";
            this.textBoxTen.Size = new System.Drawing.Size(180, 20);
            this.textBoxTen.TabIndex = 1;
            this.textBoxTen.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBoxMK
            // 
            this.textBoxMK.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBoxMK.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxMK.Location = new System.Drawing.Point(126, 129);
            this.textBoxMK.Name = "textBoxMK";
            this.textBoxMK.PasswordChar = '*';
            this.textBoxMK.Size = new System.Drawing.Size(180, 20);
            this.textBoxMK.TabIndex = 2;
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(161, 173);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(75, 23);
            this.btn.TabIndex = 3;
            this.btn.Text = "OK";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            this.btn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 332);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.textBoxMK);
            this.Controls.Add(this.textBoxTen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form Đăng Nhập";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTen;
        private System.Windows.Forms.TextBox textBoxMK;
        private System.Windows.Forms.Button btn;
    }
}

