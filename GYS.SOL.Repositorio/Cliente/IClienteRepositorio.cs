using GYS.SOL.CapaEntidad.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYS.SOL.Repositorio.Cliente
{
    public interface IClienteRepositorio
    {
        List<ClienteCE> Listar();
        ClienteCE ObtenerPorId(ClienteFiltrosCE parametro);
        ClienteCE Registrar(ClienteCE parametro);

        ClienteCE Actualizar(ClienteCE parametro);
        void Inactivar(ClienteFiltrosCE parametro);
    }
}
