using System;
using System.Collections.Generic;
using System.IO;
using Barn_Case_Deneme.EntityLayer;

namespace Barn_Case_Deneme.DataAccess
{
    public static class FarmData
    {
        private static string filePath = "farmData.txt";

        // KAYDET
        public static void SaveFarmData(List<Animal> animals, int cash)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Cash={cash}");
                foreach (var animal in animals)
                {
                    writer.WriteLine($"{animal.Name},{animal.Age},{animal.ProductCount},{animal.LifeSpan},{animal.Price}");
                }
            }
        }

        // YÜKLE
        public static (List<Animal> Animals, int Cash) LoadFarmData()
        {
            var animals = new List<Animal>();
            int cash = 0;

            if (!File.Exists(filePath))
                return (animals, cash);

            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                if (line.StartsWith("Cash="))
                {
                    int.TryParse(line.Substring(5), out cash);
                    continue;
                }

                string[] parts = line.Split(',');
                if (parts.Length != 5) continue;

                string type = parts[0];
                int age = int.Parse(parts[1]);
                int productCount = int.Parse(parts[2]);
                int lifeSpan = int.Parse(parts[3]);
                int price = int.Parse(parts[4]);

                Animal animal = null;
                switch (type)
                {
                    case "Cow":
                        animal = new Cow();
                        break;
                    case "Sheep":
                        animal = new Sheep();
                        break;
                    case "Chicken":
                        animal = new Chicken();
                        break;
                    default:
                        animal = null;
                        break;
                }


                if (animal != null)
                {
                    animal.Age = age;
                    animal.ProductCount = productCount;
                    animal.LifeSpan = lifeSpan;
                    animal.Price = price;
                    animals.Add(animal);
                }
            }

            return (animals, cash);
        }
    }
}
