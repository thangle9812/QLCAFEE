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
        DataProvider provider = new DataProvider();
        public frm_ThemNhanVien()
        {
            InitializeComponent();
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
           
        }

   

        private bool ValidateInput(string hoTen, string chucVu, string diaChi, string sdt, string gioiTinh)
        {
            if (string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Họ tên không được để trống.");
                txt_HoTen.Focus();
                return false;
            }
            
            if (string.IsNullOrEmpty(diaChi))
            {
                MessageBox.Show("Địa chỉ không được để trống.");
                txt_DiaChi.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Số điện thoại không được để trống.");
                txt_SDT.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(gioiTinh))
            {
                MessageBox.Show("Vui lòng chọn giới tính.");
                return false;
            }
            return true;
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
            datetime_NgayThue.Value = DateTime.Now; // Đặt lại ngày thuê về ngày hiện tại
            txt_DiaChi.Clear();               // Làm sạch trường địa chỉ
            txt_SDT.Clear();                  // Làm sạch trường số điện thoại
            txtLuong.Clear();                 // Làm sạch trường lương (nếu có)
            rdo_Nam.Checked = false;          // Bỏ chọn giới tính Nam
            rdo_Nu.Checked = false;           // Bỏ chọn giới tính Nữ
            rdo_Khac.Checked = false;         // Bỏ chọn giới tính Khác
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ form
            string hoTen = txt_HoTen.Text.Trim();
            string email = txt_DiaChi.Text.Trim();
            DateTime ngayThue = datetime_NgayThue.Value;
            string luong = txtLuong.Text.Trim();
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
                ResetForm();
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại");
            }
        }
    }
}
