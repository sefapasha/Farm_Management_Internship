using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barn_Case_Deneme.UI
{
    public partial class SuccessPopup : Form
    {
        private Timer timer;
        // Girişin Başarılı olduğuna dair bir pop-up mesajı oluşturan form
        public SuccessPopup()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightGreen;
            this.Width = 666;
            this.Height = 200;
            this.TopMost = true;

            Label label = new Label();
            label.Text = "Giriş Başarılı!";
            label.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            label.ForeColor = Color.Black;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Dock = DockStyle.Fill;
            this.Controls.Add(label);

            timer = new Timer();
            timer.Interval = 2000; // 2 saniye gösterilecek
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            this.Close();
        }
    }
}
