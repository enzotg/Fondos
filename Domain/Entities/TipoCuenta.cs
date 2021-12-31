using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class TipoCuenta
    {
        public long Id { get; set; }

        [MaxLength(50)]
        public string Nombre { get; set; }
    }
}
