using Florist.Business.Abstract;
using Florist.DataAccessLayer.DataTransferObject.FlowerCategoryDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Florist.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowerCategoryController : ControllerBase
    {
        public IFlowerCategoryService _flowerCategoryService;
        public FlowerCategoryController(IFlowerCategoryService flowerCategoryService)
        {
            _flowerCategoryService = flowerCategoryService;
        }

        [HttpPost]
        [Route("FlowerCategoryAdd")]
        public async Task<ActionResult<string>> AddFlowerCategory(FlowerCategoryAddDTO flowerCategory)
        {
            var result = await _flowerCategoryService.AddFlowerCategory(flowerCategory);

            if (result > 0)
            {
                return Ok("Kategori ekleme başarılı!");
            }
            return BadRequest("Kategori ekleme başarısız!");
        }

        [HttpGet]
        [Route("FlowerCategoryList")]
        public async Task<ActionResult<List<FlowerCategoryListDTO>>> ListFlowerCategory()
        {
            var flowerCategoryList = await _flowerCategoryService.ListFlowerCategory();
            if (flowerCategoryList == null)
            {
                return BadRequest("Kategori listesi bulunamadı!");
            }
            return Ok(flowerCategoryList);
        }


        [HttpPut]
        [Route("FlowerCategoryUpdate")]
        public async Task<ActionResult<string>> UpdateFlowerCategory(FlowerCategoryUpdateDTO flowerCategory)
        {
            var result = await _flowerCategoryService.UpdateFlowerCategory(flowerCategory);
            if (result > 0)
            {
                return Ok("Kategori güncelleme başarılı!");
            }
            return BadRequest("Kategori güncelleme başarısız!");
        }

        [HttpDelete]
        [Route("FlowerCategoryDelete")]
        public async Task<ActionResult<string>> DeleteFlowerCategory(int id)
        {
            var result = await _flowerCategoryService.DeleteFlowerCategory(id);
            if (result > 0)
            {
                return Ok("Kategori silme başarılı!");
            }
            return BadRequest("Kategori silme başarısız!");
        }

    }
}
