using System.Data;
using CapaDatos.Interface;
using CapaDatos;
using CapaNegocio.Entidades;
using CapaNegocio.Servicios.CorreoServicios.ConstruccionCorreos;

namespace CapaNegocio
{
    public class NVehiculo
    {
        // Instancias de clases para interactuar con la capa de datos.
        private IVehiculo obj_Vehiculo_datos = new IVehiculo(); // Instancia de IVehiculo para interactuar con la entidad Vehiculo en la capa de datos.
        private CVehiculo EnvioCorreos = new CVehiculo();

        // Método para crear un nuevo vehículo.
        public bool CrearVehiculo(EVehiculo vehiculo, EPropietario propietario)
        {
            try
            {
                // Llama al método de la capa de datos para insertar un nuevo vehículo
                bool resultado = obj_Vehiculo_datos.InsertarVehiculo(vehiculo.placa, vehiculo.valor, vehiculo.año, vehiculo.cilindraje, vehiculo.modelo, vehiculo.color, vehiculo.dni_Propieatrio, out DataTable propietarioData);

                if (resultado)
                {
                    // Calcular la deuda del vehículo recién creado
                    obj_Vehiculo_datos.CalcularDeuda(vehiculo.placa);

                    // Recoger los datos del propietario nuevamente para obtener la deuda actualizada
                    propietarioData = obj_Vehiculo_datos.RecogerDatosPropietario(vehiculo.dni_Propieatrio);

                    if (propietarioData.Rows.Count > 0)
                    {
                        var fila = propietarioData.Rows[0];
                        var nombres = fila["NOMBRES"].ToString();
                        var apellidos = fila["APELLIDOS"].ToString();
                        var correo = fila["CORREO"].ToString();
                        var deuda = Convert.ToDecimal(fila["TOTAL"]);

                        EnvioCorreos.EnviarRegistroVehiculo(correo, nombres, apellidos, vehiculo.placa, vehiculo.modelo, vehiculo.color, vehiculo.año, vehiculo.cilindraje, vehiculo.valor, deuda);
                    }
                }

                return resultado;

            }
            catch (Exception e)
            {
                throw new Exception("Error al Crear Registro del Vehiculo" + e.Message);
            }

        }

        // Método para actualizar los datos de un vehículo existente.
        public bool ActualizarVehiculo(EVehiculo vehiculo, EPropietario propietario)
        {
            try
            {
                // Llama al método de la capa de datos para modificar los datos de un vehículo.
                return obj_Vehiculo_datos.ModificarVehiculo(vehiculo.placa, vehiculo.valor, vehiculo.año, vehiculo.cilindraje, vehiculo.modelo, vehiculo.color, Convert.ToInt32(vehiculo.dni_Propieatrio));

            }
            catch (Exception e)
            {
                throw new Exception("Error al Actualizar Registro de Vehiculos" + e.Message);
            }

        }

        // Método para eliminar un vehículo existente.
        public bool Eliminar_Vehiculo(EVehiculo vehiculo, EPropietario propietario)
        {
            try
            {

                // Llama al método de la capa de datos para eliminar un vehículo por su placa.
                return obj_Vehiculo_datos.EliminarVehiculo(vehiculo.placa);

            }
            catch (Exception e)
            {
                throw new Exception("Error al Eliminar Vehiculo" + e.Message);
            }

        }

        // Método para buscar un vehículo por su placa.
        public DataTable Buscar_Placa(EVehiculo vehiculo)
        {
            try
            {
                // Llama al método de la capa de datos para buscar un vehículo por su placa y devuelve un DataTable con los resultados.
                return obj_Vehiculo_datos.BuscarVehiculoPorPlaca(vehiculo.placa);

            }
            catch (Exception e)
            {
                throw new Exception("Error al Buscar Vehiculo" + e.Message);
            }

        }

        // Método para verificar la existencia de un propietario por su DNI.
        public DataTable Verificar_DNIExistente(EVehiculo vehiculo)
        {
            try
            {
                // Llama al método de la capa de datos para verificar la existencia de un propietario por su DNI y devuelve un DataTable con los resultados.
                return obj_Vehiculo_datos.VerificarDNIExistente(vehiculo.dni_Propieatrio);

            }
            catch (Exception e)
            {
                throw new Exception($"Error al buscar propietario: {e.Message}");
            }
        }

        // Método para obtener el ID de un propietario por su DNI.
        public int ObtenerID(string dni)
        {
            var propietario = new NPropietario(); // Instancia de la clase NPropietario para interactuar con la capa de negocios de propietarios.
            var resultado = propietario.Buscar_DNI(new EPropietario { Dni = dni });

            // Verifica si se encontró un propietario con el DNI especificado.
            if (resultado.Rows.Count > 0)
            {
                return Convert.ToInt32(resultado.Rows[0]["ID"]); // Devuelve el ID del propietario encontrado.
            }
            else
            {
                throw new Exception("Propietario no encontrado");
            }
        }

        // Método para calcular la deuda de un vehiculo registrado.
        public bool CalculoDeuda(EVehiculo vehiculo)
        {
            try
            {
                // Llama al método de la capa de datos para buscar un vehículo por su placa y devuelve un DataTable con los resultados.
                return obj_Vehiculo_datos.CalcularDeuda(vehiculo.placa);

            }
            catch (Exception e)
            {
                throw new Exception("Error al Buscar Vehiculo" + e.Message);
            }

        }

        // Método para buscar datos de la deuda de vehiculos.
        public DataTable BuscarDeuda(EVehiculo vehiculo)
        {
            try
            {
                // Llama al método de la capa de datos para buscar un vehículo por su placa y devuelve un DataTable con los resultados.
                return obj_Vehiculo_datos.BuscarMatriculapago(vehiculo.placa);

            }
            catch (Exception e)
            {
                throw new Exception("Error al Buscar Matricula" + e.Message);
            }

        }

        // Método para actualizar deuda despues del pago.
        public bool PagarMatricula(EVehiculo vehiculo)
        {
            try
            {
                // Llama al método de la capa de datos para actualizar la deuda al realizar el pago.
                return obj_Vehiculo_datos.MarcarPago(vehiculo.placa);

            }
            catch (Exception e)
            {
                throw new Exception("Error al Pagar" + e.Message);
            }

        }

        // Método para recoger los datos del propietario y enviar correo.
        public DataTable RecogerDatosPropietario_Correo(EVehiculo vehiculo)
        {
            try
            {
                // Llama al método de la capa de datos para buscar los datos del propietario.
                return obj_Vehiculo_datos.RecogerDatosPropietario(vehiculo.dni_Propieatrio);

            }
            catch (Exception e)
            {
                throw new Exception($"Error al buscar propietario: {e.Message}");
            }
        }
    }
}
    