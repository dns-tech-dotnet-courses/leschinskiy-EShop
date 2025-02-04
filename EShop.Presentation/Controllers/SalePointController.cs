using EShop.Application;
using EShop.DAL;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalePointController : ControllerBase
    {
        [HttpGet("getAll")]
        public IEnumerable<SalePointDto> Get([FromQuery] decimal? areaFilter, [FromQuery] short? sortOrder)
        {
            var handler = new SalePointHandler(new InMemorySalePointRepository());
            var salePoints = handler.Get();

            if (areaFilter is not null)
                salePoints = salePoints.Where(p => p.SaleArea <= areaFilter);

            if (sortOrder is not null)
            {
                salePoints = sortOrder > 0
                    ? salePoints.OrderByDescending(p => p.SaleArea)
                    : salePoints.OrderBy(p => p.SaleArea);
            }

            var listOfDto = new List<SalePointDto>();
            foreach (var salePoint in salePoints)
                listOfDto.Add(new SalePointDto { Name = salePoint.Name, SaleArea = salePoint.SaleArea });

            return listOfDto;

        }

        [HttpGet("getById")]
        public IEnumerable<SalePointDto> GetById(int? id)
        {
            var handler = new SalePointHandler(new InMemorySalePointRepository());
            var salePoints = handler.GetById(id);

            var listOfDto = new List<SalePointDto>();
            foreach (var salePoint in salePoints)
                listOfDto.Add(new SalePointDto { Name = salePoint.Name, SaleArea = salePoint.SaleArea });

            return listOfDto;
        }
    }
}
