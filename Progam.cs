using System;
using System.Drawing;
using System.Windows.Forms;

namespace Conversor
{
    public partial class Form1 : Form
    {
        private ComboBox comboUnidad;
        private NumericUpDown numTemperatura;
        private Label lblResultadoCelsius;
        private Label lblResultadoFahrenheit;
        private Label lblResultadoKelvin;
        private Button btnConvertir;
        private Button btnLimpiar;

        public Form1()
        {
            InitializeComponent();
            InicializarComponentes();
        }

        private void InicializarComponentes()
        {
            // Configuración del formulario
            this.Text = "Conversor de Temperatura";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(240, 248, 255);

            // Título
            Label lblTitulo = new Label();
            lblTitulo.Text = "🌡️ CONVERSOR DE TEMPERATURA";
            lblTitulo.Font = new Font("Arial", 16, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(25, 25, 112);
            lblTitulo.Location = new Point(80, 20);
            lblTitulo.Size = new Size(340, 30);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblTitulo);

            // Label para temperatura
            Label lblTemp = new Label();
            lblTemp.Text = "Ingrese la temperatura:";
            lblTemp.Font = new Font("Arial", 10, FontStyle.Bold);
            lblTemp.Location = new Point(50, 70);
            lblTemp.Size = new Size(150, 25);
            this.Controls.Add(lblTemp);

            // NumericUpDown para temperatura
            numTemperatura = new NumericUpDown();
            numTemperatura.Location = new Point(210, 70);
            numTemperatura.Size = new Size(120, 25);
            numTemperatura.Font = new Font("Arial", 10);
            numTemperatura.TextAlign = HorizontalAlignment.Center;
            numTemperatura.DecimalPlaces = 2;
            numTemperatura.Increment = 1;
            numTemperatura.Minimum = -500;
            numTemperatura.Maximum = 1000;
            numTemperatura.Value = 0;
            // Convertir automáticamente cuando cambie el valor
            numTemperatura.ValueChanged += NumTemperatura_ValueChanged;
            this.Controls.Add(numTemperatura);

            // Label para unidad
            Label lblUnidad = new Label();
            lblUnidad.Text = "Unidad de medida:";
            lblUnidad.Font = new Font("Arial", 10, FontStyle.Bold);
            lblUnidad.Location = new Point(50, 110);
            lblUnidad.Size = new Size(150, 25);
            this.Controls.Add(lblUnidad);

            // ComboBox para unidades (también convierte automáticamente)
            comboUnidad = new ComboBox();
            comboUnidad.Location = new Point(210, 110);
            comboUnidad.Size = new Size(120, 25);
            comboUnidad.Font = new Font("Arial", 10);
            comboUnidad.DropDownStyle = ComboBoxStyle.DropDownList;
            comboUnidad.Items.AddRange(new string[] { "Celsius", "Fahrenheit", "Kelvin" });
            comboUnidad.SelectedIndex = 0;
            comboUnidad.SelectedIndexChanged += ComboUnidad_SelectedIndexChanged;
            this.Controls.Add(comboUnidad);

            // Botón Convertir
            btnConvertir = new Button();
            btnConvertir.Text = "🔄 CONVERTIR";
            btnConvertir.Location = new Point(120, 160);
            btnConvertir.Size = new Size(120, 35);
            btnConvertir.Font = new Font("Arial", 10, FontStyle.Bold);
            btnConvertir.BackColor = Color.FromArgb(70, 130, 180);
            btnConvertir.ForeColor = Color.White;
            btnConvertir.FlatStyle = FlatStyle.Flat;
            btnConvertir.Click += BtnConvertir_Click;
            this.Controls.Add(btnConvertir);

            // Botón Limpiar
            btnLimpiar = new Button();
            btnLimpiar.Text = "🗑️ LIMPIAR";
            btnLimpiar.Location = new Point(260, 160);
            btnLimpiar.Size = new Size(120, 35);
            btnLimpiar.Font = new Font("Arial", 10, FontStyle.Bold);
            btnLimpiar.BackColor = Color.FromArgb(220, 20, 60);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Click += BtnLimpiar_Click;
            this.Controls.Add(btnLimpiar);

            // Panel de resultados
            Panel panelResultados = new Panel();
            panelResultados.Location = new Point(50, 220);
            panelResultados.Size = new Size(400, 120);
            panelResultados.BackColor = Color.White;
            panelResultados.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(panelResultados);

            // Label título resultados
            Label lblTituloResultados = new Label();
            lblTituloResultados.Text = "📊 RESULTADOS DE CONVERSIÓN";
            lblTituloResultados.Font = new Font("Arial", 12, FontStyle.Bold);
            lblTituloResultados.ForeColor = Color.FromArgb(25, 25, 112);
            lblTituloResultados.Location = new Point(10, 10);
            lblTituloResultados.Size = new Size(300, 25);
            lblTituloResultados.TextAlign = ContentAlignment.MiddleLeft;
            panelResultados.Controls.Add(lblTituloResultados);

            // Labels para resultados
            lblResultadoCelsius = new Label();
            lblResultadoCelsius.Text = "🌡️ Celsius: --";
            lblResultadoCelsius.Font = new Font("Arial", 10);
            lblResultadoCelsius.Location = new Point(20, 40);
            lblResultadoCelsius.Size = new Size(360, 20);
            panelResultados.Controls.Add(lblResultadoCelsius);

            lblResultadoFahrenheit = new Label();
            lblResultadoFahrenheit.Text = "🌡️ Fahrenheit: --";
            lblResultadoFahrenheit.Font = new Font("Arial", 10);
            lblResultadoFahrenheit.Location = new Point(20, 65);
            lblResultadoFahrenheit.Size = new Size(360, 20);
            panelResultados.Controls.Add(lblResultadoFahrenheit);

            lblResultadoKelvin = new Label();
            lblResultadoKelvin.Text = "🌡️ Kelvin: --";
            lblResultadoKelvin.Font = new Font("Arial", 10);
            lblResultadoKelvin.Location = new Point(20, 90);
            lblResultadoKelvin.Size = new Size(360, 20);
            panelResultados.Controls.Add(lblResultadoKelvin);
        }

