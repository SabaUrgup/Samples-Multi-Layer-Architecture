using Management.Business.Abstract;
using Management.DataAccessLayer.DataTransferObject.EmployerDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        public IEmployerService _employerService;
        public EmployerController(IEmployerService employerService)
        {
            _employerService = employerService;
        }

        [HttpPost]
        [Route("EmployerAdd")]
        public ActionResult<string> AddEmployer(EmployerAddDTO employer)
        {
            var result = _employerService.AddEmployer(employer);

                if (result > 0)
                {
                    return Ok("İş veren ekleme başarılı!");
                }
                return BadRequest("İş veren ekleme başarısız!");
        }

        [HttpGet]
        [Route("EmployerList")]
        public ActionResult<List<EmployerListDTO>> ListEmployer()
        {
            var employerList = _employerService.ListEmployer();
            if (employerList == null)
            {
                return BadRequest("İş veren listesi bulunamadı!");
            }
            return Ok(employerList);
        }


        [HttpPut]
        [Route("EmployerUpdate")]
        public ActionResult<string> UpdateEmployer(EmployerUpdateDTO employer)
        {
            var result = _employerService.UpdateEmployer(employer);
                if (result > 0)
            {
                return Ok("İş veren güncelleme başarılı!");
            }
            return BadRequest("İş veren güncelleme başarısız!");
        }

        [HttpDelete]
        [Route("EmployerDelete")]
        public ActionResult<string> DeleteEmployer(int id)
        {
            var result = _employerService.DeleteEmployer(id);
                if (result> 0)
            {
                return Ok("İş veren silme başarılı!");
            }
            return BadRequest("İş veren silme başarısız!");
        }

    }
}
