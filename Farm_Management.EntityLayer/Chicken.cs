using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barn_Case_Deneme.EntityLayer
{
    public class Chicken : Animal
    {
        public Chicken()
        {
            Name = "Chicken";
            LifeSpan = 3; // hayvan yaşını gösteren
            Price = 5;
            ProductInterval = 3;  // 3 saniyede bir yumurta üretir
        }

        public override void Produce()
        {
            ProductCount++;
            Console.WriteLine("Chicken laid an egg! Total eggs: " + ProductCount);
        }
    }
}
