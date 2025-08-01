using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Barn_Case_Deneme.Businness;
using Barn_Case_Deneme.EntityLayer;
using Barn_Case_Deneme.UI.Controls;

namespace Barn_Case_Deneme.UI
{
    public partial class Form1 : Form
    {

       // private int progressStep = 0;   // Hangi hayvanda üretim yapıyoruz
        //private int currentProgress = 0; // O anki hayvanın üretim progressi (0-100)
        private AnimalManager manager = new AnimalManager();
        private int totalBalance = 0;

        public int TotalBalance
        {
            get { return totalBalance; }
            set { totalBalance = value; }
        }

        public void UpdateBalanceLabel()
        {
            labelTotalMoney.Text = $"Total: ${totalBalance}";
        }


        public Form1()
        {
            InitializeComponent();
            manager.AddAnimal("Sheep", 1); // Başlangıçta 1 koyun
            UpdateList();
            labelTotalMoney.Text = $"Total: ${totalBalance}";
            timer1.Interval = 100;
            timer1.Tick += timer1_Tick;
        }


        private void UpdateList()
        {
            listBox1.Items.Clear();
            foreach (var animal in manager.Animals)
            {
                listBox1.Items.Add($"{animal.Name} - Products: {animal.ProductCount} (Progress: {animal.Progress}%)");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                timer1.Start();
            }
        }
        /*private void button1_Click_1(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            progressBar1.Maximum = manager.Animals.Count; // hayvan sayısına göre
            progressStep = 0;
            //timer1.Start(); // Timer başlatılıyor
            manager.Produce();
            UpdateList();
        
        }*/

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (manager.Animals.Count == 0)
            {
                MessageBox.Show("Hiç hayvan yok, satılacak ürün yok!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            StringBuilder sb = new StringBuilder();
            int totalMoney = 0;

            foreach (var animal in manager.Animals)
            {
                int productCount = animal.ProductCount;
                if (productCount > 0)
                {
                    int price = animal.Price;  // 🔹 Artık hayvanın kendi fiyatını kullanıyoruz
                    int animalTotal = productCount * price;
                    totalMoney += animalTotal;

                    sb.AppendLine($"{animal.Name} - {productCount} ürün x ${price} = ${animalTotal}");

                    animal.ProductCount = 0;
                }
            }

            if (totalMoney == 0)
            {
                MessageBox.Show("Satılacak ürün yok!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 🔹 Artık totalBalance üzerine ekliyoruz
            totalBalance += totalMoney;
            labelTotalMoney.Text = $"Total: ${totalBalance}";

            sb.AppendLine($"---------------------\nToplam Kazanç: ${totalMoney}");
            MessageBox.Show(sb.ToString(), "Satış Özeti", MessageBoxButtons.OK, MessageBoxIcon.Information);

            UpdateList();
        }



        private void ShowControl(UserControl control)
        {
            if (control != null)
            {
                panel2.Controls.Clear();
                panel2.Dock = DockStyle.Fill;
                panel2.Controls.Add(control);
            }
            else
            {
                MessageBox.Show("Page not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void button3_Click_1(object sender, EventArgs e)
        {
            UserControl1 uc = new UserControl1(manager);

            uc.GoBackToMainRequested += (s, ev) =>
            {
                panel2.Controls.Clear();
                ShowMainUI();
                UpdateList();
            };

            ShowControl(uc);
            HideMainUI();
        }

        private void ShowMainUI()
        {
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            listBox1.Visible = true;
            labelTotalMoney.Visible = true;
        }

        private void HideMainUI()
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            listBox1.Visible = false;
            labelTotalMoney.Visible = false;
        }

        // private bool alreadyShownCompletionMessage = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var animal in manager.Animals)
            {
                // Progress artışı hayvanın hızına göre
                int step = 100 / (animal.ProductInterval * 10); // Örnek: 10 tick = 1 sn
                if (step < 1) step = 1;

                animal.Progress += step;

                if (animal.Progress >= 100)
                {
                    animal.Progress = 0;
                    animal.ProductCount++;
                }
            }

            if (panel2.Controls.OfType<UserControl1>().FirstOrDefault() is UserControl1 uc)
                uc.RefreshGrid();

            UpdateList();
        }




        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear(); // UserControl'ü temizle

            // Ana bileşenleri görünür yap
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            listBox1.Visible = true;
            labelTotalMoney.Visible = true;

            UpdateList(); // Listeyi güncelle
        }
    }
}
