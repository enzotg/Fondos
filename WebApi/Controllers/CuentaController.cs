using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Application.CqCuenta.Commands;
using Application.CqCuenta.Queries;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private IMediator _mediator;
        private ICuentaQueries _cuentaQueries;

        public CuentaController(IMediator mediator,ICuentaQueries cuentaQueries)
        {
            _mediator = mediator;
            _cuentaQueries = cuentaQueries;
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(long Id)
        {
            return Ok(await _cuentaQueries.GetById(Id));
        }

        // POST api/<MovimientoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CrearCuentaCommandRequest request)
        {
            var resp = await _mediator.Send(request);
            return Ok(resp);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] ModificarCuentaCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }


    }
}
