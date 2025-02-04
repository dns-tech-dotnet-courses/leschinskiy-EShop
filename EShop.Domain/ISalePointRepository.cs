namespace EShop.Domain
{
    public interface ISalePointRepository
    {
        IEnumerable<SalePoint> GetAll();
        IEnumerable<SalePoint> GetById(int? id);
    }
}
