using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace project
{
    public partial class frmLogin : Form
    {
        string name;
        string type;
        DataProvider Provider=new DataProvider();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult ms = MessageBox.Show("Bạn có muốn thoát không? ", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ms == DialogResult.Yes)
            {
                this.Close();
            }
        }

        //Ham kiem tra Dang nhap
        private bool CheckLogin(string username, string password, string typeA)
        {
            DataProvider provider = new DataProvider();
            DataTable table = provider.loadAccount();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (table.Rows[i][0].ToString() == username && table.Rows[i][2].ToString() == password && table.Rows[i][3].ToString() == typeA)
                {
                    name = table.Rows[i][1].ToString();
                    type = table.Rows[i][3].ToString();
                    //MessageBox.Show("Xin chào "+name+" :)", "Đăng nhập thành công",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            return false;
        }

        //Su kien click btnLogin
        private void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                string user = txtUsername.Text.Trim();
                string pass = txtPassword.Text.Trim();
                string type = "CASHIER";

                if (rdbAdmin.Checked == true)
                {
                    type = "ADMIN";
                }

                if (string.IsNullOrEmpty(user) && string.IsNullOrEmpty(pass))
                {
                    MessageBox.Show("Không được để trống tên tài khoản và mật khẩu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (System.Text.RegularExpressions.Regex.IsMatch(user, @"[^a-zA-Z0-9]"))
                {
                    MessageBox.Show("Tên tài khoản không thể chứa ký tự đặc biệt", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (CheckLogin(user, pass, type) == true)
                {
                    if (type == "ADMIN")
                    {
                        MessageBox.Show("Đăng nhập thành công với quyền Admin! Xin chào " + name, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập thành công với quyền Thu Ngân! Xin chào " + name, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.Hide();  // Ẩn form đăng nhập tạm thời
                    frmMain main = new frmMain(user, name, pass, type);
                    main.Show();  // Mở form `frmMain` ở chế độ không phải modal
                    main.FormClosed += (s, args) => this.Close(); // Đóng form đăng nhập khi form chính đóng
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Lỗi...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Cơ sở dữ liệu không tồn tại. Vui lòng tạo mới theo file hướng dẫn", "Lỗi...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}
