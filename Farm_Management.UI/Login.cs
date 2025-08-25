using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Barn_Case_Deneme.UI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kullanici_adi = textBox1.Text;
            string sifre = textBox2.Text;

            if (kullanici_adi == "admin" && sifre == "1234")
            {
                SuccessPopup popup = new SuccessPopup();
                popup.ShowDialog();  // Modal olarak göster, popup kapanana kadar bekle.

                this.DialogResult = DialogResult.OK;  // Popup kapandıktan sonra formu kapat.
                this.Close();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Clear();
                textBox2.Clear();
            }
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick(); // Login butonuna tıklamış gibi yapar
            }
        }
        private void textbox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus(); // Şifre kutusuna odaklanır
            }
        }
    }
}
