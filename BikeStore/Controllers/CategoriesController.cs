using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeStore.Data.Models;
using BikeStore.Data.Repositories;
using BikeStore.Data.Repositories.UnitOfWork;
using BikeStore.Model.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoriesController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_unitOfWork.CategoriesRepository.GetAll());
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            return Ok(_unitOfWork.CategoriesRepository.GetById(Id));
        }

        [HttpPost]
        public IActionResult Post(CategoryRequestModel categoryRequestModel)
        {
            Categories category = new Categories { CategoryName = categoryRequestModel.CategoryName };
            _unitOfWork.CategoriesRepository.Add(category);
            var Result = _unitOfWork.Complete();
            return Ok(category);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _unitOfWork.CategoriesRepository.Delete(Id);
            _unitOfWork.Complete();
            return Ok("Record Deleted Successfully...");
        }
    }

}