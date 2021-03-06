﻿using AutoMapper;
using BikeStore.Business.Service;
using BikeStore.Data.Models;
using BikeStore.Data.Repositories.UnitOfWork;
using BikeStore.Model.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace BikeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    //[Authorize(Roles = "Admin")]
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
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Get All Brands...");
            return Ok(await _brandService.GetAll());
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

        [HttpPost("UpdateBrand")]
        public IActionResult PostUpdate(BrandRequestModel brandRequestModel)
        {
            return Ok(_brandService.Update(_mapper.Map<Brands>(brandRequestModel)));
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            return Ok(_brandService.Delete(Id) ? "Record Deleted Successfully..." : "");
        }


    }
}