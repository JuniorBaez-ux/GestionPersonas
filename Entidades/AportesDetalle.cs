using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPersonas.Entidades
{
    public class AportesDetalle
    {
        [Key]
        public int Id { get; set; }
        public int AporteId { get; set; }
        public int TipoAportesId { get; set; }
        public double Monto { get; set; }
        public double Total { get; set; }
        public double MontoDeseado { get; set; }

        public AportesDetalle()
        {
            Id = 0;
            AporteId = 0;
            TipoAportesId = 0;
            Monto = 0;
            MontoDeseado = 0;
            Total = 0;
        }
        public AportesDetalle(int id, int aporteId, int tipoAportesId, double monto, double montoDeseado, double total)
        {
            Id = id;
            AporteId = aporteId;
            TipoAportesId = tipoAportesId;
            Monto = monto;
            MontoDeseado = montoDeseado;
            Total = total;
        }
    }
}
