using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lich_van_nien
{
    public partial class Lich : Form
    {
        string[] viet = new string[] { "Chủ Nhật", "Thứ Hai", "Thứ Ba", "Thứ Tư", "Thứ Năm", "Thứ Sáu", "Thứ Bảy" };
        public Lich()
        {
            InitializeComponent();
        }

        private void Lich_Load(object sender, EventArgs e)
        {
            System.DateTime today = DateTime.Now;
            //Day
            label1.Text = today.Day.ToString();
            //Month
            label2.Text = today.Month.ToString();
            //Year
            label3.Text = today.Year.ToString();
            //WeekDay
            label4.Text = viet[(int)today.DayOfWeek];
        }

    }
}
