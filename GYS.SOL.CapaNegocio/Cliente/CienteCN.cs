using GYS.SOL.CapaEntidad.Base;
using GYS.SOL.CapaEntidad.Cliente;
using GYS.SOL.CapaEntidad.enums;
using GYS.SOL.Repositorio.Cliente;
using GYS.SOL.SqlServer.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYS.SOL.CapaNegocio
{
    public class CienteCN
    {
        private IClienteRepositorio _IClienteRepositorio = null;

        public CienteCN()
        {
            this._IClienteRepositorio = new ClienteDA();
        }
        public CienteCN(IClienteRepositorio _IClienteRepositorio)
        {
            this._IClienteRepositorio = _IClienteRepositorio;
        }
        public ResultadoCE<List<ClienteCE>> Listar()
        {
            ResultadoCE<List<ClienteCE>> resultado = new ResultadoCE<List<ClienteCE>>();
            resultado.data = _IClienteRepositorio.Listar();
            return resultado;
        }
        public ResultadoCE<ClienteCE> ObtenerPorId(ClienteFiltrosCE parametro)
        {
            ResultadoCE<ClienteCE> resultado = new ResultadoCE<ClienteCE>();
            try
            {
                resultado.data = _IClienteRepositorio.ObtenerPorId(parametro);
            }
            catch (Exception ex)
            {
                resultado.respuesta = enumRespuesta.ERROR_SERVIDOR;
                resultado.mensaje = ex.Message;
                resultado.data = null;
            }

            return resultado;
        }
        
        public ResultadoCE<ClienteCE> Registrar(ClienteCE parametro)
        {
            ResultadoCE<ClienteCE> resultado = new ResultadoCE<ClienteCE>();
            try
            {
                resultado.data = _IClienteRepositorio.Registrar(parametro);
            }
            catch (Exception ex)
            {
                resultado.respuesta = enumRespuesta.ERROR_SERVIDOR;
                resultado.mensaje = ex.Message;
                resultado.data = null;
            }

            return resultado;
        }  
        public ResultadoCE<ClienteCE> Actualizar(ClienteCE parametro)
        {
            ResultadoCE<ClienteCE> resultado = new ResultadoCE<ClienteCE>();
            try
            {
                resultado.data = _IClienteRepositorio.Actualizar(parametro);
            }
            catch (Exception ex)
            {
                resultado.respuesta = enumRespuesta.ERROR_SERVIDOR;
                resultado.mensaje = ex.Message;
                resultado.data = null;
            }

            return resultado;
        }   
        
        public ResultadoCE<string> Inactivar(ClienteFiltrosCE parametro)
        {
            ResultadoCE<string> resultado = new ResultadoCE<string>();
            try
            {
                _IClienteRepositorio.Inactivar(parametro);
                resultado.mensaje = mensajes.ELIMINACION_EXITOSA;
            }
            catch (Exception ex)
            {
                resultado.respuesta = enumRespuesta.ERROR_SERVIDOR;
                resultado.mensaje = ex.Message;
                resultado.data = null;
            }

            return resultado;
        }
    }
}
