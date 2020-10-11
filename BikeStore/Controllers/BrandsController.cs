using AutoMapper;
using BikeStore.Business.Service;
using BikeStore.Data.Models;
using BikeStore.Data.Repositories.UnitOfWork;
using BikeStore.Model.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BikeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;
        private readonly ILogger<BrandsController> _logger;

        public BrandsController(IBrandService brandService, IMapper mapper, ILogger<BrandsController> logger)
        {
            this._brandService = brandService;
            this._mapper = mapper;
            this._logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Get All Brands...");
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
            return Ok(_brandService.Add(_mapper.Map<Brands>(brandRequestModel)));
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            return Ok(_brandService.Delete(Id) ? "Record Deleted Successfully..." : "");
        }


    }
}