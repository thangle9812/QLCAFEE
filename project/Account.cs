using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace project
{
    public partial class frmAdAccount : Form
    {
        string oldusername;
        public frmAdAccount()
        {
            InitializeComponent();
        }
        private void Account_Load(object sender, EventArgs e)
        {
            load();
        }
        //ham load thong tin
        private void load()
        {
            DataProvider provider = new DataProvider();
            DataTable table = provider.loadAccount();
            dgvResult.DataSource = table;
        }
        private void clear()
        {
            txtUsername.ResetText();
            txtDisplayname.ResetText();
            txtPassword.ResetText();
            ckbAdmin.Checked = false;
        }
        private void dgvResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvResult.Rows[e.RowIndex];
                txtUsername.Text = row.Cells[0].Value.ToString();
                oldusername = row.Cells[0].Value.ToString();
                txtDisplayname.Text = row.Cells[1].Value.ToString();
                txtPassword.Text = row.Cells[2].Value.ToString();
                if (row.Cells[3].Value.ToString() == "ADMIN")
                    ckbAdmin.Checked = true;
                else if (row.Cells[3].Value.ToString() == "CASHIER")
                    ckbAdmin.Checked = false;
            }
        }

        //Them tai khoan
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string displayname = txtDisplayname.Text.Trim();
                string password = txtPassword.Text.Trim();
                string type = "CASHIER";

                if (ckbAdmin.Checked == true)
                {
                    type = "ADMIN"; // Xác định loại tài khoản
                }

                // Kiểm tra và thông báo nếu một trong các trường bị bỏ trống
                if (string.IsNullOrEmpty(username))
                {
                    MessageBox.Show("Vui lòng nhập tên tài khoản", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(displayname))
                {
                    MessageBox.Show("Vui lòng nhập tên hiển thị", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDisplayname.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return;
                }

                // Kiểm tra ký tự đặc biệt trong tên tài khoản
                if (System.Text.RegularExpressions.Regex.IsMatch(username, @"[^a-zA-Z0-9]"))
                {
                    MessageBox.Show("Tên tài khoản không thể chứa ký tự đặc biệt", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                    return;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(displayname, @"[^a-zA-Z0-9]"))
                {
                    MessageBox.Show("Tên hiển thị không thể chứa ký tự đặc biệt", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                    return;
                }

                // Thêm tài khoản vào cơ sở dữ liệu
                DataProvider provider = new DataProvider();
                provider.AddAccount(username, displayname, password, type);

                // Hiển thị thông báo thành công dựa trên loại tài khoản
                if (type == "ADMIN")
                {
                    MessageBox.Show("Thêm thành công!\nTài khoản Admin " + displayname + " đã được thêm.", "Đã thêm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm thành công!\nTài khoản Thu Ngân " + displayname + " đã được thêm.", "Đã thêm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                load();  // Tải lại dữ liệu sau khi thêm thành công
                clear(); // Xóa các trường nhập liệu sau khi thêm
            }
            catch
            {
                MessageBox.Show("Không thêm được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Xoa tai khoan
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy tên tài khoản từ ô văn bản
                string name = txtUsername.Text.Trim();

                // Kiểm tra xem ô văn bản có rỗng không
                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Vui lòng nhập tên tài khoản cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hiện hộp thoại xác nhận
                if (MessageBox.Show("Bạn có chắc xóa tài khoản " + name + " không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Nhấn Yes để xóa
                    DataProvider provider = new DataProvider();
                    provider.DelAccount(name); // Giả định DelAccount nhận tên tài khoản để xóa
                    MessageBox.Show("Xóa thành công!\n Tài khoản " + name + " đã được xóa.", "Đã xóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load(); // Gọi lại hàm load để cập nhật giao diện
                    clear(); // Gọi hàm clear để xóa dữ liệu trên giao diện
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không xóa được. Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Sua tai khoan
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string newusername = txtUsername.Text.Trim();
                string newdisplayname = txtDisplayname.Text.Trim();
                string newpassword = txtPassword.Text.Trim();
                string type = "CASHIER";

                if (ckbAdmin.Checked == true)
                {
                    type = "ADMIN"; // Xác định loại tài khoản
                }

                // Kiểm tra nếu không nhập gì cả
                if (string.IsNullOrEmpty(newusername) && string.IsNullOrEmpty(newdisplayname) && string.IsNullOrEmpty(newpassword))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra nếu bỏ trống từng trường cụ thể
                if (string.IsNullOrEmpty(newusername))
                {
                    MessageBox.Show("Vui lòng nhập tên tài khoản", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(newdisplayname))
                {
                    MessageBox.Show("Vui lòng nhập tên hiển thị", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDisplayname.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(newpassword))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return;
                }

                // Kiểm tra ký tự đặc biệt trong tên tài khoản
                if (System.Text.RegularExpressions.Regex.IsMatch(newusername, @"[^a-zA-Z0-9]"))
                {
                    MessageBox.Show("Tên tài khoản không thể chứa ký tự đặc biệt", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                    return;
                }

                // Cập nhật tài khoản vào cơ sở dữ liệu
                DataProvider provider = new DataProvider();
                provider.UpdateAccount(newusername, newdisplayname, newpassword, type, oldusername);

                // Hiển thị thông báo sửa thành công dựa trên loại tài khoản
                if (type == "ADMIN")
                {
                    MessageBox.Show("Chỉnh sửa thành công!\nTài khoản Admin " + newdisplayname + " đã được cập nhật.", "Đã sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Chỉnh sửa thành công!\nTài khoản Thu Ngân " + newdisplayname + " đã được cập nhật.", "Đã sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                load();  // Tải lại dữ liệu sau khi sửa thành công
                clear(); // Xóa các trường nhập liệu sau khi sửa
            }
            catch
            {
                MessageBox.Show("Không sửa được!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
