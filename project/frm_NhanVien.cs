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
    public partial class frm_NhanVien : Form
    {
        DataProvider provider = new DataProvider();
        public frm_NhanVien()
        {
            InitializeComponent();
        }

        private void frm_NhanVien_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Employees";

            // Gọi phương thức LoadDL để lấy dữ liệu
            DataTable result =  provider.LoadDL(sql); // Đảm bảo LoadDL trả về DataTable

            // Đặt DataSource cho DataGridView
            data_GridView_Employees.DataSource = result;


            if (result.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nhân viên.");
            }

            // Kiểm tra xem cột "Sửa" đã tồn tại chưa, nếu có thì loại bỏ trước khi thêm lại
            //if (data_GridView_Employees.Columns.Contains("btn_Sua"))
            //{
            //    data_GridView_Employees.Columns.Remove("btn_Sua");
            //}

            // Thêm cột "Sửa" vào DataGridView
            DataGridViewButtonColumn btnEditColumn = new DataGridViewButtonColumn();
            btnEditColumn.HeaderText = "Sửa";
            btnEditColumn.Name = "btn_Sua";
            btnEditColumn.Text = "Sửa";
            btnEditColumn.UseColumnTextForButtonValue = true;
            data_GridView_Employees.Columns.Add(btnEditColumn);

            // Cài đặt các thuộc tính cho DataGridView
            data_GridView_Employees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // Không tự động điều chỉnh chiều rộng cột
            data_GridView_Employees.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            data_GridView_Employees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            data_GridView_Employees.RowTemplate.Height = 50;
            data_GridView_Employees.DefaultCellStyle.Font = new Font("Arial", 12);

            // Thiết lập chiều rộng tối đa cho từng cột
            foreach (DataGridViewColumn column in data_GridView_Employees.Columns)
            {
                column.Width = 150; // Ví dụ: đặt chiều rộng cột tối đa là 150 pixels
            }


            // Xóa lựa chọn mặc định ban đầu
            data_GridView_Employees.ClearSelection();

            // Đảm bảo sự kiện CellClick chỉ được gán một lần
            data_GridView_Employees.CellClick -= DataGridView_Employees_CellClick; // Xóa sự kiện trước đó
            data_GridView_Employees.CellClick += DataGridView_Employees_CellClick; // Gán lại sự kiện
        }

        private void DataGridView_Employees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= data_GridView_Employees.Rows.Count) // Nếu không có hàng nào được chọn hoặc chỉ số không hợp lệ
            {
                return; // Dừng lại nếu không có hàng hoặc chỉ số không hợp lệ
            }

            // Lấy thông tin nhân viên từ hàng được chọn
            var selectedRow = data_GridView_Employees.Rows[e.RowIndex];
            string employeeIdStr = selectedRow.Cells["EmployeeId"].Value.ToString();
            txt_Search.Text = employeeIdStr;

            // Kiểm tra xem người dùng có nhấn vào cột nút "Sửa" không
            if (e.ColumnIndex == data_GridView_Employees.Columns["btn_Sua"].Index)
            {
                // Chuyển đổi employeeIdStr sang int
                if (int.TryParse(employeeIdStr, out int employeeId))
                {
                    // Mở form sửa nhân viên với thông tin tương ứng
                     frm_SuaNhanVien editForm = new frm_SuaNhanVien(employeeId); // Truyền employeeId vào constructor
                    editForm.Show(); // Mở form dưới dạng hộp thoại (có thể thay đổi theo yêu cầu)
                }
                else
                {
                    MessageBox.Show("ID nhân viên không hợp lệ.");
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txt_Search.Text.Trim();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Tìm kiếm theo ID hoặc tất cả các trường
                string sql;

                // Kiểm tra nếu searchTerm là số (cho ID)
                if (int.TryParse(searchTerm, out _))
                {
                    // Nếu là số, tìm kiếm theo ID
                    sql = "SELECT * FROM Employees WHERE EmployeeId = " + searchTerm;
                }
                else
                {
                    // Nếu không phải số, tìm kiếm trong tất cả các trường
                    // Giả sử cột tên đầy đủ là FullName
                    sql = "SELECT * FROM Employees WHERE Name LIKE N'%" + searchTerm + "%' OR Sex LIKE N'%" + searchTerm + "%'";
                }

                var result = provider.LoadDL(sql);
                Console.WriteLine(result.Rows.Count); // In số dòng trong kết quả

                data_GridView_Employees.DataSource = result;

                if (result.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy nhân viên với thông tin đã nhập.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frm_ThemNhanVien themnv = new frm_ThemNhanVien();
            themnv.EmployeeAdded += (s, args) => LoadEmployeeTables();

            themnv.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Search.Text))
            {
                MessageBox.Show("Vui lòng nhập ID để xóa nhân viên.");
                return;
            }

            // Hiển thị thông báo xác nhận
            DialogResult confirmResult = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa nhân viên này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );


            // Nếu người dùng chọn "Yes", thực hiện xóa
            if (confirmResult == DialogResult.Yes)
            {
                string sql = "DELETE FROM Employees WHERE EmployeeId=" + txt_Search.Text;
                int kq = provider.XoaNhanVien(sql);
                if (kq >= 1)
                {
                    MessageBox.Show("Xóa nhân viên thành công");

                    // Reset thanh tìm kiếm sau khi xóa thành công
                    txt_Search.Text = string.Empty;

                    // Tải lại danh sách nhân viên
                    LoadEmployeeTables();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại! Nhân viên không tồn tại để xóa");
                }
            }
        }
        private async Task LoadEmployeeTables()
        {
            string sql = "SELECT * FROM Employees";
            var result = provider.LoadDL(sql);

            data_GridView_Employees.DataSource = result;

            if (result.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nhân viên.");
            }

            if (data_GridView_Employees.Columns.Contains("btn_Sua"))
            {
                data_GridView_Employees.Columns.Remove("btn_Sua");
            }

            DataGridViewButtonColumn btnEditColumn = new DataGridViewButtonColumn();
            btnEditColumn.HeaderText = "Sửa";
            btnEditColumn.Name = "btn_Sua";
            btnEditColumn.Text = "Sửa";
            btnEditColumn.UseColumnTextForButtonValue = true;
            data_GridView_Employees.Columns.Add(btnEditColumn);

            data_GridView_Employees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            data_GridView_Employees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            data_GridView_Employees.ClearSelection();

            data_GridView_Employees.CellClick -= DataGridView_Employees_CellClick;
            data_GridView_Employees.CellClick += DataGridView_Employees_CellClick;
        }

        private async void btn_Reload_Click(object sender, EventArgs e)
        {
           await LoadEmployeeTables();
        }
    }
}
