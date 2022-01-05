using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Application.CqMovimiento.Commands;
using Application.CqMovimiento.Queries;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        private IMediator _mediator;
        private IMovimientoQueries _movimientoQueries;

        public MovimientoController(IMediator mediator,IMovimientoQueries movimientoQueries )
        {
            _mediator = mediator;
            _movimientoQueries = movimientoQueries;
        }

        // GET: api/<MovimientoController>
        [HttpGet("MovimientosPorCuenta")]
        public async Task<IActionResult> GetMovimientosPorCuenta(long Id)
        {            
            return Ok(await _movimientoQueries.MovimientosPorCuenta(Id));
        }

        // GET api/<MovimientoController>/5
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(long Id)
        {
            return Ok(await _movimientoQueries.GetById(Id));            
        }

        // POST api/<MovimientoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NuevoMovimientoCommandRequest request)
        {
            var resp = await _mediator.Send(request);
            return Ok(resp);
        }


    }
}
