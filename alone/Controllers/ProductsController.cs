using alone.Domin.Servises;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CategoriesResponse>> ListAsync()
        {
            var categories = await _productService.ListAsync();
            var resources = _mapper.Map<IEnumerable<CategoriesResponse>>(categories);
            return Ok(resources);
        }
    }
}
