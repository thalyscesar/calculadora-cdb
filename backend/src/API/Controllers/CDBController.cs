
using CalculadoraCDB.Application.Request;
using CalculadoraCDB.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculadoraCDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CDBController : ControllerBase
    {
        private readonly ICDBService _cdbService;

        public CDBController(ICDBService cdbService)
        {
            _cdbService = cdbService;
        }

        [HttpPost("CalcularValores")]
        public IActionResult Post([FromBody] InvestimentoModel investimentoModel)
        {
            try
            {
              return  Ok(_cdbService.ObterValoresCDB(investimentoModel));
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
