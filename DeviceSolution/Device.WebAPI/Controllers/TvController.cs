using Device.Business.Abstract;
using Device.DataAccessLayer.DataTransferObject.TvDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TvController : ControllerBase
    {
        public ITvService _tvService;
        public TvController(ITvService tvService)
        {
            _tvService = tvService;
        }

        [HttpGet]
        [Route("TvList")]
        public ActionResult<List<TvListDTO>> ListTv()
        {
            var tvList = _tvService.ListTv();
            if (tvList == null)
            {
                return BadRequest("Televizyon listesi bulunamadı!");
            }
            return Ok(tvList);
        }

        [HttpDelete]
        [Route("TvDelete")]
        public ActionResult<string> DeleteTv(int Id)
        {
            var result = _tvService.DeleteTv(Id);
            if (result > 0)
            {
                return Ok("Silinme başarılı!");
            }
            return BadRequest("Silinme başarısız!");
        }

        [HttpPost]
        [Route("TvAdd")]
        public ActionResult<string> AddTel(TvAddDTO tv)
        {
            var result = _tvService.AddTv(tv);
            if (result > 0)
            {
                return Ok("Ekleme Başarılı!");
            }
            return BadRequest("Ekleme Başarısız!");
        }

        [HttpPut]
        [Route("TvUpdate")]
        public ActionResult<string> UpdateTv(TvUpdateDTO tv)
        {
            var result = _tvService.UpdateTv(tv);
            if (result > 0)
            {
                return Ok("Güncelleme başarılı!");
            }
            return BadRequest("Güncelleme Başarısız!");
        }
    }
}
