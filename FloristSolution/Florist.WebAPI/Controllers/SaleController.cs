using Florist.Business.Abstract;
using Florist.DataAccessLayer.DataTransferObject.SaleDTO;
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
    public class SaleController : ControllerBase
    {
        public ISaleService _saleService;
        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpPost]
        [Route("SaleAdd")]
        public async Task<ActionResult<string>> AddSale(SaleAddDTO sale)
        {
            var result = await _saleService.AddSale(sale);

            if (result > 0)
            {
                return Ok("Satış ekleme başarılı!");
            }
            return BadRequest("Satış ekleme başarısız!");
        }

        [HttpGet]
        [Route("SaleList")]
        public async Task<ActionResult<List<SaleListDTO>>> ListFlower()
        {
            var saleList = await _saleService.ListSale();
            if (saleList == null)
            {
                return BadRequest("Satış listesi bulunamadı!");
            }
            return Ok(saleList);
        }


        [HttpPut]
        [Route("SaleUpdate")]
        public async Task<ActionResult<string>> UpdateSale(SaleUpdateDTO sale)
        {
            var result = await _saleService.UpdateSale(sale);
            if (result > 0)
            {
                return Ok("Satış güncelleme başarılı!");
            }
            return BadRequest("Satış güncelleme başarısız!");
        }

        [HttpDelete]
        [Route("SaleDelete")]
        public async Task<ActionResult<string>> DeleteSale(int id)
        {
            var result = await _saleService.DeleteSale(id);
            if (result > 0)
            {
                return Ok("Satış silme başarılı!");
            }
            return BadRequest("Satış silme başarısız!");
        }
    }
}
