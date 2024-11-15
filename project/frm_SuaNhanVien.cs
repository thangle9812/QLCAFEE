using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class frm_SuaNhanVien : Form
    {
        DataProvider provider = new DataProvider();
        public frm_SuaNhanVien(int employeeId)
        {
            InitializeComponent();
            this.employeeId = employeeId; // Gán ID nhân viên vào biến
            LoadEmployeeData();
            // LopDungChungDatabase = new LopDungChungDatabase();
        }
        private int employeeId; // Biến để lưu ID nhân viên
        private string originalHoTen, originalEmail, originalSDT, originalLuong, originalGioiTinh, originalNgayThue;
        private bool ValidateInput(string hoTen, string email, string luong, string sdt, string gioiTinh)
        {
            if (string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Họ Tên không được để trống");
                txt_HoTen.Focus();
                return false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(hoTen, @"^[\p{L}\s]+$"))
            {
                MessageBox.Show("Họ tên không được chứa ký tự đặc biệt hoặc số.");
                txt_HoTen.Focus();
                return false;
            }


            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Email không được để trống");
                txt_Email.Focus();
                return false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.(vn|com)$"))
            {
                MessageBox.Show("Email không hợp lệ");
                txt_Email.Focus();
                return false;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ.");
                txt_Email.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Số điện thoại không được để trống");
                txt_SDT.Focus();
                return false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^\d+$"))
            {
                MessageBox.Show("Số điện thoại chỉ chứa số");
                txt_SDT.Focus();
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^0\d{9,10}$"))
            {
                MessageBox.Show("SĐT phải bắt đầu bằng số 0 và chứa đúng 10 hoặc 11 số");
                txt_SDT.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(luong))
            {
                MessageBox.Show("Lương không được để trống");
                txt_Luong.Focus();
                return false;
            }

            if (!decimal.TryParse(luong, out decimal salary))
            {
                MessageBox.Show("Lương chỉ chứa số");
                txt_Luong.Focus();
                return false;
            }

            if (salary < 0)
            {
                MessageBox.Show("Lương phải lớn hơn hoặc bằng 0");
                txt_Luong.Focus();
                return false;
            }
            if (datetime_NgayThue.CustomFormat == " ")
            {
                MessageBox.Show("Ngày thuê không được để trống! Vui lòng chọn ngày thuê");
                datetime_NgayThue.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(gioiTinh))
            {
                MessageBox.Show("Giới tính không được để trống! Vui lòng chọn giới tính");
                return false;
            }


            return true;
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private async void LoadEmployeeData()
        {
            //try
            //{
            // Truy vấn lấy thông tin nhân viên theo employeeId
            string query = $"SELECT * FROM Employees WHERE EmployeeId = {employeeId}";

            // Sử dụng phương thức bất đồng bộ để lấy dữ liệu
            using (SqlDataReader reader = await provider.LayDl(query))
            {
                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        // Gán dữ liệu vào các control tương ứng
                        txt_HoTen.Text = reader["Name"].ToString(); // Hiển thị tên
                        txt_Email.Text = reader["Email"].ToString(); // Hiển thị địa chỉ
                        txt_SDT.Text = reader["Phone"].ToString(); // Hiển thị số điện thoại
                        txt_Luong.Text = reader["Salary"].ToString(); // Hiển thị chức vụ

                        datetime_NgayThue.Text = reader["HireDate"].ToString(); // Hiển thị ngày thuê
                        var gioitinh = reader["Sex"].ToString(); // Hiển thị giới tính

                        if (gioitinh.Equals("Khác"))
                        {
                            rdo_Khac.Checked = true;
                        }
                        else if (gioitinh.Equals("Nữ"))
                        {
                            rdo_Nu.Checked = true;
                        }
                        else if (gioitinh.Equals("Nam"))
                        {
                            rdo_Nam.Checked = true;
                        }
                        originalHoTen = txt_HoTen.Text.Trim();
                        originalEmail = txt_Email.Text.Trim();
                        originalSDT = txt_SDT.Text.Trim();
                        originalLuong = txt_Luong.Text.Trim();
                        originalNgayThue = datetime_NgayThue.Value.ToString();
                        originalGioiTinh = rdo_Nam.Checked ? "Nam" : rdo_Nu.Checked ? "Nữ" : "Khác";
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu nhân viên.");
                }
            }

            // Đóng kết nối sau khi hoàn thành công việc
            provider.connection.Close();
            // }
            //catch (Exception ex)
            //{
            //   // MessageBox.Show($"Lỗi khi tải dữ liệu nhân viên: {ex.Message}");
            //}
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu hiện tại
            string hoTen = txt_HoTen.Text.Trim();
            string email = txt_Email.Text.Trim();
            string sdt = txt_SDT.Text.Trim();
            string luong = txt_Luong.Text.Trim();
            DateTime ngayThue = datetime_NgayThue.Value;
            string gioiTinh = rdo_Nam.Checked ? "Nam" : rdo_Nu.Checked ? "Nữ" : "Khác";

            if (!ValidateInput(hoTen, email, luong, sdt, gioiTinh))
                return;

            // Xác định các trường đã thay đổi bằng cách so sánh với giá trị ban đầu
            bool isNameChanged = !hoTen.Equals(originalHoTen);
            bool isEmailChanged = !email.Equals(originalEmail);
            bool isPhoneChanged = !sdt.Equals(originalSDT);
            bool isSalaryChanged = !luong.Equals(originalLuong);
            bool isHireDateChanged = ngayThue.Date != DateTime.Parse(originalNgayThue).Date;
            bool isGenderChanged = originalGioiTinh != gioiTinh;

            // Khởi tạo thông báo các trường đã thay đổi
            List<string> changes = new List<string>();
            if (isNameChanged) changes.Add("Họ Tên");
            if (isEmailChanged) changes.Add("Email");
            if (isPhoneChanged) changes.Add("Số điện thoại");
            if (isSalaryChanged) changes.Add("Lương");
            if (isHireDateChanged) changes.Add("Ngày thuê");
            if (isGenderChanged) changes.Add("Giới tính");

            // Thông báo dựa trên số trường đã thay đổi
            if (changes.Count == 0)
            {
                MessageBox.Show("Không có thông tin gì thay đổi để cập nhật");
                return;
            }
            else if (changes.Count == 6) // Nếu tất cả các trường đã thay đổi
            {
                MessageBox.Show("Đã cập nhật tất cả thông tin");
            }
            else // Nếu chỉ một số trường thay đổi
            {
                string message = $"Đã cập nhật thông tin: {string.Join(", ", changes)}";
                MessageBox.Show(message);
            }

            // Cập nhật thông tin trong cơ sở dữ liệu
            string sql = $"UPDATE Employees SET Name = N'{hoTen}', " +
                         $"Email = '{email}', " +
                         $"Sex = N'{gioiTinh}', " +
                         $"Salary = N'{luong}', " +
                         $"Phone = '{sdt}', " +
                         $"HireDate = '{ngayThue:yyyy-MM-dd}' " +
                         $"WHERE EmployeeId = {employeeId}";

            int result = provider.ThemXoaSua(sql);
            if (result >= 1)
            {
                MessageBox.Show("Cập nhật nhân viên thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật nhân viên thất bại");
            }
        }


    }
}