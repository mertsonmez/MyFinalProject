using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")] //route --> api/ controllerınızın ismi [controller] hangi kontrollerdaysan
    [ApiController] //Attribute c# --> bir classla ilgili bilgi verme ve onu imzalama yöntemidir. bu class bir controllerdır demek [apicontroller]
    public class ProductsController : ControllerBase
    {
        //Loosely coupled -- gevşek bağlılık (yani bir bhağımlılığı var ama soyuta bir bağımlılığı var demek)
        IProductService _productService; //field ların defaultu private dır. alt çizgili olması naming convension yani isimnlendirme kuralıdır.
        //IoC container -- Inversion of Control -- değişimin kontrolü..
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        //
        //contoller baseden implement edilmesi lazım4
        //ve attribute u olması lazım javada annotation deriz

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Swegger --> dökümantasyonlu api

            //Dependency chain --
            //IProductService productService = new ProductManager(new EfProductDal());
            var result = _productService.GetAll();

            if (result.Success == true)
            {
                //return Ok(result.Data);
                return Ok(result);
            }

            //return BadRequest(result.Message);
            return BadRequest(result);
        }

        //1.yol
        [HttpGet("getbyid")]
        //public IActionResult GetById(int id) --> hocanın yazdığı
        //public IActionResult GetProductById(int id) -- yapmıştım değiştiridk.
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        //2.yol da routing mantığı ile isim verme !!!
        //alias yöntemi yani methoda isim veriyoruz
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);

            if (result.Success) //bool değerlerin defaultuı true dur !! o yüzden == true yapmadık !!!
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        //güncelleme ve silme içinde HttpPost kullanabilirsin !! yada güncelleme için HttpPut ve silme için HttpDelete kullanırsan kategorileştirmiş olursun !!
        //ama sektörde

        [HttpGet("getbycategory")]
        public IActionResult GetByCategory(int categoryId)
        {
            var result = _productService.GetAllByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        //intensional programing !!! hocanın dediği üzere niyet güdümlü programlama :D contollerdan başlanıyor tasarlamaya

    }
}
