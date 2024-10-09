using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class frm_BaoCao : Form
    {
        public frm_BaoCao()
        {
            InitializeComponent();
        }
        DataProvider DataProvider = new DataProvider();
        private void btn_Timkiem_Click(object sender, EventArgs e)
        {
            DateTime selected = dtp_date.Value.Date;
            string select = cb_BaoCao.SelectedItem.ToString().Trim();
            string sql;
            if (select == "Doanh thu theo ngày")
            {
                sql = $"SELECT  CONVERT(DATE, DATETIME) AS N'Ngày' ,SUM(TOTAL) AS N'Doanh Thu'" +
                    $"FROM SAVEBILL WHERE CONVERT(DATE, DATETIME) = '{selected.ToString("yyyy-MM-dd")}' " +
                    $"GROUP BY CONVERT(DATE, DATETIME)";
                DataTable dt = DataProvider.loadData1(sql);
                dgv_BaoCao.DataSource = dt;


            }
            else if (select == "Doanh thu theo tuần")
            {
                sql = $"SELECT   DATEPART(WEEK, DATETIME) AS N'Tuần', SUM(TOTAL) AS N'Doanh Thu'" +
                    $" FROM SAVEBILL " +
                    $"WHERE DATEPART(YEAR, DATETIME) = '{selected.Year}' AND DATEPART(WEEK, DATETIME) = DATEPART(WEEK, '{selected.ToString("yyyy-MM-dd")}') " +
                    $"GROUP BY DATEPART(WEEK, DATETIME)";
                DataTable dt = DataProvider.loadData1(sql);
                dgv_BaoCao.DataSource = dt;

            }
            else if (select == "Doanh thu theo tháng")
            {
                sql = $"SELECT DATEPART(MONTH, DATETIME) AS N'Tháng', SUM(TOTAL) AS N'Doanh Thu'" +
                    $"FROM SAVEBILL " +
                    $"WHERE DATEPART(YEAR, DATETIME) = '{selected.Year}' AND DATEPART(MONTH, DATETIME) = '{selected.Month}' " +
                    $"GROUP BY DATEPART(MONTH, DATETIME)";
                DataTable dt = DataProvider.loadData1(sql);
                dgv_BaoCao.DataSource = dt;

            }

        }

        private void frm_BaoCao_Load(object sender, EventArgs e)
        {
            DateTime selected = dtp_date.Value.Date;
            string sql = $"SELECT  CONVERT(DATE, DATETIME) AS N'Ngày' ,SUM(TOTAL) AS N'Doanh Thu'" +
                   $"FROM SAVEBILL WHERE CONVERT(DATE, DATETIME) = '{selected.ToString("yyyy-MM-dd")}' " +
                   $"GROUP BY CONVERT(DATE, DATETIME)";
            DataTable dt = DataProvider.loadData1(sql);
            dgv_BaoCao.DataSource = dt;
        }
    }
}
