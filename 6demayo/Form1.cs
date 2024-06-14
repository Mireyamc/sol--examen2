using MySqlConnector;
using System.Data;
using System.Text;

namespace _6demayo
{
    public partial class Form1 : Form
    {
        int cR, cG, cB;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "archivos.jpg | *.jpg";
            openFileDialog1.ShowDialog();
            pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            var bmp = new Bitmap(pictureBox1.Image);
            var avgColor = GetAverageColor(bmp, e.X, e.Y, 10);
            cR = avgColor.R;
            cG = avgColor.G;
            cB = avgColor.B;
            textBox1.Text = cR.ToString();
            textBox2.Text = cG.ToString();
            textBox3.Text = cB.ToString();
            textBox5.Text = ColorTranslator.ToHtml(avgColor).Substring(1);
        }

        private Color GetAverageColor(Bitmap bmp, int x, int y, int size)
        {
            int sR = 0, sG = 0, sB = 0, count = 0;

            for (int i = x; i < x + size && i < bmp.Width; i++)
            {
                for (int j = y; j < y + size && j < bmp.Height; j++)
                {
                    var c = bmp.GetPixel(i, j);
                    sR += c.R;
                    sG += c.G;
                    sB += c.B;
                    count++;
                }
            }

            return Color.FromArgb(sR / count, sG / count, sB / count);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Por favor, carga una imagen primero.");
                return;
            }

            var bmp = new Bitmap(pictureBox1.Image);
            var colorCounts = new Dictionary<string, int>();
            var cambios = ProcesarImagen(bmp, colorCounts, 1);

            MostrarResultados(bmp, cambios, colorCounts);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Por favor, carga una imagen primero.");
                return;
            }

            var bmp = new Bitmap(pictureBox1.Image);
            var colorCounts = new Dictionary<string, int>();
            var cambios = ProcesarImagen(bmp, colorCounts, 10);

            MostrarResultados(bmp, cambios, colorCounts);
        }

        private int ProcesarImagen(Bitmap bmp, Dictionary<string, int> colorCounts, int step)
        {
            int cambios = 0;

            using (var conexionBD = AbrirConexion())
            {
                if (conexionBD == null || conexionBD.State != ConnectionState.Open)
                {
                    MessageBox.Show("Error al conectar con la base de datos.");
                    return cambios;
                }

                string query = "SELECT cR_origen, cG_origen, cB_origen, cR_destino, cG_destino, cB_destino FROM textura";
                var comando = new MySqlCommand(query, conexionBD);

                using (var reader = comando.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        MessageBox.Show("No se encontraron filas en la tabla.");
                        return cambios;
                    }

                    while (reader.Read())
                    {
                        int cR_origen = reader.GetInt32("cR_origen");
                        int cG_origen = reader.GetInt32("cG_origen");
                        int cB_origen = reader.GetInt32("cB_origen");
                        int cR_destino = reader.GetInt32("cR_destino");
                        int cG_destino = reader.GetInt32("cG_destino");
                        int cB_destino = reader.GetInt32("cB_destino");

                        string colorKey = $"{cR_origen},{cG_origen},{cB_origen}|{cR_destino},{cG_destino},{cB_destino}";
                        if (!colorCounts.ContainsKey(colorKey)) colorCounts[colorKey] = 0;

                        for (int i = 0; i < bmp.Width; i += step)
                        {
                            for (int j = 0; j < bmp.Height; j += step)
                            {
                                var avgColor = GetAverageColor(bmp, i, j, step);
                                if (Math.Abs(avgColor.R - cR_origen) <= 20 &&
                                    Math.Abs(avgColor.G - cG_origen) <= 20 &&
                                    Math.Abs(avgColor.B - cB_origen) <= 20)
                                {
                                    for (int ip = i; ip < i + step && ip < bmp.Width; ip++)
                                    {
                                        for (int jp = j; jp < j + step && jp < bmp.Height; jp++)
                                        {
                                            bmp.SetPixel(ip, jp, Color.FromArgb(cR_destino, cG_destino, cB_destino));
                                        }
                                    }
                                    colorCounts[colorKey]++;
                                    cambios++;
                                }
                            }
                        }
                    }
                }
            }

            return cambios;
        }

        private void MostrarResultados(Bitmap bmp, int cambios, Dictionary<string, int> colorCounts)
        {
            if (cambios > 0)
            {
                MessageBox.Show("Se realizaron cambios en la imagen ingresada");

                var messageBuilder = new StringBuilder();
                foreach (var colorCount in colorCounts)
                {
                    if (colorCount.Value > 0)
                    {
                        string[] parts = colorCount.Key.Split('|');
                        string[] origenParts = parts[0].Split(',');
                        string[] destinoParts = parts[1].Split(',');
                        messageBuilder.AppendLine($"Color origen ({origenParts[0]}, {origenParts[1]}, {origenParts[2]}) " +
                                                  $"se convirtió en ({destinoParts[0]}, {destinoParts[1]}, {destinoParts[2]}) " +
                                                  $"encontrado {colorCount.Value} veces.");
                    }
                }

                if (messageBuilder.Length > 0)
                {
                    MessageBox.Show(messageBuilder.ToString(), "Colores encontrados");
                }

                pictureBox1.Image = bmp;
            }
            else
            {
                MessageBox.Show("No hay coincidencias en la base de datos");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var conexionBD = AbrirConexion())
            {
                if (conexionBD != null && conexionBD.State == ConnectionState.Open)
                {
                    MessageBox.Show("La conexión fue exitosa.");
                    var adapter = new MySqlDataAdapter("SELECT * FROM textura", conexionBD);
                    var dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("No se pudo abrir la conexión a la base de datos.");
                }
            }
        }

        private MySqlConnection AbrirConexion()
        {
            string connectionString = "server=localhost;user=root;password=;database=examen2";
            var conexionBD = new MySqlConnection(connectionString);

            try
            {
                conexionBD.Open();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
                return null;
            }

            return conexionBD;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
    }
}
