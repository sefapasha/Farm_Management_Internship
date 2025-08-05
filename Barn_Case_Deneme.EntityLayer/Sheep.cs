using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barn_Case_Deneme.EntityLayer
{
    public class Sheep : Animal
    {
        public Sheep()
        {
            Name = "Sheep";
            LifeSpan = 6;
            ProductInterval = 5;  // 7 saniyede bir yün üretir
            Price = 10;           // Yün başına 10$
        }


        public override void Produce()
        {
            ProductCount++;
            Console.WriteLine("Sheep produced wool! Total wool: " + ProductCount);
        }
    }
}
