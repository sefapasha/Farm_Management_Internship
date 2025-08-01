using System;
using System.Drawing;
using System.Windows.Forms;
using Barn_Case_Deneme.Businness;
using Barn_Case_Deneme.EntityLayer;

namespace Barn_Case_Deneme.UI.Controls
{
    public partial class UserControl1 : UserControl
    {
        private readonly AnimalManager _manager;

        public event EventHandler GoBackToMainRequested;

        public UserControl1(AnimalManager manager)
        {
            InitializeComponent();
            dataGridView1.CellPainting += dataGridView1_CellPainting;
            _manager = manager ?? throw new ArgumentNullException(nameof(manager));

            comboBox1.Items.AddRange(new string[] { "Cow", "Sheep", "Chicken" });
            comboBox2.Items.AddRange(new string[] { "1", "2", "3", "4", "5" });

            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Age", "Age");
            dataGridView1.Columns.Add("ProductCount", "Products");
            dataGridView1.Columns.Add("ProgressBar", "Progress Status");
            dataGridView1.Columns.Add("Price", "Price ($)");
            dataGridView1.Columns.Add("Total", "Total ($)");

            RefreshGrid();
        }
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["ProgressBar"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.ClipBounds, true);

                var progress = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ProgressBar"].Value);
                Rectangle rect = new Rectangle(e.CellBounds.X + 2, e.CellBounds.Y + 2,
                                               e.CellBounds.Width - 4, e.CellBounds.Height - 4);

                using (var brush = new SolidBrush(Color.LightGreen))
                    e.Graphics.FillRectangle(brush, rect.X, rect.Y, rect.Width * progress / 100, rect.Height);

                e.Handled = true;
            }
        }

        /*private void UserControl1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox1.Items.AddRange(new string[] { "Cow", "Sheep", "Chicken" });
            comboBox2.Items.AddRange(new string[] { "1", "2", "3", "4", "5" });

            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Age", "Age");

            RefreshGrid();
        }*/


        private void button1_Click(object sender, EventArgs e)
        {
            string selectedAnimal = comboBox1.SelectedItem?.ToString();
            string selectedAge = comboBox2.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedAnimal) && !string.IsNullOrEmpty(selectedAge))
            {
                // Fiyatı al
                int buyPrice = AnimalManager.AnimalBuyPrices[selectedAnimal];

                // Form1 üzerinden bakiyeye ulaş
                Form1 mainForm = this.FindForm() as Form1;
                if (mainForm != null)
                {
                    // Yeterli para var mı
                    if (mainForm.TotalBalance < buyPrice)
                    {
                        MessageBox.Show($"Yetersiz bakiye! {selectedAnimal} almak için ${buyPrice} gerekli.");
                        return;
                    }

                    // Parayı düş
                    mainForm.TotalBalance -= buyPrice;
                    mainForm.UpdateBalanceLabel(); // Label güncelle

                    string result = _manager.AddAnimal(selectedAnimal, int.Parse(selectedAge));
                    if (!string.IsNullOrEmpty(result))
                        MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        RefreshGrid();
                }
            }
            else
            {
                MessageBox.Show("Please choose both an animal and age.");
            }
        }


        public void RefreshGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (var animal in _manager.Animals)
            {
                int rowIndex = dataGridView1.Rows.Add(
                    animal.Name,
                    animal.Age,
                    animal.ProductCount,
                    animal.Progress,
                    animal.Price,
                    animal.ProductCount * animal.Price
                );

                // ProgressBar hücresi
                dataGridView1.Rows[rowIndex].Cells["ProgressBar"].Value = animal.Progress;
            }
        }



    }
}
