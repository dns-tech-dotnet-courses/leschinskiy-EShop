using EShop.Domain;

namespace EShop.DAL
{
    public class InMemorySalePointRepository : ISalePointRepository
    {
        private SalePoint[] products =
        [
            new SalePoint { Id = 1, Name = "Спортивная", SaleArea = 333 },
            new SalePoint { Id = 2, Name = "Гоголя", SaleArea = 444 },
            new SalePoint { Id = 3, Name = "Максим", SaleArea = 555 },
            new SalePoint { Id = 4, Name = "Бачурин", SaleArea = 666 },
            new SalePoint { Id = 5, Name = "Авангард", SaleArea = 777 }
        ];

        public IEnumerable<SalePoint> GetAll()
        {
            return products;
        }

        public IEnumerable<SalePoint> GetById(int? id)
        {
            var list = new List<SalePoint>();
            foreach (var item in products)
            {
                if (id != null && item.Id == id)
                    list.Add(item);
            }
            return list;
        }
    }
}
