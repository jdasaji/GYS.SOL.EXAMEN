using GYS.SOL.CapaEntidad.Base;
using GYS.SOL.CapaEntidad.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYS.SOL.Contracto
{
    public interface IClienteServicio
    {
        ResultadoCE<List<ClienteCE>> Listar();

        ResultadoCE<ClienteCE> ObtenerPorId(ClienteFiltrosCE parametro);
        ResultadoCE<ClienteCE> Registrar(ClienteCE parametro);
        ResultadoCE<ClienteCE> Actualizar(string codigoCliente, ClienteCE parametro);
        ResultadoCE<string> Inactivar(string parametro);
    }
}
