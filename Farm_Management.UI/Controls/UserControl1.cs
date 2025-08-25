using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Barn_Case_Deneme.Businness;

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

            comboBox1.Text = "Select Animal";
            comboBox2.Text = "Select Age";
            comboBox1.Items.AddRange(new string[] { "Cow", "Sheep", "Chicken" });
            comboBox2.Items.AddRange(new string[] { "1", "2", "3", "4", "5" });

            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Age", "Age");
            dataGridView1.Columns.Add("ProductCount", "Products");
            dataGridView1.Columns.Add("ProgressBar", "Progress Status");
            dataGridView1.Columns.Add("Price", "Price ($)");
            dataGridView1.Columns.Add("Total", "Total ($)");

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            RefreshGrid();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selectedAnimal = comboBox1.SelectedItem.ToString();
            int price = 0;

            switch (selectedAnimal)
            {
                case "Cow":
                    price = 150;
                    break;
                case "Sheep":
                    price = 100;
                    break;
                case "Chicken":
                    price = 50;
                    break;
            }

            labelAnimalPrice.Text = $"${price}";
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
        
        private void button1_Click(object sender, EventArgs e)
        {
            string selectedAnimal = comboBox1.SelectedItem?.ToString();
            string selectedAge = comboBox2.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedAnimal) && !string.IsNullOrEmpty(selectedAge))
            {
                Form1 mainForm = this.FindForm() as Form1;
                if (mainForm != null)
                {
                    int buyPrice = AnimalManager.AnimalBuyPrices[selectedAnimal];

                    // Tek kaynaktan kontrol: _manager.Cash
                    if (_manager.Cash < buyPrice)
                    {
                        MessageBox.Show($"Yetersiz bakiye! \n{selectedAnimal} almak için ${buyPrice} gerekli.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Parayı düş
                    _manager.Cash -= buyPrice;
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
                MessageBox.Show("Lütfen Hayvanı ve Yaşını Seçiniz!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }




        public void RefreshGrid()
        {
            dataGridView1.Rows.Clear();

            foreach (var animal in _manager.Animals.ToList()) // Burada kopyaladık hayvan öldüğü an hayvan ekleyince burası patlıyordu
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
