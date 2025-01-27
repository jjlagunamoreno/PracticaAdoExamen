using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using PracticaAdoExamen.Models;

namespace PracticaAdoExamen.Repositories
{
    public class RepositoryPedidos
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public RepositoryPedidos(string connectionString)
        {
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        // MÉTODO PARA OBTENER LOS DETALLES DE UN PEDIDO POR SU CÓDIGO
        public async Task<Pedido> GetPedidoDetalleAsync(string codigoPedido)
        {
            string sql = "SELECT CodigoPedido, CodigoCliente, FechaEntrega, FormaEnvio, Importe " +
                         "FROM PEDIDOS WHERE CodigoPedido = @codigoPedido";

            this.com.Parameters.Clear();
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;

            this.com.Parameters.AddWithValue("@codigoPedido", codigoPedido);

            Pedido pedido = null;

            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();

            if (await this.reader.ReadAsync())
            {
                pedido = new Pedido
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
            }

            await this.reader.CloseAsync();
            await this.cn.CloseAsync();

            return pedido;
        }

        // MÉTODO PARA ELIMINAR UN PEDIDO POR SU CÓDIGO
        public async Task DeletePedidoAsync(string codigoPedido)
        {
            string sql = "DELETE FROM PEDIDOS WHERE CodigoPedido = @codigoPedido";

            this.com.Parameters.Clear();
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;

            this.com.Parameters.AddWithValue("@codigoPedido", codigoPedido);

            await this.cn.OpenAsync();
            await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
        }

        // MÉTODO PARA AÑADIR UN NUEVO PEDIDO
        public async Task AddPedidoAsync(Pedido pedido)
        {
            string sql = "INSERT INTO PEDIDOS (CodigoPedido, CodigoCliente, FechaEntrega, FormaEnvio, Importe) " +
                         "VALUES (@codigoPedido, @codigoCliente, @fechaEntrega, @formaEnvio, @importe)";

            this.com.Parameters.Clear();
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;

            this.com.Parameters.AddWithValue("@codigoPedido", pedido.CodigoPedido);
            this.com.Parameters.AddWithValue("@codigoCliente", pedido.CodigoCliente);
            this.com.Parameters.AddWithValue("@fechaEntrega", pedido.FechaEntrega ?? (object)DBNull.Value);
            this.com.Parameters.AddWithValue("@formaEnvio", pedido.FormaEnvio);
            this.com.Parameters.AddWithValue("@importe", pedido.Importe ?? (object)DBNull.Value);

            await this.cn.OpenAsync();
            await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
        }
    }
}