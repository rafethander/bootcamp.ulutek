using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace net_core_bootcamp_b1_Hander.Controllers
{
    [Route("api/[Controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static readonly IList<Product> data = new List<Product>();

        [HttpPost("Add")]
        public IActionResult Add([FromBody]Product model)
        {
            model.Id = Guid.NewGuid();
            model.CreatedAt = DateTime.UtcNow;

            data.Add(model);

            return Ok($"{model.Name} eklendi");
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody]Product model)
        {
            if (model.Id == null)
                return BadRequest("id alanı boş geçilemez");

            var rec = data.Where(x => x.Id == model.Id).FirstOrDefault();
            if (rec == null)
                return BadRequest($"{model.Id} 'e ait kayıt bulunamadı");

            rec.Name = model.Name;
            rec.Price = model.Price;
            rec.Desc = model.Desc;

            return Ok($"{model.Id} 'e ait kayıt güncellendi");
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([BindRequired]Guid id)
        {
            var rec = data.Where(x => x.Id == id).FirstOrDefault();
            if (rec == null)
                return BadRequest($"{id} 'e ait kayıt bulunamadı");

            data.Remove(rec);
            return Ok($"{rec.Name} silindi");
        }

        
        [HttpGet("Get")]
        public IActionResult Get(string name = null)
        {
            var filterData = data;

            if (!string.IsNullOrWhiteSpace(name))
                filterData = data.Where(x => x.Name.Contains(name)).ToList();

            return Ok(filterData);
        }
    }
}
