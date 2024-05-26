using MySql.Data.MySqlClient;
using System.Data;

namespace DragonBallCharacters.Data.DataAccess
{
    internal class PersonajeDB(string servidor, string usur, string pwd)
    {
        // Información de conexión a la base de datos
        private readonly string _connectionString = $"Server={servidor};Database=dbcharacters;Uid={usur};Pwd={pwd};";

        // Prueba de conexión
        public bool ProbarConexion()
        {
            using var connection = new MySqlConnection(_connectionString);
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        // Método para leer todos los personajes
        public DataTable LeerPersonajes()
        {
            DataTable personajes = new();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM tbcharacters";
                using MySqlCommand command = new(sql, connection);
                using MySqlDataAdapter adapter = new(command);
                adapter.Fill(personajes);
            }


            return personajes;
        }

        



        // Método para crear un nuevo personaje
        public int CrearPersonaje(string nombre, string raza, Int64 nivelPoder, string ch_history, string ch_fecha)
        {
        
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = @"
                INSERT INTO tbcharacters (nombre, raza, nivel_poder, fecha_creacion, historia, img)
                VALUES (@nombre, @raza, @nivelPoder, @fecha_creacion, @historia, @img)";

            using MySqlCommand command = new(sql, connection);
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@raza", raza);
            command.Parameters.AddWithValue("@nivelPoder", nivelPoder);
            command.Parameters.AddWithValue("@fecha_creacion", ch_fecha);
            command.Parameters.AddWithValue("@historia", ch_history);

            return command.ExecuteNonQuery();
        }

        // Busca un personaje por su ID
        public DataTable BuscarPersonajePorId(int id)
        {
            DataTable personaje = new();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = "SELECT * FROM tbcharacters WHERE id = @id";
            using MySqlCommand command = new(sql, connection);
            command.Parameters.AddWithValue("@id", id);

            using MySqlDataAdapter adapter = new(command);
            adapter.Fill(personaje);

          

            return personaje;
        }
        public DataTable BuscarPersonajePorRaza(string raza)
        {
            DataTable personaje = new();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM tbcharacters WHERE raza LIKE @raza";
                using var command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@raza", "%" + raza + "%");

                using var adapter = new MySqlDataAdapter(command);
                adapter.Fill(personaje);
            }

            

            return personaje;
        }


        public DataTable BuscarPersonajePorNombre(string nombre)
        {
            DataTable personaje = new();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = "SELECT * FROM tbcharacters WHERE nombre like @nombre";
            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@nombre", nombre);
            using var adapter = new MySqlDataAdapter(command);
            adapter.Fill(personaje);

            return personaje;
        }

        // Método para actualizar un personaje
        public void ActualizarPersonaje(int id, string nombre, string raza, Int64 nivelPoder, string ch_fecha, string ch_history)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = "UPDATE tbcharacters SET nombre = @nombre, raza = @raza, nivel_poder = @nivelPoder , fecha_creacion = @fecha_creacion, " +
                "historia = @historia, img=@image WHERE id = @id";
            using MySqlCommand command = new(sql, connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@raza", raza);
            command.Parameters.AddWithValue("@nivelPoder", nivelPoder);
            command.Parameters.AddWithValue("@fecha_creacion", ch_fecha);
            command.Parameters.AddWithValue("@historia", ch_history);


            command.ExecuteNonQuery();
        }

        // Método para eliminar un personaje
        public void EliminarPersonaje(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string sql = "DELETE FROM tbcharacters WHERE id = @id";
            using MySqlCommand command = new(sql, connection);
            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();
        }

        // Función para ejecutar consultas SQL genéricas
        public DataTable EjecutarConsulta(string consultaSQL)
        {
            DataTable resultado = new();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            using MySqlCommand command = new(consultaSQL, connection);
            using MySqlDataAdapter adapter = new(command);
            adapter.Fill(resultado);

            return resultado;
        }
    }
}
