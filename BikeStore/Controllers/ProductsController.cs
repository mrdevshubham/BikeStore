using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeStore.Data.Models;
using BikeStore.Data.Repositories.UnitOfWork;
using BikeStore.Model.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_unitOfWork.ProductsRepository.GetAll());
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            return Ok(_unitOfWork.ProductsRepository.GetById(Id));
        }

        [HttpPost]
        public IActionResult Post(ProductRequestModel productRequestModel)
        {
            Products product = new Products 
            {
                ProductName = productRequestModel.ProductName,
                BrandId = productRequestModel.BrandId,
                CategoryId = productRequestModel.CategoryId,
                ModelYear = productRequestModel.ModelYear,
                ListPrice = productRequestModel.ListPrice
            };
            _unitOfWork.ProductsRepository.Add(product);
            var Result = _unitOfWork.Complete();
            return Ok(product);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _unitOfWork.ProductsRepository.Delete(Id);
            _unitOfWork.Complete();
            return Ok("Record Deleted Successfully...");
        }

    }
}