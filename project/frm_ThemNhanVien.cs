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
    public partial class frm_ThemNhanVien : Form
    {
        public event EventHandler EmployeeAdded;
        DataProvider provider = new DataProvider();
        public frm_ThemNhanVien()
        {
            InitializeComponent();
        }
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
        private void ClearDateTimePicker()
        {
            datetime_NgayThue.CustomFormat = " ";
            datetime_NgayThue.Format = DateTimePickerFormat.Custom;
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

        private string GetGioiTinh()
        {
            if (rdo_Nam.Checked) return "Nam";
            if (rdo_Nu.Checked) return "Nữ";
            if (rdo_Khac.Checked) return "Khác";
            return null; // Nếu không chọn giới tính
        }



        private void ResetForm()
        {
            txt_HoTen.Clear();
            datetime_NgayThue.Value = DateTime.Now;
            txt_Email.Clear();
            txt_SDT.Clear();
            txt_Luong.Clear();
            ResetGenderSelection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ form
            string hoTen = txt_HoTen.Text.Trim();
            string email = txt_Email.Text.Trim();
            DateTime ngayThue = datetime_NgayThue.Value;
            string luong = txt_Luong.Text.Trim();
            string sdt = txt_SDT.Text.Trim();
            string gioiTinh = GetGioiTinh();

            // Kiểm tra dữ liệu đầu vào
            if (!ValidateInput(hoTen, email, luong, sdt, gioiTinh))
                return;

            // Câu lệnh SQL để thêm nhân viên
            string sql = "INSERT INTO Employees (Name, Phone, Email, Sex, HireDate, Salary) " +
                         "VALUES (@FullName, @Phone, @Email, @Sex, @HireDate, @Salary)";

            // Thực hiện câu lệnh SQL
            int result = provider.AddEmployee(sql, hoTen, sdt, email, gioiTinh, ngayThue, luong);
            if (result >= 1)
            {
                MessageBox.Show("Thêm nhân viên thành công");
                EmployeeAdded?.Invoke(this, EventArgs.Empty);
                ResetForm();
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại");
            }
        }

        private void ResetGenderSelection()
        {
            // Đảm bảo rằng không có checkbox nào được chọn khi mở form
            rdo_Nam.Checked = false;
            rdo_Nu.Checked = false;
            rdo_Khac.Checked = false;
        }
        private void frm_ThemNhanVien_Load(object sender, EventArgs e)
        {
            ResetGenderSelection();
            ClearDateTimePicker();
            ActiveControl = panel1;
        }

        private void datetime_NgayThue_ValueChanged(object sender, EventArgs e)
        {
            datetime_NgayThue.CustomFormat = "dd/MM/yyyy";
        }

        private void txt_HoTen_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
