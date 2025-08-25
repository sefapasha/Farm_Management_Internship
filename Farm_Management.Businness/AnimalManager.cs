using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Barn_Case_Deneme.EntityLayer;
using Barn_Case_Deneme.DataAccess;
using Barn_Case_Deneme.Businness;

namespace Barn_Case_Deneme.Businness
{
    public class AnimalManager
    {
        public List<Animal> Animals { get; set; } = new List<Animal>();
        public int Cash { get; set; } = 0;

        public event Action AnimalsUpdated;

        private readonly int MaxAnimalCount = 10;

        public static readonly Dictionary<string, int> AnimalBuyPrices = new Dictionary<string, int>
    {
        { "Chicken", 50 },
        { "Sheep", 100 },
        { "Cow", 150 }
    };

        public string AddAnimal(string animalType, int age)
        {
            if (IsAnimalLimitReached(animalType))
                return $"Cannot add more than {MaxAnimalCount} {animalType}s.";

            Animal newAnimal;

            switch (animalType)
            {
                case "Cow":
                    newAnimal = new Cow { Age = age };
                    break;
                case "Sheep":
                    newAnimal = new Sheep { Age = age };
                    break;
                case "Chicken":
                    newAnimal = new Chicken { Age = age };
                    break;
                default:
                    return "Unknown animal type.";
            }

            Animals.Add(newAnimal);
            AnimalsUpdated?.Invoke();
            return string.Empty;
        }

        private bool IsAnimalLimitReached(string animalType)
        {
            int count = 0;
            foreach (var a in Animals)
            {
                if (a.Name == animalType) count++;
            }
            return count >= MaxAnimalCount;
        }

        /*public void SellProduct(Animal animal)
        {
            Cash += animal.ProductCount * animal.Price;
            animal.ProductCount = 0;
            AnimalsUpdated?.Invoke();
        }

        public void UpdateAnimals()
        {
            var deadAnimals = new List<Animal>();

            foreach (var animal in Animals)
            {
                animal.Age++;

                if (animal.Age >= animal.LifeSpan)
                {
                    deadAnimals.Add(animal);
                    continue;
                }

                if (animal.Age % animal.ProductInterval == 0)
                {
                    animal.Produce();
                }
            }

            foreach (var dead in deadAnimals)
                Animals.Remove(dead);

            AnimalsUpdated?.Invoke();
        }*/



        /*public void SaveFarm()
        {
            FarmData.SaveFarmData(Animals, Cash);
        }

        public void LoadFarm()
        {
            var data = FarmData.LoadFarmData();
            Animals.Clear();
            foreach (var animal in data.Animals)
                Animals.Add(animal);

            Cash = data.Cash;
            AnimalsUpdated?.Invoke();
        }*/
        /*public void Produce()
        {
            foreach (var animal in Animals)
            {
                animal.Produce(); // Her hayvan kendi ürün üretim metodunu çalıştırır
            }
            AnimalsUpdated?.Invoke(); // UI'ya haber ver
        }
        public int Sell()
        {
            int totalProducts = 0;
            foreach (var animal in Animals)
            {
                totalProducts += animal.ProductCount;
                animal.ProductCount = 0; // Ürünler satıldıktan sonra sıfırlanır
            }
            Cash += totalProducts * 10; // Örnek fiyat, gerçek uygulamada dinamik olabilir
            AnimalsUpdated?.Invoke(); // UI'ya haber ver
            return totalProducts;
        }*/
    }



    /* public class AnimalManager
     {
         public List<Animal> Animals { get; private set; } = new List<Animal>();
         public int Cash { get; private set; } = 0;
         public event Action AnimalsUpdated; // UI'yi bilgilendirmek için

         private readonly int MaxAnimalCount = 5; // İstersen değiştirebilirsin

         // Yeni hayvan ekler
         public string AddAnimal(string animalType, int age)
         {
             if (IsAnimalLimitReached(animalType))
                 return $"Cannot add more than {MaxAnimalCount} {animalType}s.";

             Animal newAnimal;

             switch (animalType)
             {
                 case "Cow":
                     newAnimal = new Cow { Age = age };
                     break;
                 case "Sheep":
                     newAnimal = new Sheep { Age = age };
                     break;
                 case "Chicken":
                     newAnimal = new Chicken { Age = age };
                     break;
                 default:
                     newAnimal = null;
                     break;
             }

             if (newAnimal == null)
                 return "Unknown animal type.";

             Animals.Add(newAnimal);
             AnimalsUpdated?.Invoke();
             return string.Empty; // Hatasız
         }

         // Hayvanın ürününü sat ve kasayı güncelle
         public void SellProduct(Animal animal)
         {
             Cash += animal.ProductCount * animal.Price;
             animal.ProductCount = 0;
             AnimalsUpdated?.Invoke();
         }

         // Tüm hayvanları güncelle (yaş + ürün üretimi + ölüm kontrolü)
         public void UpdateAnimals()
         {
             var deadAnimals = new List<Animal>();

             foreach (var animal in Animals)
             {
                 animal.Age++; // Her tikte 1 yaş büyüt
                 if (animal.Age >= animal.LifeSpan)
                 {
                     deadAnimals.Add(animal);
                     continue;
                 }

                 // Ürün üretimi
                 if (animal.Age % animal.ProductInterval == 0)
                 {
                     animal.Produce();
                 }
             }

             // Ölü hayvanları kaldır
             foreach (var dead in deadAnimals)
                 Animals.Remove(dead);

             AnimalsUpdated?.Invoke();
         }

         private bool IsAnimalLimitReached(string animalType)
         {
             int count = Animals.Count(a => a.Name == animalType);
             return count >= MaxAnimalCount;
         }
     }*/
}
