namespace project
{
    partial class ReplaceTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReplaceTable));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.dgvTableFrom = new System.Windows.Forms.DataGridView();
            this.cbbTableTo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbTableFrom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableFrom)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.btnAccept);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTotal);
            this.groupBox1.Controls.Add(this.dgvTableFrom);
            this.groupBox1.Controls.Add(this.cbbTableTo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbbTableFrom);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(486, 533);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chuyển bàn:";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.Cyan;
            this.btnAccept.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAccept.FlatAppearance.BorderSize = 0;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.ForeColor = System.Drawing.Color.Black;
            this.btnAccept.Location = new System.Drawing.Point(148, 385);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(204, 41);
            this.btnAccept.TabIndex = 16;
            this.btnAccept.Text = "Xác Nhận Chuyển";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(383, 103);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 25);
            this.label4.TabIndex = 19;
            this.label4.Text = "VNĐ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(70, 103);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 25);
            this.label3.TabIndex = 18;
            this.label3.Text = "Tổng:";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotal.Location = new System.Drawing.Point(173, 101);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(204, 27);
            this.txtTotal.TabIndex = 17;
            // 
            // dgvTableFrom
            // 
            this.dgvTableFrom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTableFrom.BackgroundColor = System.Drawing.Color.White;
            this.dgvTableFrom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableFrom.Location = new System.Drawing.Point(57, 151);
            this.dgvTableFrom.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTableFrom.Name = "dgvTableFrom";
            this.dgvTableFrom.RowHeadersWidth = 51;
            this.dgvTableFrom.RowTemplate.Height = 24;
            this.dgvTableFrom.Size = new System.Drawing.Size(374, 213);
            this.dgvTableFrom.TabIndex = 16;
            // 
            // cbbTableTo
            // 
            this.cbbTableTo.BackColor = System.Drawing.Color.White;
            this.cbbTableTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTableTo.FormattingEnabled = true;
            this.cbbTableTo.Location = new System.Drawing.Point(164, 461);
            this.cbbTableTo.Margin = new System.Windows.Forms.Padding(2);
            this.cbbTableTo.Name = "cbbTableTo";
            this.cbbTableTo.Size = new System.Drawing.Size(267, 33);
            this.cbbTableTo.TabIndex = 13;
            this.cbbTableTo.TextChanged += new System.EventHandler(this.cbbTableTo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(52, 461);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Đến bàn:";
            // 
            // cbbTableFrom
            // 
            this.cbbTableFrom.BackColor = System.Drawing.Color.White;
            this.cbbTableFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTableFrom.FormattingEnabled = true;
            this.cbbTableFrom.Location = new System.Drawing.Point(173, 49);
            this.cbbTableFrom.Margin = new System.Windows.Forms.Padding(2);
            this.cbbTableFrom.Name = "cbbTableFrom";
            this.cbbTableFrom.Size = new System.Drawing.Size(258, 33);
            this.cbbTableFrom.TabIndex = 11;
            this.cbbTableFrom.TextChanged += new System.EventHandler(this.cbbTableFrom_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(73, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Từ bàn:";
            // 
            // ReplaceTable
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(507, 554);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReplaceTable";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyển bàn";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableFrom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.DataGridView dgvTableFrom;
        private System.Windows.Forms.ComboBox cbbTableTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbTableFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAccept;

    }
}