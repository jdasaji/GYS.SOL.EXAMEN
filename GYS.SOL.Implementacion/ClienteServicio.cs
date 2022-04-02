using GYS.SOL.CapaEntidad.Base;
using GYS.SOL.CapaEntidad.Cliente;
using GYS.SOL.CapaNegocio;
using GYS.SOL.Contracto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYS.SOL.Implementacion
{
    public class ClienteServicio : IClienteServicio
    {
        public ResultadoCE<List<ClienteCE>> Listar()
        {
            return new CienteCN().Listar();
        }

        public ResultadoCE<ClienteCE> ObtenerPorId(ClienteFiltrosCE parametro)
        {
            return new CienteCN().ObtenerPorId(parametro);
        }

        public ResultadoCE<ClienteCE> Registrar(ClienteCE parametro)
        {
            return new CienteCN().Registrar(parametro);
        }

        public ResultadoCE<ClienteCE> Actualizar(string codigoCliente, ClienteCE parametro)
        {
            parametro.CodCliente = codigoCliente;
            return new CienteCN().Actualizar(parametro);
        }
        public ResultadoCE<string> Inactivar(string parametro)
        {
            return new CienteCN().Inactivar(new ClienteFiltrosCE { codigoCliente = parametro });
        }
    }
}
