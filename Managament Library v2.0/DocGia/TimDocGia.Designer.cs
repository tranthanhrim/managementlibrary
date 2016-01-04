namespace Managament_Library_v2._0
{
    partial class TimDocGia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimDocGia));
            this.panel3 = new System.Windows.Forms.Panel();
            this.btntim = new System.Windows.Forms.Button();
            this.dgvdocgia = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbten = new System.Windows.Forms.RadioButton();
            this.rblop = new System.Windows.Forms.RadioButton();
            this.rbmdg = new System.Windows.Forms.RadioButton();
            this.txtlop = new System.Windows.Forms.TextBox();
            this.txtten = new System.Windows.Forms.TextBox();
            this.txtmdg = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdocgia)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.btntim);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 414);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(778, 44);
            this.panel3.TabIndex = 4;
            // 
            // btntim
            // 
            this.btntim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btntim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntim.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntim.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btntim.Location = new System.Drawing.Point(667, 3);
            this.btntim.Name = "btntim";
            this.btntim.Size = new System.Drawing.Size(111, 38);
            this.btntim.TabIndex = 43;
            this.btntim.Text = "Tìm";
            this.btntim.UseVisualStyleBackColor = false;
            this.btntim.Click += new System.EventHandler(this.btntim_Click);
            // 
            // dgvdocgia
            // 
            this.dgvdocgia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdocgia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvdocgia.Location = new System.Drawing.Point(3, 153);
            this.dgvdocgia.MultiSelect = false;
            this.dgvdocgia.Name = "dgvdocgia";
            this.dgvdocgia.ReadOnly = true;
            this.dgvdocgia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvdocgia.Size = new System.Drawing.Size(778, 255);
            this.dgvdocgia.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.rbten);
            this.panel2.Controls.Add(this.rblop);
            this.panel2.Controls.Add(this.rbmdg);
            this.panel2.Controls.Add(this.txtlop);
            this.panel2.Controls.Add(this.txtten);
            this.panel2.Controls.Add(this.txtmdg);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(778, 94);
            this.panel2.TabIndex = 2;
            // 
            // rbten
            // 
            this.rbten.AutoSize = true;
            this.rbten.Location = new System.Drawing.Point(417, 18);
            this.rbten.Name = "rbten";
            this.rbten.Size = new System.Drawing.Size(83, 17);
            this.rbten.TabIndex = 35;
            this.rbten.TabStop = true;
            this.rbten.Text = "Tên độc giả";
            this.rbten.UseVisualStyleBackColor = true;
            this.rbten.CheckedChanged += new System.EventHandler(this.rbten_CheckedChanged);
            // 
            // rblop
            // 
            this.rblop.AutoSize = true;
            this.rblop.Location = new System.Drawing.Point(156, 59);
            this.rblop.Name = "rblop";
            this.rblop.Size = new System.Drawing.Size(43, 17);
            this.rblop.TabIndex = 34;
            this.rblop.TabStop = true;
            this.rblop.Text = "Lớp";
            this.rblop.UseVisualStyleBackColor = true;
            this.rblop.CheckedChanged += new System.EventHandler(this.rblop_CheckedChanged);
            // 
            // rbmdg
            // 
            this.rbmdg.AutoSize = true;
            this.rbmdg.Checked = true;
            this.rbmdg.Location = new System.Drawing.Point(156, 17);
            this.rbmdg.Name = "rbmdg";
            this.rbmdg.Size = new System.Drawing.Size(79, 17);
            this.rbmdg.TabIndex = 33;
            this.rbmdg.TabStop = true;
            this.rbmdg.Text = "Mã độc giả";
            this.rbmdg.UseVisualStyleBackColor = true;
            this.rbmdg.CheckedChanged += new System.EventHandler(this.rbmdg_CheckedChanged);
            // 
            // txtlop
            // 
            this.txtlop.Location = new System.Drawing.Point(246, 62);
            this.txtlop.Name = "txtlop";
            this.txtlop.Size = new System.Drawing.Size(48, 20);
            this.txtlop.TabIndex = 30;
            this.txtlop.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmdg_KeyDown);
            // 
            // txtten
            // 
            this.txtten.Location = new System.Drawing.Point(506, 16);
            this.txtten.Name = "txtten";
            this.txtten.Size = new System.Drawing.Size(150, 20);
            this.txtten.TabIndex = 27;
            this.txtten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmdg_KeyDown);
            // 
            // txtmdg
            // 
            this.txtmdg.Location = new System.Drawing.Point(246, 16);
            this.txtmdg.Name = "txtmdg";
            this.txtmdg.Size = new System.Drawing.Size(48, 20);
            this.txtmdg.TabIndex = 0;
            this.txtmdg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmdg_KeyDown);
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
            this.label1.Size = new System.Drawing.Size(175, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "TÌM ĐỘC GIẢ";
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvdocgia, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 461);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // TimDocGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "TimDocGia";
            this.Text = "Tìm độc giả";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TimDocGia_KeyDown);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdocgia)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btntim;
        private System.Windows.Forms.DataGridView dgvdocgia;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbten;
        private System.Windows.Forms.RadioButton rblop;
        private System.Windows.Forms.RadioButton rbmdg;
        private System.Windows.Forms.TextBox txtlop;
        private System.Windows.Forms.TextBox txtten;
        private System.Windows.Forms.TextBox txtmdg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

    }
}