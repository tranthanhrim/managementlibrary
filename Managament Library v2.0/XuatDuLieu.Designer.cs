namespace Managament_Library_v2._0
{
    partial class XuatDuLieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XuatDuLieu));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbsach = new System.Windows.Forms.CheckBox();
            this.cbdocgia = new System.Windows.Forms.CheckBox();
            this.cbxdkchomuon = new System.Windows.Forms.CheckBox();
            this.cbxmuonsach = new System.Windows.Forms.CheckBox();
            this.btnxuat = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(434, 211);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 54);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(67, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Xuất dữ liệu";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.cbsach);
            this.panel2.Controls.Add(this.cbdocgia);
            this.panel2.Controls.Add(this.cbxdkchomuon);
            this.panel2.Controls.Add(this.cbxmuonsach);
            this.panel2.Controls.Add(this.btnxuat);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(428, 145);
            this.panel2.TabIndex = 1;
            // 
            // cbsach
            // 
            this.cbsach.AutoSize = true;
            this.cbsach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbsach.Location = new System.Drawing.Point(284, 62);
            this.cbsach.Name = "cbsach";
            this.cbsach.Size = new System.Drawing.Size(59, 21);
            this.cbsach.TabIndex = 30;
            this.cbsach.Text = "Sách";
            this.cbsach.UseVisualStyleBackColor = true;
            this.cbsach.CheckedChanged += new System.EventHandler(this.cbxdocgia_CheckedChanged);
            // 
            // cbdocgia
            // 
            this.cbdocgia.AutoSize = true;
            this.cbdocgia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbdocgia.Location = new System.Drawing.Point(284, 18);
            this.cbdocgia.Name = "cbdocgia";
            this.cbdocgia.Size = new System.Drawing.Size(75, 21);
            this.cbdocgia.TabIndex = 29;
            this.cbdocgia.Text = "Độc giả";
            this.cbdocgia.UseVisualStyleBackColor = true;
            this.cbdocgia.CheckedChanged += new System.EventHandler(this.cbxdocgia_CheckedChanged);
            // 
            // cbxdkchomuon
            // 
            this.cbxdkchomuon.AutoSize = true;
            this.cbxdkchomuon.Checked = true;
            this.cbxdkchomuon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxdkchomuon.Enabled = false;
            this.cbxdkchomuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxdkchomuon.Location = new System.Drawing.Point(45, 62);
            this.cbxdkchomuon.Name = "cbxdkchomuon";
            this.cbxdkchomuon.Size = new System.Drawing.Size(145, 21);
            this.cbxdkchomuon.TabIndex = 28;
            this.cbxdkchomuon.Text = "Đăng ký chờ mượn";
            this.cbxdkchomuon.UseVisualStyleBackColor = true;
            // 
            // cbxmuonsach
            // 
            this.cbxmuonsach.AutoSize = true;
            this.cbxmuonsach.Checked = true;
            this.cbxmuonsach.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxmuonsach.Enabled = false;
            this.cbxmuonsach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxmuonsach.Location = new System.Drawing.Point(45, 18);
            this.cbxmuonsach.Name = "cbxmuonsach";
            this.cbxmuonsach.Size = new System.Drawing.Size(96, 21);
            this.cbxmuonsach.TabIndex = 27;
            this.cbxmuonsach.Text = "Mượn sách";
            this.cbxmuonsach.UseVisualStyleBackColor = true;
            // 
            // btnxuat
            // 
            this.btnxuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnxuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnxuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxuat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnxuat.Location = new System.Drawing.Point(345, 106);
            this.btnxuat.Name = "btnxuat";
            this.btnxuat.Size = new System.Drawing.Size(74, 30);
            this.btnxuat.TabIndex = 26;
            this.btnxuat.Text = "Xuất";
            this.btnxuat.UseVisualStyleBackColor = false;
            this.btnxuat.Click += new System.EventHandler(this.btnxuat_Click);
            // 
            // XuatDuLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 211);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "XuatDuLieu";
            this.Text = "Xuất dữ liệu";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnxuat;
        private System.Windows.Forms.CheckBox cbsach;
        private System.Windows.Forms.CheckBox cbdocgia;
        private System.Windows.Forms.CheckBox cbxdkchomuon;
        private System.Windows.Forms.CheckBox cbxmuonsach;

    }
}