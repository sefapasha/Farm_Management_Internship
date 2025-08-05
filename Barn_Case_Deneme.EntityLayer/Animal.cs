using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barn_Case_Deneme.EntityLayer;

namespace Barn_Case_Deneme.EntityLayer
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int LifeSpan { get; set; } // Hayat süresi
        public int ProductCount { get; set; }
        public int ProductInterval { get; set; } // Ürün üretme sıklığı
        public int Price { get; set; } // Satış fiyatı
        public object ProductName { get; set; }
        public int Progress { get; set; } = 0;

        public abstract void Produce(); // Ürün üretir
    }
}
