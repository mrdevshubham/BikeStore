using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeStore.Data.Models;
using BikeStore.Data.Repositories;
using BikeStore.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandRepository _brandRepository;
        public BrandsController(IBrandRepository brandRepository)
        {
            this._brandRepository = brandRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_brandRepository.GetAll());
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            return Ok(_brandRepository.GetById(Id));
        }

        [HttpPost]
        public IActionResult Post(BrandRequestModel brandRequestModel)
        {
            Brands brand = new Brands
            {
                BrandName = brandRequestModel.BrandName
            };

            return Ok(_brandRepository.Add(brand));
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            return Ok(_brandRepository.Delete(Id));
        }


    }
}