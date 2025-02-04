using EShop.Domain;

namespace EShop.Application
{
    public class SalePointHandler
    {
        private readonly ISalePointRepository _salePointRepository;

        public SalePointHandler(ISalePointRepository salePointRepository)
        {
            _salePointRepository = salePointRepository;
        }

        public IEnumerable<SalePoint> Get()
        {
            var salePoints = _salePointRepository.GetAll();
            return MutateSalePoints(salePoints);
        }

        public IEnumerable<SalePoint> GetById(int? id)
        {
            var salePoints = _salePointRepository.GetById(id);
            return MutateSalePoints(salePoints);
        }

        private IEnumerable<SalePoint> MutateSalePoints(IEnumerable<SalePoint> salePoints)
        {
            var mutatedList = new List<SalePoint>();

            foreach (var point in salePoints)
            {
                mutatedList.Add(new SalePoint
                {
                    Id = point.Id,
                    Name = point.Name,
                    SaleArea = point.SaleArea * 100
                });
            }

            return mutatedList;
        }
    }
}