using CapaVisual.Validaciones;
using CapaNegocio;
using CapaNegocio.Entidades;
using System.Windows.Forms;

namespace CapaVisual
{
    public partial class frmVehiculo : Form
    {
        // Declaración de objetos para manipular entidades y negocios de vehículos
        EVehiculo EntidadVehiculo = new EVehiculo();
        EPropietario EntidadPropietario = new EPropietario();
        NVehiculo NegocioVehiculo = new NVehiculo();
        ValidacionesMetodos ValidarDatos = new ValidacionesMetodos();
        LimpiezaDatos LimpiarControladores = new LimpiezaDatos();


        // Método para limpiar los controles de texto en el formulario frmVehiculos
        internal void LimpiarTextBox()
        {
            LimpiarControladores.LimpiarControladoresVehiculos(PlacaTextBox, ValorTextBox, AñoTextBox, CilindrajeTextBox, ModeloTextBox, ColorTextBox, DNITextBox);
        }



        // Constructor del formulario
        public frmVehiculo()
        {
            InitializeComponent();
            // Suscribir el evento TextChanged de los TextBox
            PlacaTextBox.TextChanged += new EventHandler(TextBox_TextChanged);
            ValorTextBox.TextChanged += new EventHandler(TextBox_TextChanged);
            AñoTextBox.TextChanged += new EventHandler(TextBox_TextChanged);
            CilindrajeTextBox.TextChanged += new EventHandler(TextBox_TextChanged);
            ModeloTextBox.TextChanged += new EventHandler(TextBox_TextChanged);
            ColorTextBox.TextChanged += new EventHandler(TextBox_TextChanged);
            DNITextBox.TextChanged += new EventHandler(TextBox_TextChanged);
            // Inicialmente deshabilitar el botón
            GuardarVehiculo.Enabled = false;
        }

        // Método para manejar cambios en TextBox y habilitar/deshabilitar botón
        private void TextBox_TextChanged(object sender, EventArgs e)
        {

            TextBox textBox = sender as TextBox;
            int maxLength = textBox.MaxLength;

            // Comprobar si todos los TextBox tienen texto
            GuardarVehiculo.Enabled = !string.IsNullOrWhiteSpace(PlacaTextBox.Text) &&
                                      !string.IsNullOrWhiteSpace(ValorTextBox.Text) &&
                                      !string.IsNullOrWhiteSpace(AñoTextBox.Text) &&
                                      !string.IsNullOrWhiteSpace(CilindrajeTextBox.Text) &&
                                      !string.IsNullOrWhiteSpace(ModeloTextBox.Text) &&
                                      !string.IsNullOrWhiteSpace(ColorTextBox.Text) &&
                                      !string.IsNullOrWhiteSpace(DNITextBox.Text);
        }

        // Guardar la información del vehículo
        private void GuardarVehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                EntidadVehiculo.Placa = PlacaTextBox.Text;
                EntidadVehiculo.Valor = decimal.Parse(ValorTextBox.Text);
                EntidadVehiculo.Año = int.Parse(AñoTextBox.Text);
                EntidadVehiculo.Cilindraje = int.Parse(CilindrajeTextBox.Text);
                EntidadVehiculo.Modelo = ModeloTextBox.Text;
                EntidadVehiculo.Color = ColorTextBox.Text;
                EntidadVehiculo.Dni_Propieatrio = DNITextBox.Text;

                var dniexiste = NegocioVehiculo.Verificar_DNIExistente(EntidadVehiculo);

                if (dniexiste.Rows.Count > 0)
                {
                    var resultado = NegocioVehiculo.CrearVehiculo(EntidadVehiculo, EntidadPropietario);

                    if (resultado)
                    {
                        
                        NegocioVehiculo.RecogerDatosPropietario_Correo(EntidadVehiculo);
                        MessageBox.Show("Registro Creado con Exito");
                        LimpiarTextBox();
                    }
                    else
                        MessageBox.Show("No se Creo el Registro");

                }
                else
                {
                    MessageBox.Show("DNI Proporcionado no Existe");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Metodos para nevegar entre interfases.
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MenuPrincipal formuPrincipal = new MenuPrincipal();
            formuPrincipal.Show();
            this.Hide();
        }

        private void ModificarVehiculo_Click(object sender, EventArgs e)
        {
            frmModificarVehiculo formuModificar = new frmModificarVehiculo();
            formuModificar.Show();
            this.Hide();
        }


        // Métodos para validar entrada de datos en TextBox específicos según su contenido
        private void ValorTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDatos.SoloNumeros(e, ValorTextBox);
        }

        private void AñoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDatos.SoloNumerosAños(e, AñoTextBox);
        }

        private void CilindrajeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDatos.SoloNumeros(e, CilindrajeTextBox);
        }

        private void ColorTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDatos.SoloLetras(e, ColorTextBox);
        }

        private void DNITextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDatos.SoloNumeros(e, DNITextBox);
        }

        private void PlacaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDatos.NumeroYLetras(e, PlacaTextBox);
        }

        private void frmVehiculos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}
