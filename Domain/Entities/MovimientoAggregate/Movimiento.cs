using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities.CuentaAggregate;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.MovimientoAggregate
{
    public class Movimiento
    {
        public long Id { get; set; }

        public long CuentaId { get; set; }

        public long SucursalIdMov { get; set; }

        public long NumeroOp { get; set; }

        public DateTime FechaOp { get; set; }

        public DateTime FechaGrab { get; set; }

        public long OperacionId { get; set; }
               
        public double Importe { get; set; }

        public double SaldoOp { get; set; }

        public double SaldoGr { get; set; }

        public long InfAdicional { get; set; }

        public long UsuarioId { get; set; }

        public bool Anulado { get; set; }

        public Cuenta Cuenta { get; set; }

        public Operacion Operacion { get; set; }

        [NotMapped]
        public CuentaSaldo CuentaSaldo { get; set; }

        public Movimiento()
        {

        }
        public Movimiento(long CuentaId, long SucursalIdMov, long NumeroOp,  DateTime FechaOp, Operacion Operacion, 
            double Importe, long InfAdicional, long UsuarioId, Cuenta cuenta, CuentaSaldo CuentaSaldo, List<Movimiento> MovAnt)
        {
            this.CuentaId = CuentaId;
            this.SucursalIdMov = SucursalIdMov;
            this.NumeroOp = NumeroOp;            
            this.FechaOp = FechaOp;
            this.FechaGrab = DateTime.Now;
            this.Operacion = Operacion;            
            this.Importe = Importe;
            this.SaldoOp = 0;
            this.SaldoGr = 0;
            this.UsuarioId = UsuarioId;
            this.InfAdicional = InfAdicional;
            this.Cuenta = cuenta;
            //this.CuentaSaldo = CuentaSaldo;
            this.CuentaSaldo = CuentaSaldo ?? new CuentaSaldo(CuentaId, DateTime.Now, 0, 0);                       

            //En cuenta saldo
            double nuevoSaldo = ActualizarSaldo(SucursalIdMov, FechaOp, Operacion, Importe, InfAdicional, UsuarioId);
            this.SaldoOp = nuevoSaldo;
            ActualizarFechaUltMov(FechaOp);

            ArrMovAntAHoy(MovAnt);

        }

        private double ActualizarSaldo(long SucursalIdMov, DateTime FechaOp, Operacion Operacion, double Importe, long InfAdicional, long UsuarioId)
        {
            //Tipo operacion - Cambio: op comun, cambio estado

            //Actual saldo            
            double nuevoSaldo = 0;
            nuevoSaldo = this.CuentaSaldo.Saldo + EvalOp(Operacion, Importe);

            //Saldo negativo
            if (nuevoSaldo < 0)
                throw new Exception("Error, grabar este movimiento provocaria un saldo negativo");

            this.CuentaSaldo.Saldo = nuevoSaldo;

            return CuentaSaldo.Saldo;
        }
        private double EvalOp(Operacion Operacion, double Importe)
        {
            double res = .0;
            if (Operacion.TipoOperacionId == 1) //Operaciones comunes
            {
                if (Operacion.OperadorId == 1) //suma
                {
                    res = Importe;
                }
                if (Operacion.OperadorId == 2) //resta
                {
                    res = Importe * -1;
                }
            }
            return res;
        }
        private void ActualizarFechaUltMov(DateTime Fecha)
        {
            this.CuentaSaldo.FechaUltMov = Fecha;
        }

        private List<Movimiento> ArrMovAntAHoy(List<Movimiento> movimientos)
        {            
            var res = new List<Movimiento>();
            var primSaldo = .0;            
                                 
            var primMov = movimientos
                .OrderBy(x => x.FechaOp)
                .ThenBy(x => x.FechaGrab)
                .ThenBy(x => x.Id)
                .FirstOrDefault();

            if (primMov != null)
            {
                primSaldo = primMov.SaldoOp; // + EvalOp(primMov.Operacion, primMov.Importe);
            }
            else
            {
                return res;
            }


            movimientos.Add(this);

            
            foreach (var mov in movimientos
                .Where(x=> x.FechaOp > this.FechaOp || x.Id == this.Id)
                .OrderBy(x => x.FechaOp).ThenBy(x => x.FechaGrab).ToList())
            {

                //Corregir saldo
                var importeMov = EvalOp(mov.Operacion, mov.Importe);
                double nuevoSaldo = primSaldo +( importeMov * 1);

                mov.SaldoOp = nuevoSaldo;
            }


            return res;
        }

    }
}
