using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barn_Case_Deneme.EntityLayer
{
    public class Cow : Animal
    {
        public Cow()
        {
            Name = "Cow";
            LifeSpan = 8;
            ProductInterval = 5;  // 5 saniyede bir süt üretir
            Price = 15;           // Süt başına 15$
        }


        public override void Produce()
        {
            ProductCount++;
            Console.WriteLine("Cow produced milk! Total milk: " + ProductCount);
        }
    }
}