        // Evento para conversión automática cuando cambia el valor
        private void NumTemperatura_ValueChanged(object sender, EventArgs e)
        {
            ConvertirTemperatura();
        }

        // Evento para conversión automática cuando cambia la unidad
        private void ComboUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConvertirTemperatura();
        }

        // Método centralizado para convertir
        private void ConvertirTemperatura()
        {
            try
            {
                double temperatura = (double)numTemperatura.Value;
                string unidadOrigen = comboUnidad.SelectedItem.ToString();

                // Convertir a Celsius usando switch statement tradicional
                double celsius;
                switch (unidadOrigen)
                {
                    case "Celsius":
                        celsius = temperatura;
                        break;
                    case "Fahrenheit":
                        celsius = (temperatura - 32) * 5 / 9;
                        break;
                    case "Kelvin":
                        celsius = temperatura - 273.15;
                        break;
                    default:
                        celsius = 0;
                        break;
                }

                double fahrenheit = (celsius * 9 / 5) + 32;
                double kelvin = celsius + 273.15;

                lblResultadoCelsius.Text = unidadOrigen != "Celsius"
                    ? $"🌡️ Celsius: {celsius:F2}°C"
                    : "🌡️ Celsius: (Unidad de origen)";

                lblResultadoFahrenheit.Text = unidadOrigen != "Fahrenheit"
                    ? $"🌡️ Fahrenheit: {fahrenheit:F2}°F"
                    : "🌡️ Fahrenheit: (Unidad de origen)";

                lblResultadoKelvin.Text = unidadOrigen != "Kelvin"
                    ? $"🌡️ Kelvin: {kelvin:F2}K"
                    : "🌡️ Kelvin: (Unidad de origen)";

                // Cambiar color si está por debajo del cero absoluto
                if (kelvin < 0)
                {
                    lblResultadoKelvin.ForeColor = Color.Red;
                }
                else
                {
                    lblResultadoKelvin.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnConvertir_Click(object sender, EventArgs e)
        {
            // Ahora este botón solo actualiza la conversión manualmente
            ConvertirTemperatura();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            numTemperatura.Value = 0;
            comboUnidad.SelectedIndex = 0;
            lblResultadoCelsius.Text = "🌡️ Celsius: --";
            lblResultadoFahrenheit.Text = "🌡️ Fahrenheit: --";
            lblResultadoKelvin.Text = "🌡️ Kelvin: --";
            lblResultadoKelvin.ForeColor = Color.Black;
            numTemperatura.Focus();
        }

    }
}
