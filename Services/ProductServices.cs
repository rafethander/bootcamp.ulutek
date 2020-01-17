using net_core_bootcamp_b1_Hander.DTOs;
using net_core_bootcamp_b1_Hander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_core_bootcamp_b1_Hander.Services
{
    public interface IProductService
    {
        string Add(ProductAddDto model);
        string Update(ProductUpdateDto model);
        string Delete(Guid id);
        IList<ProductGetDto> Get();

    }
    public class ProductServices : IProductService
    {
        private static readonly IList<Product> data = new List<Product>();
        public string Add(ProductAddDto model)
        {
            Product entity = new Product
            {
               Id=Guid.NewGuid(),
               CreatedAt=DateTime.UtcNow
            };

            entity.Name = model.Name;
            entity.Desc = model.Desc;
            entity.Price = model.Price ?? 0;

            data.Add(entity);

            return $"{model.Name} Eklendi.";

        }

        public string Delete(Guid id)
        {
            var entity = data.Where(x => x.Id == id).FirstOrDefault();
            if (entity == null)
                return $"{entity.Id} 'e ait kayıt bulunamadı.";

            entity.IsDeleted = true;

            return $"{entity.Id} 'e ait kayıt silindi.";
        }

        public IList<ProductGetDto> Get()
        {
            var result = new List<ProductGetDto>();
            result = data
                .Where(x => !x.IsDeleted)
                .Select(s => new ProductGetDto
                {
                    Id=(Guid)s.Id,
                    Name=s.Name,
                    CreatedAt=s.CreatedAt,
                    Price=s.Price,
                    Desc=s.Desc

                }).ToList();

            return result;
        }

        public string Update(ProductUpdateDto model)
        {
            var entity = data.Where(x => !x.IsDeleted && x.Id == model.Id).FirstOrDefault();
            if (entity == null)
                return $"{model.Id} 'e ait kayıt bulunamadı.";

            entity.Name = model.Name;
            entity.Desc = model.Desc;

            return $"{entity.Id} 'e ait kayıt güncellendi";

        }
    }
}
