using CapaNegocio;
using CapaNegocio.Entidades;
using CapaVisual.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVisual
{
    // Instancias de las entidades y servicios necesarios
    public partial class frmPagosMatricula : Form
    {
        EVehiculo EntidadVehiculo = new EVehiculo();
        NVehiculo NegocioVehiculo = new NVehiculo();
        LimpiezaDatos LimpiarControladores = new LimpiezaDatos();
        ValidacionesMetodos ValidarDatos = new ValidacionesMetodos();

        public frmPagosMatricula()
        {
            InitializeComponent();
        }

        internal void LimpiarTextBox()
        {
            // Limpia los controles relacionados con el pago de matrícula
            LimpiarControladores.LimpiarControladoresPagoMatricular(Modelotxt, Anotxt, Colortxt, Deudatxt, Matriculatxt, lblEstadoPago);
        }

        // Manejo dek evento del boton para buscar datos del vehiculo.
        private void Buscarbtn_Click(object sender, EventArgs e)
        {
            try
            {
                EntidadVehiculo.Placa = Matriculatxt.Text;

                var resultado = NegocioVehiculo.BuscarDeuda(EntidadVehiculo); // Busca la deuda del vehículo
                if (resultado.Rows.Count > 0)
                {
                    // Si se encuentran resultados, asigna los valores a los TextBox correspondientes
                    DataRow row = resultado.Rows[0];
                    Anotxt.Text = row["AÑO"].ToString();
                    Modelotxt.Text = row["MODELO"].ToString();
                    Colortxt.Text = row["COLOR"].ToString();
                    Deudatxt.Text = row["DEUDA"].ToString();
                    bool pagado = Convert.ToBoolean(row["PAGADO"]);

                    // Actualiza el estado de pago y habilita o deshabilita el botón de pago
                    if (pagado)
                    {
                        lblEstadoPago.Text = "Pagado";
                        lblEstadoPago.BackColor = Color.Green;
                        Pagarbtn.Enabled = false;
                    }
                    else
                    {
                        lblEstadoPago.Text = "No Pagado";
                        lblEstadoPago.BackColor = Color.Red;
                        Pagarbtn.Enabled = true;
                    }
                }

                else
                {
                    MessageBox.Show("No se encontraron resultados para la placa proporcionada.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmPagosMatricula_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        // Manejo del evento del boton para pagar la deuda del vehiculo.
        private void Pagarbtn_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Llama al método PagarMatricula de la capa de negocio para realizar el pago de la matrícula del vehículo
                NegocioVehiculo.PagarMatricula(EntidadVehiculo);
                MessageBox.Show("Pago realizado con exito");
                LimpiarTextBox();
                Pagarbtn.Enabled = false;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        // Metodos para nevegar entre interfases.
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MenuPrincipal formuPrincipal = new MenuPrincipal();
            formuPrincipal.Show();
            this.Hide();
        }

        // Métodos para validar entrada de datos en TextBox específicos según su contenido
        private void Matriculatxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDatos.NumeroYLetras(e, Matriculatxt);
        }
    }
}
