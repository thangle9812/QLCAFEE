namespace project
{
    partial class frmAdTables
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdTables));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.lblText);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(20, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1166, 182);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách bàn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(42, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 22);
            this.label2.TabIndex = 43;
            this.label2.Text = "Tên bàn:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(42, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 22);
            this.label1.TabIndex = 42;
            this.label1.Text = "Đang chọn:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(984, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 22);
            this.label6.TabIndex = 41;
            this.label6.Text = "Sửa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(807, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 22);
            this.label5.TabIndex = 40;
            this.label5.Text = "Xóa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(618, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 22);
            this.label4.TabIndex = 39;
            this.label4.Text = "Thêm";
            // 
            // lblText
            // 
            this.lblText.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblText.Location = new System.Drawing.Point(162, 56);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(41, 22);
            this.lblText.TabIndex = 35;
            this.lblText.Text = "Bàn";
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtName.Location = new System.Drawing.Point(166, 123);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(126, 28);
            this.txtName.TabIndex = 34;
            // 
            // dgvResult
            // 
            this.dgvResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResult.BackgroundColor = System.Drawing.Color.White;
            this.dgvResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Location = new System.Drawing.Point(19, 200);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.RowHeadersWidth = 51;
            this.dgvResult.RowTemplate.Height = 24;
            this.dgvResult.Size = new System.Drawing.Size(1167, 333);
            this.dgvResult.TabIndex = 11;
            this.dgvResult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResult_CellContentClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.BackgroundImage = global::project.Properties.Resources.bin;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDelete.Location = new System.Drawing.Point(800, 45);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(49, 40);
            this.btnDelete.TabIndex = 38;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEdit.BackColor = System.Drawing.Color.White;
            this.btnEdit.BackgroundImage = global::project.Properties.Resources.reporticon;
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEdit.Location = new System.Drawing.Point(978, 44);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(48, 45);
            this.btnEdit.TabIndex = 37;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.BackgroundImage = global::project.Properties.Resources.add;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdd.Location = new System.Drawing.Point(622, 44);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(49, 43);
            this.btnAdd.TabIndex = 36;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmAdTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1204, 545);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvResult);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAdTables";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý danh sách bàn";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmAdTables_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DataGridView dgvResult;


    }
}