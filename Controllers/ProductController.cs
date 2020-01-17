using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using net_core_bootcamp_b1_Hander.DTOs;
using net_core_bootcamp_b1_Hander.Models;
using net_core_bootcamp_b1_Hander.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace net_core_bootcamp_b1_Hander.Controllers
{
    [Route("api/[Controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    public class ProductController : ControllerBase
    {
       

        private readonly IProductService _productservice;
        public ProductController(IProductService productService)
        {
            _productservice = productService;
        }

        /// <summary>
        /// Git Examples Changes
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost("Add")]
        public IActionResult Add([FromBody]ProductAddDto model)
        {
            var result = _productservice.Add(model);

            return Ok(result);
        }
        /// <summary>
        /// Git Example Master
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        public IActionResult Update([FromBody]ProductUpdateDto model)
        {
            var result = _productservice.Update(model);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([BindRequired]Guid id)
        {
            var result = _productservice.Delete(id);
            return Ok(result);
        }

        
        [HttpGet("Get")]
        [ProducesResponseType(typeof(IList<ProductGetDto>),200)]
        public IActionResult Get()
        {
            var result = _productservice.Get();

            return Ok(result);  
        }
    }
}
