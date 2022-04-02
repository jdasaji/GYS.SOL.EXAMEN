using FluentValidation;
using GYS.SOL.CapaEntidad.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYS.SOL.Servicio.ModelValidation.Cliente
{
    public class ClienteValidator : AbstractValidator<ClienteCE>
    {
        public ClienteValidator()
        {
            RuleFor(m => m.NombreCompleto).NotEmpty();
            RuleFor(m => m.NombreCorto).NotEmpty();
            RuleFor(m => m.Abreviatura).NotEmpty();
            RuleFor(m => m.Ruc).NotEmpty();
          
          
        }
    }
}
