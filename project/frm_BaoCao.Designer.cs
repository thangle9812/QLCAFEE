namespace project
{
    partial class frm_BaoCao
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
            this.dtp_date = new System.Windows.Forms.DateTimePicker();
            this.cb_BaoCao = new System.Windows.Forms.ComboBox();
            this.dgv_BaoCao = new System.Windows.Forms.DataGridView();
            this.btn_Timkiem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BaoCao)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label1.Location = new System.Drawing.Point(316, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Báo Cáo";
            // 
            // dtp_date
            // 
            this.dtp_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_date.Location = new System.Drawing.Point(271, 188);
            this.dtp_date.Name = "dtp_date";
            this.dtp_date.Size = new System.Drawing.Size(273, 30);
            this.dtp_date.TabIndex = 1;
            // 
            // cb_BaoCao
            // 
            this.cb_BaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_BaoCao.FormattingEnabled = true;
            this.cb_BaoCao.Items.AddRange(new object[] {
            "Doanh thu theo ngày",
            "Doanh thu theo tuần",
            "Doanh thu theo tháng"});
            this.cb_BaoCao.Location = new System.Drawing.Point(271, 135);
            this.cb_BaoCao.Name = "cb_BaoCao";
            this.cb_BaoCao.Size = new System.Drawing.Size(273, 33);
            this.cb_BaoCao.TabIndex = 2;
            this.cb_BaoCao.Text = "Doanh thu theo ngày";
            // 
            // dgv_BaoCao
            // 
            this.dgv_BaoCao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_BaoCao.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_BaoCao.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv_BaoCao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_BaoCao.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv_BaoCao.Location = new System.Drawing.Point(23, 254);
            this.dgv_BaoCao.Name = "dgv_BaoCao";
            this.dgv_BaoCao.RowHeadersWidth = 51;
            this.dgv_BaoCao.RowTemplate.Height = 24;
            this.dgv_BaoCao.Size = new System.Drawing.Size(765, 167);
            this.dgv_BaoCao.TabIndex = 3;
            // 
            // btn_Timkiem
            // 
            this.btn_Timkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Timkiem.Location = new System.Drawing.Point(572, 188);
            this.btn_Timkiem.Name = "btn_Timkiem";
            this.btn_Timkiem.Size = new System.Drawing.Size(122, 30);
            this.btn_Timkiem.TabIndex = 4;
            this.btn_Timkiem.Text = "Tìm Kiếm";
            this.btn_Timkiem.UseVisualStyleBackColor = true;
            this.btn_Timkiem.Click += new System.EventHandler(this.btn_Timkiem_Click);
            // 
            // frm_BaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Timkiem);
            this.Controls.Add(this.dgv_BaoCao);
            this.Controls.Add(this.cb_BaoCao);
            this.Controls.Add(this.dtp_date);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_BaoCao";
            this.Text = "frm_BaoCao";
            this.Load += new System.EventHandler(this.frm_BaoCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BaoCao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_date;
        private System.Windows.Forms.ComboBox cb_BaoCao;
        private System.Windows.Forms.DataGridView dgv_BaoCao;
        private System.Windows.Forms.Button btn_Timkiem;
    }
}