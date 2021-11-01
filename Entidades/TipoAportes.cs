using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPersonas.Entidades
{
    public class TipoAportes
    {
        [Key]
        public int TipoAporteId { get; set; }
        public string Descripcion { get; set; }


        public TipoAportes()
        {
            TipoAporteId = 0;
            Descripcion = string.Empty;
        }
        public TipoAportes(int tipoAporteId, string descripcion)
        {
            TipoAporteId = tipoAporteId;
            Descripcion = descripcion;
        }
    }
}
