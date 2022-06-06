using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Lich_van_nien
{
    public partial class Lich : Form
    {
        string[] viet = new string[] { "Chủ Nhật", "Thứ Hai", "Thứ Ba", "Thứ Tư", "Thứ Năm", "Thứ Sáu", "Thứ Bảy" };
        string[] jap = new string[] { "日", "月", "火", "水", "木", "金", "土" };

        System.DateTime today = new System.DateTime();
    
        public Lich()
        {
            InitializeComponent();
        }

        public void display(System.DateTime date)
        {
            //SOLAR
            //System.DateTime date = DateTime.Now;
            ngaythang.Text = date.Year.ToString() + "年" + date.Month.ToString() + "月" + date.Day.ToString() + "日" + "(" + jap[(int)date.DayOfWeek] + ")";
            thu.Text = viet[(int)date.DayOfWeek];

            //LUNAR
            VietnameseCalendar vCal = new VietnameseCalendar();
            int y, m, d;
            vCal.FromDateTime(date, out y, out m, out d);
            namam.Text = "Năm " + VietnameseCalendar.GetYearName(y);//Tên Năm
            ngayamso.Text = d.ToString() + "/" + m.ToString(); //ngày âm (số)
            ngayamchu.Text = "Ngày " + VietnameseCalendar.GetDayName(date); //Tên Can Chi ngày
            thangamchu.Text = "Tháng " + VietnameseCalendar.GetMonthName(y, m); //Tên Can Chi tháng
        }

        private void Lich_Load(object sender, EventArgs e)
        {
            //SOLAR
            today = DateTime.Now;
            display(today);

            //quote stuffs
            string RunningPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string FileName = string.Format("{0}Resources\\danhngon.txt", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));
            string[] lines = System.IO.File.ReadAllLines(FileName);
            Random ran = new Random();
            int choice = ran.Next(24);
            //
            string quote = lines[choice];
            int pos = quote.IndexOf("~");
            quotebox.Text = quote.Substring(0, pos);
            //who.Text = "- " + quote.Substring(pos + 1);
        }

        private void homqua_Click(object sender, EventArgs e)
        {
            today = today.AddDays(-1);
            display(today);
        }

        private void homnay_Click(object sender, EventArgs e)
        {
            today = DateTime.Now;
            display(today);
        }

        private void ngaymai_Click(object sender, EventArgs e)
        {
            today = today.AddDays(1);
            display(today);
        }

        private void trangay_Click(object sender, EventArgs e)
        {
            try
            {
                TraNgay win = new TraNgay();
                if (win.ShowDialog() == DialogResult.OK)
                {
                    today = win.newdate;
                    display(today);
                }
            }
            catch
            {
                MessageBox.Show("Ngày đã nhập quá xa!","LỖI XẢY RA",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
