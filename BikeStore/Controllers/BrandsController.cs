using BikeStore.Business.Service;
using BikeStore.Data.Models;
using BikeStore.Data.Repositories.UnitOfWork;
using BikeStore.Model.Request;
using Microsoft.AspNetCore.Mvc;

namespace BikeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;
        public BrandsController(IBrandService brandService)
        {
            this._brandService = brandService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_brandService.GetAll());
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            return Ok(_brandService.GetById(Id));
        }

        [HttpPost]
        public IActionResult Post(BrandRequestModel brandRequestModel)
        {
            return Ok(_brandService.Add(brandRequestModel));
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            return Ok(_brandService.Delete(Id) ? "Record Deleted Successfully..." : "");
        }


    }
}