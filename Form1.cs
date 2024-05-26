using DragonBallCharacters.Data.DataAccess;
using System.Data;
using System.Security;

namespace DragonBallCharacters
{
    public partial class Form1 : Form
    {
        //filtros
        private readonly string[] filterData = [
            "id",
            "razas",
            "nombre",
        ];
        // Lista de razas
        private readonly string[] razasDragonBall = [
            "Android",
            "Bio-Android",
            "Humana",
            "Humano",
            "Majin",
            "Namekuseijin",
            "Saiyajin",
            "Saiyajin/Humano",
            "Saiyajin/Saiyajin"
        ];
        private readonly PersonajeDB personaje;

        public Form1()
        {
            InitializeComponent();
            personaje = new PersonajeDB("localhost", "root", "MEGAyol0.");
        }




        private void ButtonCargaData_Click(object sender, EventArgs e)
        {
            GridCharacters.DataSource = personaje.LeerPersonajes();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Llenar el ComboBox con las razas
            raza_ch.Items.AddRange(razasDragonBall);
            filter.Items.AddRange(filterData);
            
        }

        private void ButtonInsertar_Click(object sender, EventArgs e)
        {
            string nombre = name_ch.Text;
            string raza = raza_ch.SelectedText;
            int nivelPoder = (int)power_ch.Value;
            string ch_fecha = fecha_ch.Value.ToString("yyyy-MM-dd");
            string ch_history = history.Text;
            Image ch_image = ImageCh.Image;
            int respuesta = personaje.CrearPersonaje(nombre, raza, nivelPoder,ch_history, ch_fecha, ch_image);
            if (respuesta > 0)
            {
                MessageBox.Show("Personaje creado correctamente");
                GridCharacters.DataSource = personaje.LeerPersonajes();
            }
            else
            {
                MessageBox.Show("Error al crear el personaje");
            }
        }


        private void BuscarPorId()
        {
            int idPersonajeABuscar = int.Parse(search_params.Text);

            DataTable personajeEncontrado = personaje.BuscarPersonajePorId(idPersonajeABuscar);

            if (personajeEncontrado.Rows.Count > 0)
            {
                // El personaje fue encontrado

                string? nombre = personajeEncontrado.Rows[0]["nombre"].ToString();
                string? raza = personajeEncontrado.Rows[0]["raza"].ToString();
                int nivelPoder = int.Parse(personajeEncontrado.Rows[0]["nivel_poder"].ToString());
                id_ch.Text = personajeEncontrado.Rows[0]["id"].ToString();
                name_ch.Text = nombre;
                raza_ch.Text = raza;
                power_ch.Value = nivelPoder;
                if(personajeEncontrado.Rows[0]["img"] != DBNull.Value)
   {
                    ImageCh.Image = (Image)personajeEncontrado.Rows[0]["img"];
                }
    else
                {
                    // Si la imagen es DBNull, puedes establecer una imagen predeterminada o dejar el PictureBox vacío
                    ImageCh.Image = null; // Dejar el PictureBox sin imagen
                                          //ImageCh.Image = Properties.Resources.DefaultImage; // Establecer una imagen predeterminada desde tus recursos
                }
            }
            else
            {
                // El personaje no fue encontrado
                Console.WriteLine("No se encontró el personaje con ID: " + idPersonajeABuscar);
            }
        }


        private void ButtonBuscar_Click(object sender, EventArgs e)
        {
            int? f = filter.SelectedIndex;
            switch (f)
            {
                case 0:
                    Console.WriteLine("hola");
                    break;
                case 1:
                    Console.WriteLine("hola 1");
                    break;
                case 2:
                    Console.WriteLine("hola 2");
                    break;
            }
            BuscarPorId();
        }

        private void TextBoxID_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(id_ch.Text))
            {
                MessageBox.Show("Por favor, ingresa un valor en el campo de texto.");
                id_ch.Focus(); // Devolver el foco al TextBox
            }
            else
            {
                BuscarPorId();
            }
        }

        private void ButtonTestCon_Click(object sender, EventArgs e)
        {
            if (personaje.ProbarConexion())
            {
                MessageBox.Show("Conexión exitosa");
            }
            else
            {
                MessageBox.Show("Error en la conexión");
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openFileDialog1.FileName;
                    using Stream str = openFileDialog1.OpenFile();
                    ImageCh.Image = Image.FromStream(str);
                    ImageCh.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

