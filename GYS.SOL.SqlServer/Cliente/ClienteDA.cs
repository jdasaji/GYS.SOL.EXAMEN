using GYS.SOL.CapaEntidad.Cliente;
using GYS.SOL.Repositorio.Cliente;
using GYS.SOL.SqlServer.context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYS.SOL.SqlServer.Cliente
{
    public class ClienteDA : IClienteRepositorio
    {
        public AppDbContext dbContext = null;

        public ClienteDA()
        {
            this.dbContext = new AppDbContext();
        }
        public ClienteDA(AppDbContext fake)
        {
            this.dbContext = fake;
        }
        public List<ClienteCE> Listar()
        {
            DbSet<ClienteCE> modelo = dbContext.Set<ClienteCE>();
            string query = string.Format("exec dbo.Cliente_listarRegistros_pa");
            var result = modelo.FromSqlRaw(query).ToList();
            return result;
        }
        public ClienteCE ObtenerPorId(ClienteFiltrosCE parametro)
        {
            DbSet<ClienteCE> modelo = dbContext.Set<ClienteCE>();
            var parameters = new[] {
                new SqlParameter("@p_codCliente", SqlDbType.VarChar) { Value = parametro.codigoCliente    },
            };
            string query = string.Format("exec Cliente_obtenerPorId_pa @{0}", "p_codCliente");
            var result = modelo.FromSqlRaw(query, parameters).ToList().FirstOrDefault();
            return result;
        }

        public ClienteCE Registrar(ClienteCE parametro)
        {
            SqlParameter codigoClienteOuput = new SqlParameter("@p_codCliente", SqlDbType.VarChar, 10) { Direction = ParameterDirection.Output };

            var parameters = new[] {
              codigoClienteOuput  ,
                     new SqlParameter("@p_NombreCompleto", SqlDbType.VarChar,200){ Value=parametro.NombreCompleto} ,
                     new SqlParameter("@p_NombreCorto", SqlDbType.VarChar,200){ Value=parametro.NombreCorto} ,
                     new SqlParameter("@p_Abreviatura", SqlDbType.VarChar,200){ Value=parametro.Abreviatura} ,
                     new SqlParameter("@p_Ruc", SqlDbType.VarChar,200){ Value=parametro.Ruc} ,
                     new SqlParameter("@p_Estado", SqlDbType.Char,1){ Value=parametro.Estado} ,
                     new SqlParameter("@p_GrupoFacturacion", SqlDbType.VarChar,100){ Value= parametro.GrupoFacturacion??(object)DBNull.Value} ,
                     new SqlParameter("@p_InactivoDesde", SqlDbType.DateTime){ Value=parametro.InactivoDesde??(object)DBNull.Value} ,
                     new SqlParameter("@p_CodigoSAP", SqlDbType.VarChar,20){ Value= parametro.CodigoSap??(object)DBNull.Value} ,
            };
            string query = string.Format("exec Cliente_registrar_pa  @p_codCliente output" +
                ",@p_NombreCompleto" +
                ",@p_NombreCorto" +
                ",@p_Abreviatura" +
                ",@p_Ruc" +
                ",@p_Estado" +
                ",@p_GrupoFacturacion" +
                ",@p_InactivoDesde" +
                ",@p_CodigoSAP"
                );
            dbContext.Database.ExecuteSqlRaw(query, parameters);
            parametro.CodCliente = codigoClienteOuput.Value?.ToString();
            return parametro;
        }


        public ClienteCE Actualizar(ClienteCE parametro)
        {

            var parameters = new[] {
                     new SqlParameter("@p_codCliente", SqlDbType.VarChar,200){ Value=parametro.CodCliente} ,
                     new SqlParameter("@p_NombreCompleto", SqlDbType.VarChar,200){ Value=parametro.NombreCompleto} ,
                     new SqlParameter("@p_NombreCorto", SqlDbType.VarChar,200){ Value=parametro.NombreCorto} ,
                     new SqlParameter("@p_Abreviatura", SqlDbType.VarChar,200){ Value=parametro.Abreviatura} ,
                     new SqlParameter("@p_Ruc", SqlDbType.VarChar,200){ Value=parametro.Ruc} ,
                     new SqlParameter("@p_Estado", SqlDbType.Char,1){ Value=parametro.Estado} ,
                     new SqlParameter("@p_GrupoFacturacion", SqlDbType.VarChar,100){ Value= parametro.GrupoFacturacion??(object)DBNull.Value} ,
                     new SqlParameter("@p_InactivoDesde", SqlDbType.DateTime){ Value=parametro.InactivoDesde??(object)DBNull.Value} ,
                     new SqlParameter("@p_CodigoSAP", SqlDbType.VarChar,20){ Value= parametro.CodigoSap??(object)DBNull.Value} ,
            };
            string query = string.Format("exec Cliente_actualizar_pa  @p_codCliente" +
                ",@p_NombreCompleto" +
                ",@p_NombreCorto" +
                ",@p_Abreviatura" +
                ",@p_Ruc" +
                ",@p_Estado" +
                ",@p_GrupoFacturacion" +
                ",@p_InactivoDesde" +
                ",@p_CodigoSAP"
                );
            dbContext.Database.ExecuteSqlRaw(query, parameters);
            return parametro;
        }



        public void Inactivar(ClienteFiltrosCE parametro)
        {

            var parameters = new[] {
                     new SqlParameter("@p_codCliente", SqlDbType.VarChar,200){ Value=parametro.codigoCliente}
            };
            string query = string.Format("exec Cliente_inactivar_pa  @p_codCliente");
            dbContext.Database.ExecuteSqlRaw(query, parameters);

        }
    }
}
