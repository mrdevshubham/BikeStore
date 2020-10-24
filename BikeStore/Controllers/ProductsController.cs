using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BikeStore.Business.Service;
using BikeStore.Data.Models;
using BikeStore.Data.Repositories.UnitOfWork;
using BikeStore.Model.Filters;
using BikeStore.Model.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productsService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productsService, IMapper mapper)
        {
            this._productsService = productsService;
            this._mapper = mapper;
        }

        [HttpGet("{CurrentPage}/{TotalRecordsPerPage}")]
        public IActionResult Get(int CurrentPage, int TotalRecordsPerPage)
        {
            return Ok(_productsService.GetAll(CurrentPage, TotalRecordsPerPage));
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            return Ok(_productsService.GetById(Id));
        }

        [HttpGet("getproductsFiltered")]
        public async Task<IActionResult> Get([FromQuery]ProductsFilter productsFilter)
        {
            return Ok(await _productsService.GetProductsFiltered(productsFilter));
        }

        [HttpPost]
        public IActionResult Post(ProductRequestModel productRequestModel)
        {
            return Ok(_productsService.Add(_mapper.Map<Products>(productRequestModel)));
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            return Ok(_productsService.Delete(Id));
        }

    }
}