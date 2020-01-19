using Microsoft.EntityFrameworkCore;
using net_core_bootcamp_b1_Hander.Database;
using net_core_bootcamp_b1_Hander.Database.Models;
using net_core_bootcamp_b1_Hander.DTOs;
using net_core_bootcamp_b1_Hander.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_core_bootcamp_b1_Hander.Services
{
    public interface IProductService
    {
        Task<ApiResult> Add(ProductAddDto model);
        Task<ApiResult> Update(ProductUpdateDto model);
        Task<ApiResult> Delete(Guid id);
        Task <IList<ProductGetDto>> Get();

    }
    public class ProductServices : IProductService
    {
        private readonly BootcampHanderDbContext _context;
        public ProductServices(BootcampHanderDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResult> Add(ProductAddDto model)
        {
            Product entity = new Product
            {
               Id=Guid.NewGuid(),
               CreatedAt=DateTime.UtcNow
            };

            entity.Name = model.Name;
            entity.Desc = model.Desc;
            entity.Price = model.Price ?? 0;
          
            await _context.Product.AddAsync(entity);
            await _context.SaveChangesAsync();

            return new ApiResult {Data=entity.Id,Message=ApiResultMessages.Ok };
            

        }

        public async Task<ApiResult> Delete(Guid id)
        {
            var entity = await _context.Product.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (entity == null)
                return new ApiResult { Data = entity.Id, Message = ApiResultMessages.PRE01 };

            entity.IsDeleted = true;

            await _context.SaveChangesAsync();

            return new ApiResult { Data = entity.Id, Message = ApiResultMessages.Ok };
        }

        public async Task<IList<ProductGetDto>> Get()
        {
            var result = new List<ProductGetDto>();
            result = await _context.Product
                .Where(x => !x.IsDeleted)
                .Select(s => new ProductGetDto
                {
                    Id=(Guid)s.Id,
                    Name=s.Name,
                    CreatedAt=s.CreatedAt,
                    Price=s.Price,
                    Desc=s.Desc

                }).ToListAsync();

            return result;
        }

        public async Task<ApiResult> Update(ProductUpdateDto model)
        {
            var entity = await _context.Product.Where(x => !x.IsDeleted && x.Id == model.Id).FirstOrDefaultAsync();
            if (entity == null)
                return new ApiResult { Data = entity.Id, Message = ApiResultMessages.PRE01 };

            _context.Entry<Product>(entity).State = EntityState.Modified;
            entity.Name = model.Name;
            entity.Desc = model.Desc;

            await _context.SaveChangesAsync();



            return new ApiResult { Data = entity.Id, Message = ApiResultMessages.Ok };

        }
        
    }
}
