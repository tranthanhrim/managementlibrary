namespace Managament_Library_v2._0
{
    partial class TimDangKyCho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimDangKyCho));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtngaygiodk = new System.Windows.Forms.DateTimePicker();
            this.rbngaydk = new System.Windows.Forms.RadioButton();
            this.rbmadausach = new System.Windows.Forms.RadioButton();
            this.rbmdg = new System.Windows.Forms.RadioButton();
            this.txtmds = new System.Windows.Forms.TextBox();
            this.txtmdg = new System.Windows.Forms.TextBox();
            this.dgvdkcho = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btntim = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdkcho)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvdkcho, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 461);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(778, 44);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(65, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(485, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "TÌM THÔNG TIN ĐĂNG KỲ CHỜ MƯỢN";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.dtngaygiodk);
            this.panel2.Controls.Add(this.rbngaydk);
            this.panel2.Controls.Add(this.rbmadausach);
            this.panel2.Controls.Add(this.rbmdg);
            this.panel2.Controls.Add(this.txtmds);
            this.panel2.Controls.Add(this.txtmdg);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(778, 94);
            this.panel2.TabIndex = 2;
            // 
            // dtngaygiodk
            // 
            this.dtngaygiodk.Location = new System.Drawing.Point(474, 17);
            this.dtngaygiodk.Name = "dtngaygiodk";
            this.dtngaygiodk.Size = new System.Drawing.Size(200, 20);
            this.dtngaygiodk.TabIndex = 35;
            this.dtngaygiodk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmdg_KeyDown);
            // 
            // rbngaydk
            // 
            this.rbngaydk.AutoSize = true;
            this.rbngaydk.Location = new System.Drawing.Point(389, 18);
            this.rbngaydk.Name = "rbngaydk";
            this.rbngaydk.Size = new System.Drawing.Size(79, 17);
            this.rbngaydk.TabIndex = 34;
            this.rbngaydk.Text = "Ngày mượn";
            this.rbngaydk.UseVisualStyleBackColor = true;
            // 
            // rbmadausach
            // 
            this.rbmadausach.AutoSize = true;
            this.rbmadausach.Location = new System.Drawing.Point(137, 63);
            this.rbmadausach.Name = "rbmadausach";
            this.rbmadausach.Size = new System.Drawing.Size(88, 17);
            this.rbmadausach.TabIndex = 33;
            this.rbmadausach.Text = "Mã đầu sách";
            this.rbmadausach.UseVisualStyleBackColor = true;
            this.rbmadausach.CheckedChanged += new System.EventHandler(this.rbmadausach_CheckedChanged);
            // 
            // rbmdg
            // 
            this.rbmdg.AutoSize = true;
            this.rbmdg.Checked = true;
            this.rbmdg.Location = new System.Drawing.Point(137, 18);
            this.rbmdg.Name = "rbmdg";
            this.rbmdg.Size = new System.Drawing.Size(79, 17);
            this.rbmdg.TabIndex = 32;
            this.rbmdg.TabStop = true;
            this.rbmdg.Text = "Mã độc giả";
            this.rbmdg.UseVisualStyleBackColor = true;
            this.rbmdg.CheckedChanged += new System.EventHandler(this.rbmdg_CheckedChanged);
            // 
            // txtmds
            // 
            this.txtmds.Location = new System.Drawing.Point(246, 62);
            this.txtmds.Name = "txtmds";
            this.txtmds.Size = new System.Drawing.Size(55, 20);
            this.txtmds.TabIndex = 30;
            this.txtmds.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmdg_KeyDown);
            // 
            // txtmdg
            // 
            this.txtmdg.Location = new System.Drawing.Point(246, 17);
            this.txtmdg.Name = "txtmdg";
            this.txtmdg.Size = new System.Drawing.Size(55, 20);
            this.txtmdg.TabIndex = 0;
            this.txtmdg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmdg_KeyDown);
            // 
            // dgvdkcho
            // 
            this.dgvdkcho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdkcho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvdkcho.Location = new System.Drawing.Point(3, 153);
            this.dgvdkcho.MultiSelect = false;
            this.dgvdkcho.Name = "dgvdkcho";
            this.dgvdkcho.ReadOnly = true;
            this.dgvdkcho.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvdkcho.Size = new System.Drawing.Size(778, 245);
            this.dgvdkcho.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.btntim);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 404);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(778, 54);
            this.panel3.TabIndex = 4;
            // 
            // btntim
            // 
            this.btntim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btntim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntim.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntim.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btntim.Location = new System.Drawing.Point(668, 3);
            this.btntim.Name = "btntim";
            this.btntim.Size = new System.Drawing.Size(110, 48);
            this.btntim.TabIndex = 30;
            this.btntim.Text = "Tìm";
            this.btntim.UseVisualStyleBackColor = false;
            this.btntim.Click += new System.EventHandler(this.btntim_Click);
            // 
            // TimDangKyCho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "TimDangKyCho";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TimDangKyCho_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdkcho)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtngaygiodk;
        private System.Windows.Forms.RadioButton rbngaydk;
        private System.Windows.Forms.RadioButton rbmadausach;
        private System.Windows.Forms.RadioButton rbmdg;
        private System.Windows.Forms.TextBox txtmds;
        private System.Windows.Forms.TextBox txtmdg;
        private System.Windows.Forms.DataGridView dgvdkcho;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btntim;
    }
}