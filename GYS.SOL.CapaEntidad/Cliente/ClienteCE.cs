using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYS.SOL.CapaEntidad.Cliente
{
   public class ClienteCE
    {
        [Key]
        public string CodCliente { get; set; }
        public string NombreCompleto { get; set; }
        public string NombreCorto { get; set; }
        public string Abreviatura { get; set; }
        public string Ruc { get; set; }
        public string Estado { get; set; }
        public string GrupoFacturacion { get; set; }
        public DateTime? InactivoDesde { get; set; }
        public string CodigoSap { get; set; }
    }
}
