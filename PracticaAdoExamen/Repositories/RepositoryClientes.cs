using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using PracticaAdoExamen.Models;

# region STORED PROCEDURES
//PROCEDURE PARA TRAER LOS CLIENTES
//
//CREATE PROCEDURE SP_ALL_CLIENTES
//AS
//BEGIN
//    SELECT CodigoCliente, Empresa
//    FROM CLIENTES
//END
//GO
//
//PROCEDURE PARA DETALLES DE LOS CLIENTES
//
//CREATE PROCEDURE SP_CLIENTE_DETALLE
//    @empresa NVARCHAR(MAX)
//AS
//BEGIN
//    SELECT CodigoCliente, Empresa, Contacto, Cargo, Ciudad, Telefono
//    FROM CLIENTES
//    WHERE Empresa = @empresa
//END
//GO
#endregion

namespace PracticaAdoExamen.Repositories
{
    public class RepositoryClientes
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public RepositoryClientes(string connectionString)
        {
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        // MÉTODO PARA OBTENER TODOS LOS CLIENTES
        public async Task<List<Cliente>> GetClientesAsync()
        {
            string sql = "SP_ALL_CLIENTES";
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;

            List<Cliente> clientes = new List<Cliente>();

            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();

            while (await this.reader.ReadAsync())
            {
                Cliente cliente = new Cliente
                {
                    CodigoCliente = this.reader["CodigoCliente"].ToString(),
                    Empresa = this.reader["Empresa"].ToString()
                };
                clientes.Add(cliente);
            }

            await this.reader.CloseAsync();
            await this.cn.CloseAsync();

            return clientes;
        }

        // MÉTODO PARA OBTENER LOS DETALLES DE UN CLIENTE POR SU EMPRESA
        public async Task<Cliente> GetClienteDetalleAsync(string empresa)
        {
            string sql = "SP_CLIENTE_DETALLE";
            this.com.Parameters.Clear();
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;

            this.com.Parameters.AddWithValue("@empresa", empresa);

            Cliente cliente = null;

            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();

            if (await this.reader.ReadAsync())
            {
                cliente = new Cliente
                {
                    CodigoCliente = this.reader["CodigoCliente"].ToString(),
                    Empresa = this.reader["Empresa"].ToString(),
                    Contacto = this.reader["Contacto"].ToString(),
                    Cargo = this.reader["Cargo"].ToString(),
                    Ciudad = this.reader["Ciudad"].ToString(),
                    Telefono = this.reader["Telefono"] != DBNull.Value
                        ? (int?)Convert.ToInt32(this.reader["Telefono"])
                        : null
                };
            }

            await this.reader.CloseAsync();
            await this.cn.CloseAsync();

            return cliente;
        }

        // MÉTODO PARA OBTENER LOS PEDIDOS DE UN CLIENTE POR SU CÓDIGO
        public async Task<List<Pedido>> GetPedidosByClienteAsync(string codigoCliente)
        {
            string sql = "SELECT CodigoPedido, CodigoCliente, FechaEntrega, FormaEnvio, Importe " +
                         "FROM PEDIDOS WHERE CodigoCliente = @codigoCliente";

            this.com.Parameters.Clear();
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;

            this.com.Parameters.AddWithValue("@codigoCliente", codigoCliente);

            List<Pedido> pedidos = new List<Pedido>();

            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();

            while (await this.reader.ReadAsync())
            {
                Pedido pedido = new Pedido
                {
                    CodigoPedido = this.reader["CodigoPedido"].ToString(),
                    CodigoCliente = this.reader["CodigoCliente"].ToString(),
                    FechaEntrega = this.reader["FechaEntrega"] != DBNull.Value
                        ? (DateTime?)Convert.ToDateTime(this.reader["FechaEntrega"])
                        : null,
                    FormaEnvio = this.reader["FormaEnvio"].ToString(),
                    Importe = this.reader["Importe"] != DBNull.Value
                        ? (int?)Convert.ToInt32(this.reader["Importe"])
                        : null
                };
                pedidos.Add(pedido);
            }

            await this.reader.CloseAsync();
            await this.cn.CloseAsync();

            return pedidos;
        }

    }
}
