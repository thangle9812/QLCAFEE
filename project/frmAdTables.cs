﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace project
{
    public partial class frmAdTables : Form
    {
        public frmAdTables()
        {
            InitializeComponent();
        }

        private void frmAdTables_Load(object sender, EventArgs e)
        {
            loadTable();
        }
        //ham load thong tin
        private void loadTable()
        {
            try
            {
                DataProvider provider = new DataProvider();
                DataTable table = provider.loadTableF();
                dgvResult.DataSource = table;
            }
            catch
            {
                MessageBox.Show("Không thể tải bàn!", "Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        //click vao bang
        private void dgvResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int t = dgvResult.CurrentCell.RowIndex;
            lblText.Text = dgvResult.Rows[t].Cells[0].Value.ToString();
        }
       
        //Them ban
        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                string name = txtName.Text;
                DataProvider provider = new DataProvider();

                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Tên bàn trống kìa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (name.Length > 10)
                {
                    MessageBox.Show("Tên bàn không được quá 10 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!System.Text.RegularExpressions.Regex.IsMatch(name, @"^[\p{L}\p{N}\s]+$"))
                {
                    MessageBox.Show("Tên bàn không được chứa kí tự đặc biệt!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (provider.IsTableNameExists(name))
                {
                    MessageBox.Show("Tên bàn đã tồn tại trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    provider.AddTable(name);
                    loadTable();
                    MessageBox.Show("Đã thêm bàn thành công!", "Đã thêm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Không thể thêm bàn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Xoa ban
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    //Nhan yes
                    DataProvider provider = new DataProvider();
                    provider.DelTable(lblText.Text);
                    loadTable();
                    MessageBox.Show("Đã xóa bàn thành công!", "Đã xóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //nhan no
            }
            catch
            {
                MessageBox.Show("Không thể xóa bàn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Sua ban
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text != "")
                {
                    DataProvider provider = new DataProvider();
                    provider.UpdateTable(txtName.Text,lblText.Text);
                    loadTable();
                    MessageBox.Show("Đã sửa bàn thành công!", "Đã sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.ResetText();
                }
                else
                {
                    MessageBox.Show("Tên bàn trống kìa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch 
            {
                MessageBox.Show("Không thể sửa bàn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
