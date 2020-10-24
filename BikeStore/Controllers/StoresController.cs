using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BikeStore.Business.Service;
using BikeStore.Data.Models;
using BikeStore.Model.Request;
using Microsoft.AspNetCore.Mvc;

namespace BikeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly IStoreService _storeService;
        private readonly IMapper _mapper;
        public StoresController(IStoreService storeService, IMapper mapper)
        {
            this._storeService = storeService;
            this._mapper = mapper;
        }

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok(_storeService.GetAll());
        //}

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            return Ok(_storeService.GetById(Id));
        }

        [HttpPost]
        public IActionResult Post(StoreRequestModel storeRequestModel)
        {
            return Ok(_storeService.Add(_mapper.Map<Stores>(storeRequestModel)));
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            return Ok(_storeService.Delete(Id) ? "Record Deleted Successfully..." : "");
        }

    }
}