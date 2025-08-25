using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Barn_Case_Deneme.Businness;
using Barn_Case_Deneme.DataAccess;
using Barn_Case_Deneme.EntityLayer;
using Barn_Case_Deneme.UI.Controls;

namespace Barn_Case_Deneme.UI
{
    public partial class Form1 : Form
    {

        private AnimalManager manager = new AnimalManager();
        private int totalBalance = 0;

        public int TotalBalance
        {
            get { return manager.Cash; }
            set { manager.Cash = value; }
        }

        public void UpdateBalanceLabel()
        {
            labelTotalMoney.Text = $"Total: ${manager.Cash}";
        }
        

        private BackgroundWorker lifeWorker;
        public Form1()
        {
            InitializeComponent();

            // Önce kaydedilmiş çiftliği yükle
            var loadedData = FarmData.LoadFarmData();
            manager.Animals = loadedData.Animals;
            manager.Cash = loadedData.Cash;

            // Eğer hiç hayvan yoksa, başlangıç için 1 koyun ver
            if (manager.Animals.Count == 0)
            {
                manager.AddAnimal("Sheep", 1);
            }

            UpdateList();
            labelTotalMoney.Text = $"Total: ${manager.Cash}";

            timer1.Interval = 100;
            timer1.Tick += timer1_Tick;

            // Hayat döngüsü için BackgroundWorker
            lifeWorker = new BackgroundWorker();
            lifeWorker.WorkerSupportsCancellation = true;
            lifeWorker.DoWork += LifeWorker_DoWork;
            lifeWorker.RunWorkerAsync();

            // Form kapanınca çiftliği kaydet
            this.FormClosing += Form1_FormClosing;
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
                timer1.Start(); // Üretimi başlatma
            }
        }
            
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
                    int price = animal.Price;
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

            //Tek kaynak
            manager.Cash += totalMoney;
            UpdateBalanceLabel();

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
            button6.Visible = true;
            listBox1.Visible = true;
            labelTotalMoney.Visible = true;
        }

        private void HideMainUI()
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button6.Visible = false;
            listBox1.Visible = false;
            labelTotalMoney.Visible = false;
        }

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
            ShowMainUI();
            UpdateList(); // Listeyi güncelle
        }

        private void LifeWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Random rnd = new Random();

            while (!lifeWorker.CancellationPending)
            {
                System.Threading.Thread.Sleep(30000); // 30 sn = 1 yaş

                var naturalDeaths = new List<Animal>();
                var diseaseDeaths = new List<Animal>();

                foreach (var animal in manager.Animals.ToList())
                {
                    animal.Age++;

                    bool diedNaturally = false;
                    bool diedFromDisease = false;

                    // Normal ölüm
                    if (animal.Age >= animal.LifeSpan)
                    {
                        diedNaturally = true;
                    }
                    else
                    {
                        // Hastalık / erken ölüm şansı
                        int deathChance = 0;
                        switch (animal.Name)
                        {
                            case "Chicken": deathChance = 10; break; // %10
                            case "Sheep": deathChance = 5; break;    // %5
                            case "Cow": deathChance = 3; break;      // %3
                        }

                        if (rnd.Next(0, 100) < deathChance)
                        {
                            diedFromDisease = true;
                        }
                    }

                    if (diedNaturally || diedFromDisease)
                    {
                        // Ölmeden önce ürünleri paraya çevir
                        manager.Cash += animal.ProductCount * animal.Price;

                        if (diedNaturally) naturalDeaths.Add(animal);
                        if (diedFromDisease) diseaseDeaths.Add(animal);
                    }
                }

                if (naturalDeaths.Any() || diseaseDeaths.Any())
                {
                    this.Invoke((Action)(() =>
                    {
                        //Normal ölüm mesajı
                        if (naturalDeaths.Any())
                        {
                            string msg = "Ömrü Dolan Hayvanlar:\n";
                            foreach (var dead in naturalDeaths)
                            {
                                msg += $"{dead.Name} (Yaş {dead.Age})\n";
                                manager.Animals.Remove(dead);
                            }
                            MessageBox.Show(msg, "Doğal Ölüm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        // Hastalık ölüm mesajı
                        if (diseaseDeaths.Any())
                        {
                            string msg = "Hastalık çıktı! Ölen hayvanlar:\n";
                            foreach (var dead in diseaseDeaths)
                            {
                                msg += $"{dead.Name} (Yaş {dead.Age})\n";
                                manager.Animals.Remove(dead);
                            }
                            MessageBox.Show(msg, "Hastalık!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        // Ekran güncelle
                        if (panel2.Controls.OfType<UserControl1>().FirstOrDefault() is UserControl1 uc)
                            uc.RefreshGrid();

                        UpdateList();
                        labelTotalMoney.Text = $"Total: ${manager.Cash}";
                    }));
                }
            }
        }



        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                MessageBox.Show("Üretim durduruldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Üretim zaten durdurulmuş!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Programdan çıkmak istiyor musunuz?",
                                         "Çıkış",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return; // Kullanıcı çıkmak istemiyorsa hiçbir şey yapma
            }

            if (result == DialogResult.Yes)
                FarmData.SaveFarmData(manager.Animals, manager.Cash);
                Application.Exit();    
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FarmData.SaveFarmData(manager.Animals, manager.Cash);
        }
    }
}
