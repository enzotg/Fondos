using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.CuentaAggregate;
using Domain.Entities.MovimientoAggregate;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.CqMovimiento.Commands
{
    public class NuevoMovimientoCommandHandler:IRequestHandler<NuevoMovimientoCommandRequest,long>
    {
        private IMovimientoRepository _movimientoRepository;
        private ICuentaRepository _cuentaRepository;
        private IGenericRepositoryAsync<Operacion> _operacionRepository;

        public NuevoMovimientoCommandHandler(IMovimientoRepository movimientoRepository, ICuentaRepository cuentaRepository, IGenericRepositoryAsync<Operacion> operacionRepository)
        {
            _movimientoRepository = movimientoRepository;
            _cuentaRepository = cuentaRepository;
            _operacionRepository = operacionRepository;
        }

        public async Task<long> Handle(NuevoMovimientoCommandRequest request, CancellationToken cancellationToken)
        {
            long NumeroOp = await _movimientoRepository.GetNuevoNumeroOp(request.SucursalIdMov, DateTime.Now);
            Operacion Op = await _operacionRepository.GetByIdAsync(request.OperacionId);
            Cuenta cuenta = await _cuentaRepository.GetByIdAsync(request.CuentaId);
            CuentaSaldo cs = await _movimientoRepository.CuentaSaldo(request.CuentaId);
            List<Movimiento> movAnt = await _movimientoRepository.GetMovimientos(request.CuentaId, request.FechaOp);

            if(Op==null)
                throw new Exception("No existe operacion " );
            if(cuenta==null)
                throw new Exception("No existe cuenta ");
            if(NumeroOp<=0)
                throw new Exception("Error en numero de operacion");

            var nuevo = new Movimiento(request.CuentaId, request.SucursalIdMov,
                NumeroOp, request.FechaOp, Op, request.Importe, request.InfAdicional, request.UsuarioId,
                cuenta, cs, movAnt);

            await _movimientoRepository.AddAsync(nuevo);

            return nuevo.Id;
        }

        public void Validate(NuevoMovimientoCommandRequest request)
        {
            if (request.CuentaId == 0)
                throw new Exception("Cuenta ident. no puede ser cero. " + request.CuentaId.ToString());

            if (request.OperacionId == 0)
                throw new Exception("Operacion no puede ser cero. " + request.OperacionId.ToString());
        }

    }
}
