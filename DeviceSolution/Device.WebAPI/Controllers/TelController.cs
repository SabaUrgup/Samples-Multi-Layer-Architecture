using Device.Business.Abstract;
using Device.DataAccessLayer.DataTransferObject.TelDTO;
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
    public class TelController : ControllerBase
    {
        public ITelService _telService;
        public TelController(ITelService telService)
        {
            _telService = telService;
        }

        [HttpGet]
        [Route("TelList")]
        public ActionResult<List<TelListDTO>> ListTel()
        {
            var telList = _telService.ListTel();
            if (telList == null)
            {
                return BadRequest("Telefon listesi bulunamadı!");
            }
            return Ok(telList);
        }

        [HttpDelete]
        [Route("TelDelete")]
        public ActionResult<string> DeleteTel(int Id)
        {
            var result = _telService.DeleteTel(Id);
            if (result > 0)
            {
                return Ok("Silinme başarılı!");
            }
            return BadRequest("Silinme başarısız!");
        }

        [HttpPost]
        [Route("TelAdd")]
        public ActionResult<string> AddTel(TelAddDTO tel)
        {
            var result = _telService.AddTel(tel);
            if (result > 0)
            {
                return Ok("Ekleme Başarılı!");
            }
            return BadRequest("Ekleme Başarısız!");
        }

        [HttpPut]
        [Route("TelUpdate")]
        public ActionResult<string> UpdateTel(TelUpdateDTO tel)
        {
            var result = _telService.UpdateTel(tel);
            if (result > 0)
            {
                return Ok("Güncelleme başarılı!");
            }
            return BadRequest("Güncelleme Başarısız!");
        }
    }
}
