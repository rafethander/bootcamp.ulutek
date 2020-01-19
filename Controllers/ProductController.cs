using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using net_core_bootcamp_b1_Hander.DTOs;
using net_core_bootcamp_b1_Hander.Helpers;
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
        public async Task<IActionResult> Add([FromBody]ProductAddDto model)
        {
            var result =await _productservice.Add(model);
            if (result.Message != ApiResultMessages.Ok)
                return BadRequest(result);

            return Ok(result);
        }
        /// <summary>
        /// Git Example Master
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody]ProductUpdateDto model)
        {
            var result =await _productservice.Update(model);
            if (result.Message != ApiResultMessages.Ok)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([BindRequired]Guid id)
        {
            var result =await _productservice.Delete(id);
            if (result.Message != ApiResultMessages.Ok)
                return BadRequest(result);
            return Ok(result);
        }

        
        [HttpGet("Get")]
        [ProducesResponseType(typeof(IList<ProductGetDto>),200)]
        public async Task<IActionResult> Get()
        {
            var result =await _productservice.Get();

            return Ok(result);  
        }
        
    }
}
