using EShop.Domain;

namespace EShop.Application
{
    public class SalePointHandler
    {
        private SalePoint[] products =
        [
            new SalePoint { Id = 1, Name = "Спортивная", SaleArea = 333 },
            new SalePoint { Id = 2, Name = "Гоголя", SaleArea = 444 },
            new SalePoint { Id = 3, Name = "Максим", SaleArea = 555 },
            new SalePoint { Id = 4, Name = "Бачурин", SaleArea = 666 },
            new SalePoint { Id = 5, Name = "Авангард", SaleArea = 777 }
        ];

        public IEnumerable<SalePoint> Get()
        {
            var mutatedArray = new List<SalePoint>();
            foreach (SalePoint p in products)
                mutatedArray.Add(new SalePoint { Id = p.Id, Name = p.Name, SaleArea = p.SaleArea * 100 });

            return mutatedArray;
        }
    }
}
