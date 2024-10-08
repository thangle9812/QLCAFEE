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
                            txt_DiaChi.Text = reader["Email"].ToString(); // Hiển thị địa chỉ
                            txt_SDT.Text = reader["Phone"].ToString(); // Hiển thị số điện thoại
                            txtLuong.Text = reader["Salary"].ToString(); // Hiển thị chức vụ
                             
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

                            // Các control khác cũng hiển thị tương tự nếu cần
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
            // Lấy dữ liệu từ form
            string hoTen = txt_HoTen.Text.Trim();
            string email = txt_DiaChi.Text.ToString();
            
            DateTime ngayThue = datetime_NgayThue.Value;
            string luong = txtLuong.Text.Trim();
            string sdt = txt_SDT.Text.Trim();
            string gioiTinh = string.Empty;

            if (rdo_Nam.Checked)
            {
                gioiTinh = rdo_Nam.Text.Trim();
            }
            else if (rdo_Nu.Checked)
            {
                gioiTinh = rdo_Nu.Text.Trim();
            }
            else if (rdo_Khac.Checked)
            {
                gioiTinh = rdo_Khac.Text.Trim();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn giới tính.");
                return;
            }

            // Câu lệnh SQL để cập nhật thông tin nhân viên
            string sql = $"UPDATE Employees SET Name = N'{hoTen}', " +
             $"Email = '{email}', " +
             $"Sex = N'{gioiTinh}', " +
             $"Salary = N'{luong}', " +
             $"Phone = '{sdt}', " +
             $"HireDate = '{ngayThue:yyyy-MM-dd}' " +
             $"WHERE EmployeeId = {employeeId}";

            // Thực hiện câu lệnh SQL
            int result = provider.ThemXoaSua(sql);
            if (result >= 1)
            {
                MessageBox.Show("Cập nhật nhân viên thành công");
                //ResetForm(); // Reset form nếu cần thiết
            }
            else
            {
                MessageBox.Show("Cập nhật nhân viên thất bại");
            }
        }
    }
}
