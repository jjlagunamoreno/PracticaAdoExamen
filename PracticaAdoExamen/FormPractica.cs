using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using PracticaAdoExamen.Models;
using PracticaAdoExamen.Repositories;

namespace Test
{
    public partial class FormPractica : Form
    {
        private RepositoryClientes repoClientes;
        private RepositoryPedidos repoPedidos;

        public FormPractica()
        {
            InitializeComponent();

            // CONFIGURAMOS LOS REPOSITORIOS CON LA CADENA DE CONEXIÓN
            string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=PRACTICA;Persist Security Info=True;User ID=SA;Encrypt=True;TrustServerCertificate=True";
            this.repoClientes = new RepositoryClientes(connectionString);
            this.repoPedidos = new RepositoryPedidos(connectionString);

            // CARGAMOS LOS CLIENTES AL INICIAR
            _ = this.LoadClientesAsync();
        }
        //MÉTODO PARA CARGAR CLIENTES
        private async Task LoadClientesAsync()
        {
            List<Cliente> clientes = await this.repoClientes.GetClientesAsync();
            this.cmbclientes.Items.Clear();

            // AGREGAMOS LOS NOMBRES DE LAS EMPRESAS AL COMBOBOX
            foreach (Cliente cliente in clientes)
            {
                this.cmbclientes.Items.Add(cliente.Empresa);
            }
        }
        //MÉTODO PARA CARGAR PEDIDOS
        private async Task LoadPedidosAsync(string codigoCliente)
        {
            // RECUPERAMOS Y MOSTRAMOS LOS PEDIDOS DEL CLIENTE
            List<Pedido> pedidos = await this.repoClientes.GetPedidosByClienteAsync(codigoCliente);
            this.lstpedidos.Items.Clear();

            foreach (Pedido pedido in pedidos)
            {
                this.lstpedidos.Items.Add(pedido.CodigoPedido);
            }

            // LIMPIAMOS LAS CAJAS DE DETALLE DE PEDIDO
            this.txtcodigopedido.Clear();
            this.txtfechaentrega.Clear();
            this.txtformaenvio.Clear();
            this.txtimporte.Clear();
        }

        //MÉTODO PARA CARGAR DETALLES DEL CLIENTE
        private async void cmbclientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbclientes.SelectedIndex != -1)
            {
                string empresa = this.cmbclientes.SelectedItem.ToString();

                // OBTENEMOS LOS DETALLES DEL CLIENTE
                Cliente cliente = await this.repoClientes.GetClienteDetalleAsync(empresa);

                if (cliente != null)
                {
                    // MOSTRAMOS LOS DATOS EN LAS CAJAS DE TEXTO
                    this.txtempresa.Text = cliente.Empresa;
                    this.txtcontacto.Text = cliente.Contacto;
                    this.txtcargo.Text = cliente.Cargo;
                    this.txtciudad.Text = cliente.Ciudad;
                    this.txttelefono.Text = cliente.Telefono.HasValue ? cliente.Telefono.ToString() : "";

                    // OBTENEMOS LOS PEDIDOS DEL CLIENTE
                    List<Pedido> pedidos = await this.repoClientes.GetPedidosByClienteAsync(cliente.CodigoCliente);

                    // MOSTRAMOS LOS PEDIDOS EN EL LISTBOX
                    this.lstpedidos.Items.Clear();
                    foreach (Pedido pedido in pedidos)
                    {
                        this.lstpedidos.Items.Add(pedido.CodigoPedido);
                    }
                }
            }
        }
        // DETALLES DEL PEDIDO
        private async void lstpedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstpedidos.SelectedIndex != -1)
            {
                string codigoPedido = this.lstpedidos.SelectedItem.ToString();

                // OBTENEMOS LOS DETALLES DEL PEDIDO
                Pedido pedido = await this.repoPedidos.GetPedidoDetalleAsync(codigoPedido);

                if (pedido != null)
                {
                    // MOSTRAMOS LOS DATOS EN LAS CAJAS DE TEXTO
                    this.txtcodigopedido.Text = pedido.CodigoPedido;
                    this.txtfechaentrega.Text = pedido.FechaEntrega.HasValue ? pedido.FechaEntrega.Value.ToString("dd/MM/yyyy") : "";
                    this.txtformaenvio.Text = pedido.FormaEnvio;
                    this.txtimporte.Text = pedido.Importe.HasValue ? pedido.Importe.Value.ToString() : "";
                }
            }
        }
        //NUEVO PEDIDO PARA UN CLIENTE
        private async void btnnuevopedido_Click(object sender, EventArgs e)
        {
            if (this.cmbclientes.SelectedIndex != -1)
            {
                // RECUPERAMOS EL CÓDIGO DEL CLIENTE A TRAVÉS DE SU SELECCIÓN
                string empresa = this.cmbclientes.SelectedItem.ToString();
                Cliente cliente = await this.repoClientes.GetClienteDetalleAsync(empresa);

                if (cliente != null)
                {
                    Pedido nuevoPedido = new Pedido
                    {
                        CodigoPedido = this.txtcodigopedido.Text,
                        CodigoCliente = cliente.CodigoCliente, // ASOCIAMOS EL CÓDIGO DEL CLIENTE
                        FechaEntrega = DateTime.TryParse(this.txtfechaentrega.Text, out DateTime fecha)
                            ? (DateTime?)fecha
                            : null,
                        FormaEnvio = this.txtformaenvio.Text,
                        Importe = int.TryParse(this.txtimporte.Text, out int importe)
                            ? (int?)importe
                            : null
                    };

                    await this.repoPedidos.AddPedidoAsync(nuevoPedido);
                    MessageBox.Show("Pedido añadido correctamente.");

                    // ACTUALIZAMOS LA LISTA DE PEDIDOS USANDO EL MÉTODO EXISTENTE
                    await LoadPedidosAsync(cliente.CodigoCliente);
                }
                else
                {
                    MessageBox.Show("No se encontró el cliente seleccionado.");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un cliente para añadir un pedido.");
            }
        }
        //ELIMINAMOS UN PEDIDO PARA UN CLIENTE
        private async void btneliminarpedido_Click(object sender, EventArgs e)
        {
            if (this.lstpedidos.SelectedIndex != -1)
            {
                string codigoPedido = this.lstpedidos.SelectedItem.ToString();

                DialogResult result = MessageBox.Show(
                    "¿Estás seguro de que deseas eliminar este pedido?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    await this.repoPedidos.DeletePedidoAsync(codigoPedido);
                    MessageBox.Show("Pedido eliminado correctamente.");

                    // RECUPERAMOS EL CLIENTE ACTUAL Y ACTUALIZAMOS LA LISTA DE PEDIDOS
                    string empresa = this.cmbclientes.SelectedItem.ToString();
                    Cliente cliente = await this.repoClientes.GetClienteDetalleAsync(empresa);

                    if (cliente != null)
                    {
                        await LoadPedidosAsync(cliente.CodigoCliente);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un pedido para eliminar.");
            }
        }
    }
}