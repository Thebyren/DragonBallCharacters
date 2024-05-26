using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace DragonBallCharacters.Data.DataAccess
{
    internal class PersonajeDB(string servidor, string usur, string pwd)
    {
        // Información de conexión a la base de datos
        private readonly string connectionString = "Server=" + servidor + ";Database=dbcharacters;Uid=" + usur + ";Pwd=" + pwd + ";";


        //prueba de conexion
        public bool ProbarConexion()
        {
            using MySqlConnection connection = new(connectionString);
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Método para leer todos los personajes
        public DataTable LeerPersonajes()
        {
            DataTable personajes = new();

            using (MySqlConnection connection = new(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM tbcharacters";
                using MySqlCommand command = new(sql, connection);
                using MySqlDataAdapter adapter = new(command);
                adapter.Fill(personajes);
            }

            // Convertir las imágenes almacenadas en el DataTable
            foreach (DataRow row in personajes.Rows)
            {
                if (row["img"] != DBNull.Value)
                {
                    byte[] imageBytes = (byte[])row["img"];
                    row["img"] = ByteArrayToImage(imageBytes);
                }
            }

            return personajes;
        }

        // Método para convertir byte[] a Image
        private static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using MemoryStream ms = new(byteArrayIn);
            return Image.FromStream(ms);
        }


        // Método para crear un nuevo personaje
        public int CrearPersonaje(string nombre, string raza, int nivelPoder, string ch_history, string ch_fecha, Image ch_image)
        {
            // Convertir la imagen a un array de bytes
//            byte[] imageBytes = ImageToByteArray(ch_image);
            ImageToByteArray(ch_image);
            

            using MySqlConnection connection = new(connectionString);
            connection.Open();

            // Consulta SQL que incluye todos los campos
            string sql = @"
        INSERT INTO tbcharacters (nombre, raza, nivel_poder, fecha, history, imagen)
        VALUES (@nombre, @raza, @nivelPoder, @fecha, @history, @imagen)";

            using MySqlCommand command = new(sql, connection);
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@raza", raza);
            command.Parameters.AddWithValue("@nivelPoder", nivelPoder);
            command.Parameters.AddWithValue("@fecha", ch_fecha);
            command.Parameters.AddWithValue("@history", ch_history);
           // command.Parameters.AddWithValue("@imagen", imageBytes);

            return command.ExecuteNonQuery();
        }

        //Busca un personaje por su ID
        public DataTable BuscarPersonajePorId(int id)
        {
            DataTable personaje = new();

            using (MySqlConnection connection = new(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM tbcharacters WHERE id = @id";
                using MySqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@id", id);

                using MySqlDataAdapter adapter = new(command);
                adapter.Fill(personaje);
            }
            foreach (DataRow row in personaje.Rows)
            {
                if (row["img"] != DBNull.Value)
                {
                    byte[] imageBytes = (byte[])row["img"];
                    row["img"] = ByteArrayToImage(imageBytes);
                }
            }

            return personaje;
        }


        // Método para actualizar un personaje
        public void ActualizarPersonaje(int id, string nombre, string raza, int nivelPoder)
        {
            using MySqlConnection connection = new(connectionString);
            connection.Open();

            string sql = "UPDATE tbcharacters SET nombre = @nombre, raza = @raza, nivel_poder = @nivelPoder WHERE id = @id";
            using MySqlCommand command = new(sql, connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@raza", raza);
            command.Parameters.AddWithValue("@nivelPoder", nivelPoder);

            command.ExecuteNonQuery();
        }

        // Método para eliminar un personaje
        public void EliminarPersonaje(int id)
        {
            using MySqlConnection connection = new(connectionString);
            connection.Open();

            string sql = "DELETE FROM tbcharacters WHERE id = @id";
            using MySqlCommand command = new(sql, connection);
            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();
        }



        //si da tiempo:
        // Función para ejecutar consultas SQL genéricas
        public DataTable EjecutarConsulta(string consultaSQL)
        {
            DataTable resultado = new();

            using (MySqlConnection connection = new(connectionString))
            {
                connection.Open();

                using MySqlCommand command = new(consultaSQL, connection);
                using MySqlDataAdapter adapter = new(command);
                adapter.Fill(resultado);
            }

            return resultado;
        }
        private static void ImageToByteArray(Image image)
        {
            Console.WriteLine(image.RawFormat);
            // using MemoryStream ms = new();
            // image.Save(ms, format); // Guarda la imagen en el MemoryStream usando el formato original de la imagen
            // return ms.ToArray(); // Convierte el MemoryStream a un array de bytes
        }
    }
}
