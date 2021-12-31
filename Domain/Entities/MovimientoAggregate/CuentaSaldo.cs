using Domain.Entities.CuentaAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.MovimientoAggregate
{
    public class CuentaSaldo
    {
        public long  Id { get; set; }

        public long  CuentaId { get; set; }

        public DateTime FechaUltMov { get; set; }

        public double InteresAcum { get; set; }

        public double Saldo { get; set; }

        public Cuenta Cuenta { get; set; }

        public CuentaSaldo()
        {

        }
        public CuentaSaldo(long CuentaId, DateTime FechaUltMov, double InteresAcum, double Saldo)
        {
            this.CuentaId = CuentaId;
            this.FechaUltMov = FechaUltMov;
            this.InteresAcum = 0;
            this.Saldo = 0;
        }
    }
}
