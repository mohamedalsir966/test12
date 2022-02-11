using alone.Domin;
using alone.Domin.Servises;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using alone.Resources;
using alone.Extensions;

namespace alone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        //to see update in master
        private readonly IcategoryServices _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(IcategoryServices categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CategoriesResponse>> GetAllAsync()
        {
            var categories = await _categoryService.ListAsync();
            var resources = _mapper.Map<IEnumerable <CategoriesResponse>>(categories);
            return Ok(resources);
        }

        [HttpPost]
        public async Task<ActionResult> PostAllAsync([FromBody] SaveCategoryResource resource)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await _categoryService.SaveAsync(category);
            var categoryResource = _mapper.Map<Category, CategoriesResponse>(result);
            return Ok(categoryResource);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await _categoryService.UpdateAsync(id, category);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var result = await _categoryService.DeleteAsync(id);
            var deleteditem = _mapper.Map<Category, CategoriesResponse>(result.Category);
            return Ok(deleteditem);
        }

    }
}
