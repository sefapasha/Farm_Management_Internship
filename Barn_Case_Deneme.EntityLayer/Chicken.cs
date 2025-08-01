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
            LifeSpan = 10;
            Price = 8;
            ProductInterval = 3;  // 3 saniyede bir yumurta üretir
            Price = 5;
        }

        public override void Produce()
        {
            ProductCount++;
            Console.WriteLine("Chicken laid an egg! Total eggs: " + ProductCount);
        }
    }
}
