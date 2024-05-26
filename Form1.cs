using DragonBallCharacters.Data.DataAccess;
using MySql.Data.MySqlClient;
using System.Data;
using System.Security;

namespace DragonBallCharacters
{
    public partial class Form1 : Form
    {
        // Filtros
        private readonly string[] filterData = {
            "id",
            "razas",
            "nombre",
        };

        // Lista de razas
        private readonly string[] razasDragonBall = {
            "Android",
            "Bio-Android",
            "Humana",
            "Humano",
            "Majin",
            "Namekuseijin",
            "Saiyajin",
            "Saiyajin/Humano",
            "Saiyajin/Saiyajin"
        };

        private readonly PersonajeDB personaje;

        public Form1()
        {
            InitializeComponent();
            personaje = new PersonajeDB("localhost", "root", "MEGAyol0.");
        }

        private async void ButtonCargaData_Click(object sender, EventArgs e)
        {
            GridCharacters.DataSource = await Task.Run(() => personaje.LeerPersonajes());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Llenar el ComboBox con las razas
            raza_ch.Items.AddRange(razasDragonBall);
            filter.Items.AddRange(filterData);
        }

        private async void ButtonInsertar_Click(object sender, EventArgs e)
        {
            string nombre = name_ch.Text;
            string raza = raza_ch.Text;
            Int64 nivelPoder = (Int64)power_ch.Value;
            string ch_fecha = fecha_ch.Value.ToString("yyyy-MM-dd");
            string ch_history = history.Text;

            // Buscar personaje por nombre
            DataTable dtPersonajeExistente = await Task.Run(() => personaje.BuscarPersonajePorNombre(nombre));

            if (dtPersonajeExistente.Rows.Count > 0)
            {
                // Actualizar personaje existente
                int id = Convert.ToInt32(dtPersonajeExistente.Rows[0]["id"]);
                await Task.Run(() => personaje.ActualizarPersonaje(id, nombre, raza, nivelPoder, ch_fecha, ch_history));
                MessageBox.Show("Personaje actualizado correctamente");
            }
            else
            {
                // Crear nuevo personaje
                int respuesta = await Task.Run(() => personaje.CrearPersonaje(nombre, raza, nivelPoder, ch_history, ch_fecha));
                if (respuesta > 0)
                {
                    MessageBox.Show("Personaje creado correctamente");
                }
                else
                {
                    MessageBox.Show("Error al crear el personaje");
                }
            }

            // Actualizar la cuadrícula de personajes
            GridCharacters.DataSource = await Task.Run(() => personaje.LeerPersonajes());
        }

        private async void BuscarPorId()
        {
            if (int.TryParse(search_params.Text, out int idPersonajeABuscar))
            {
                DataTable personajeEncontrado = await Task.Run(() => personaje.BuscarPersonajePorId(idPersonajeABuscar));

                if (personajeEncontrado.Rows.Count > 0)
                {
                    DataRow row = personajeEncontrado.Rows[0];

                    id_ch.Text = row["id"].ToString();
                    name_ch.Text = row["nombre"].ToString();
                    raza_ch.Text = row["raza"].ToString();
                    power_ch.Value = Convert.ToDecimal(row["nivel_poder"]);
                    history.Text = row["historia"].ToString();


                }
                else
                {
                    MessageBox.Show("No se encontró el personaje con ID: " + idPersonajeABuscar);
                }
            }
            else
            {
                MessageBox.Show("ID no válido.");
            }
        }

        private void ButtonBuscar_Click(object sender, EventArgs e)
        {
            switch (filter.SelectedIndex)
            {
                case 0:
                    // Implementar lógica de búsqueda por ID
                    BuscarPorId();
                    break;
                case 1:
                    // Implementar lógica de búsqueda por raza
                    BuscarPorRaza();
                    break;
                case 2:
                    // Implementar lógica de búsqueda por nombre
                    BuscarPorNombre();
                    break;
                default:
                    MessageBox.Show("Seleccione un filtro válido.");
                    break;
            }
        }






        private async void BuscarPorRaza()
        {
            string razaPersonajeABuscar = search_params.Text;

            DataTable personajesEncontrados = await Task.Run(() => personaje.BuscarPersonajePorRaza(razaPersonajeABuscar));

            if (personajesEncontrados.Rows.Count > 0)
            {
                // Mostrar todos los personajes encontrados en la cuadrícula
                GridCharacters.DataSource = personajesEncontrados;

                // O seleccionar el primer personaje encontrado para mostrar detalles individuales
                DataRow row = personajesEncontrados.Rows[0];

                id_ch.Text = row["id"].ToString();
                name_ch.Text = row["nombre"].ToString();
                raza_ch.Text = row["raza"].ToString();
                power_ch.Value = Convert.ToDecimal(row["nivel_poder"]);
                history.Text = row["historia"].ToString();


            }
            else
            {
                MessageBox.Show("No se encontró ningún personaje con la raza: " + razaPersonajeABuscar);
            }
        }

        private async void BuscarPorNombre()
        {
            string nombrePersonajeABuscar = search_params.Text;

            DataTable personajesEncontrados = await Task.Run(() => personaje.BuscarPersonajePorNombre(nombrePersonajeABuscar));

            if (personajesEncontrados.Rows.Count > 0)
            {
                // Mostrar todos los personajes encontrados en la cuadrícula
                GridCharacters.DataSource = personajesEncontrados;

                // O seleccionar el primer personaje encontrado para mostrar detalles individuales
                DataRow row = personajesEncontrados.Rows[0];

                id_ch.Text = row["id"].ToString();
                name_ch.Text = row["nombre"].ToString();
                raza_ch.Text = row["raza"].ToString();
                power_ch.Value = Convert.ToDecimal(row["nivel_poder"]);
                history.Text = row["historia"].ToString();


            }
            else
            {
                MessageBox.Show("No se encontró ningún personaje con el nombre: " + nombrePersonajeABuscar);
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            // Implementar la lógica si es necesario
        }
        private async Task BorrarPorId()
        {
            if (int.TryParse(search_params.Text, out int idPersonajeAEliminar))
            {
                var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este personaje?",
                                                     "Confirmar eliminación",
                                                     MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    await Task.Run(() => personaje.EliminarPersonaje(idPersonajeAEliminar));
                    MessageBox.Show("Personaje eliminado correctamente");
                    GridCharacters.DataSource = await Task.Run(() => personaje.LeerPersonajes());
                }
            }
            else
            {
                MessageBox.Show("ID no válido.");
            }
        }

        private void DeleteB_Click(object sender, EventArgs e)
        {
            _ = BorrarPorId();
        }

    } 
}

