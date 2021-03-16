using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Swegger --> dökümantasyonlu api

            //Dependency chain --
            //IProductService productService = new ProductManager(new EfProductDal());
            var result = _categoryService.GetAll();

            if (result.Success == true)
            {
                //return Ok(result.Data);
                return Ok(result);
            }

            //return BadRequest(result.Message);
            return BadRequest(result);
        }

    }
}
