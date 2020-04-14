using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using webServicreditos.Models;
using Entity;
using Logica;

namespace webServicreditos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditoController: ControllerBase
    {
        private readonly CreditoService _creditoService;
        public IConfiguration Configuration { get; }

        public CreditoController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _creditoService = new CreditoService(connectionString);
        }

        [HttpPost]
        public ActionResult<CreditoViewModel> post(CreditoInputModel creditoInput){
            Credito credito = MapearCredito(creditoInput);
            var response = _creditoService.Guardar(credito);
            if(response.Error){
                return BadRequest(response.Mensaje);
            }
            return Ok(response.credito);
        }
        private Credito MapearCredito(CreditoInputModel creditoInput)
        {
            var credito = new Credito
            {
                Identificacion = creditoInput.Identificacion,
                Nombre = creditoInput.Nombre,
                CapitalInicial = creditoInput.CapitalInicial,
                TasaInteres = creditoInput.TasaInteres,
                TiempoDuracion = creditoInput.TiempoDuracion
            };
            return credito;
        }

        [HttpGet]
        public IEnumerable<CreditoViewModel> gets(){
            var creditos = _creditoService.ConsultarTodos().Select(p=> new CreditoViewModel(p));
            return creditos;
        }
    }
}