using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeStore.Data.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public StoresController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_unitOfWork.StoreRepository.GetAll());
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            return Ok(_unitOfWork.StoreRepository.GetById(Id));
        }

    }
}