using Florist.Business.Abstract;
using Florist.DataAccessLayer.DataTransferObject.FlowerDTO;
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
    public class FlowerController : ControllerBase
    {
        public IFlowerService _flowerService;
        public FlowerController(IFlowerService flowerService)
        {
            _flowerService = flowerService;
        }

        [HttpPost]
        [Route("FlowerAdd")]
        public async Task<ActionResult<string>> AddFlower(FlowerAddDTO flower)
        {
            var result = await _flowerService.AddFlower(flower);

            if (result > 0)
            {
                return Ok("Çiçek ekleme başarılı!");
            }
            return BadRequest("Çiçek ekleme başarısız!");
        }

        [HttpGet]
        [Route("FlowerList")]
        public async Task<ActionResult<List<FlowerListDTO>>> ListFlower()
        {
            var flowerList = await _flowerService.ListFlower();
            if (flowerList == null)
            {
                return BadRequest("Çiçek listesi bulunamadı!");
            }
            return Ok(flowerList);
        }
        [HttpGet]
        [Route("FlowerIdList")]
        public async Task<ActionResult<List<FlowerGetDTO>>> GetFlowerById(int Id)
        {
            var flowerList = await _flowerService.GetFlowerById(Id);
            if (flowerList == null)
            {
                return BadRequest("Çiçek id listesi bulunamadı!");
            }
            return Ok(flowerList);
        }


        [HttpPut]
        [Route("FlowerUpdate")]
        public async Task<ActionResult<string>> UpdateFlower(FlowerUpdateDTO flower)
        {
            var result = await _flowerService.UpdateFlower(flower);
            if (result > 0)
            {
                return Ok("Çiçek güncelleme başarılı!");
            }
            return BadRequest("Çiçek güncelleme başarısız!");
        }

        [HttpDelete]
        [Route("FlowerDelete")]
        public async Task<ActionResult<string>> DeleteFlower(int id)
        {
            var result = await _flowerService.DeleteFlower(id);
            if (result > 0)
            {
                return Ok("Çiçek silme başarılı!");
            }
            return BadRequest("Çiçek silme başarısız!");
        }
    }
}
