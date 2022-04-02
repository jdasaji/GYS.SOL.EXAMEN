using GYS.SOL.CapaEntidad.Base;
using GYS.SOL.CapaEntidad.Cliente;
using GYS.SOL.Contracto;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYS.SOL.Servicio.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]/[action]")]
    [ApiController]
    public class ClienteController : ControllerBase, IClienteServicio
    {
        private IClienteServicio _IClienteServicio;
        public ClienteController(IClienteServicio _IClienteServicio)
        {
            this._IClienteServicio = _IClienteServicio;
        }
        [HttpGet]
        public ResultadoCE<List<ClienteCE>> Listar()
        {
            return this._IClienteServicio.Listar();
        }

        [HttpGet]
        public ResultadoCE<ClienteCE> ObtenerPorId([FromQuery] ClienteFiltrosCE parametro)
        {
            return this._IClienteServicio.ObtenerPorId(parametro);
        }

        [HttpPost]
        public ResultadoCE<ClienteCE> Registrar(ClienteCE parametro)
        {
            return this._IClienteServicio.Registrar(parametro);
        }

        [HttpPut("{codigoCliente}")]
        public ResultadoCE<ClienteCE> Actualizar(string codigoCliente, ClienteCE parametro)
        {
            return this._IClienteServicio.Actualizar(codigoCliente, parametro);
        }
        [HttpDelete("{codigoCliente}")]
        public ResultadoCE<string> Inactivar(string codigoCliente)
        {
            return this._IClienteServicio.Inactivar(codigoCliente);
        }
    }
}
