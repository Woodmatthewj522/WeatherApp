using System;
using System.Data;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherApp
{
    public partial class MattsWeatherApp : Form
    {
        // OpenWeatherMap API key
        private readonly string apiKey = "6927a1742ef9e64755583799244f1387";

        public MattsWeatherApp()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes UI elements on form load.
        /// </summary>
        private void MattsWeatherApp_Load(object sender, EventArgs e)
        {
            UpdateNameLabel();
        }

        /// <summary>
        /// Updates the NameLabel with your name and today's date, positioned bottom-left.
        /// </summary>
        private void UpdateNameLabel()
        {
            NameLabel.Text = $"MW {DateTime.Now:MM/dd/yyyy}";
            NameLabel.TextAlign = ContentAlignment.BottomLeft;
            NameLabel.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            NameLabel.AutoSize = true;

            int margin = 10;

            // Position label just below the forecastGrid
            int newY = forecastGrid.Bottom + margin;
            if (newY + NameLabel.Height > this.ClientSize.Height)
            {
                newY = this.ClientSize.Height - NameLabel.Height - margin;
            }

            NameLabel.Location = new Point(margin, newY);
            NameLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        }

        /// <summary>
        /// Handles the "Get Weather" button click.
        /// Fetches current weather and forecast for Hanover, PA (zip 17331).
        /// </summary>
        private async void btnGetWeather_Click(object sender, EventArgs e)
        {
            string currentWeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?zip=17331,US&appid={apiKey}&units=imperial";
            await FetchWeatherAsync(currentWeatherUrl);
            await FetchForecastAsync();
        }

        /// <summary>
        /// Fetches current weather data and updates temperature, condition, and humidity labels.
        /// </summary>
        private async Task FetchWeatherAsync(string url)
        {
            using HttpClient client = new HttpClient();

            try
            {
                string response = await client.GetStringAsync(url);
                using JsonDocument doc = JsonDocument.Parse(response);
                {
                    var root = doc.RootElement;
                    double temp = root.GetProperty("main").GetProperty("temp").GetDouble();
                    string desc = root.GetProperty("weather")[0].GetProperty("description").GetString();
                    int humidity = root.GetProperty("main").GetProperty("humidity").GetInt32();

                    lblTemp.Text = $"Temperature: {temp:F1} °F";
                    lblDesc.Text = $"Condition: {desc}";
                    lblHumidity.Text = $"Humidity: {humidity}%";
                }
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Network error. Please check your internet connection.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
            }
        }

        /// <summary>
        /// Fetches 5-day forecast and populates the DataGridView.
        /// </summary>
        private async Task FetchForecastAsync()
        {
            string url = $"https://api.openweathermap.org/data/2.5/forecast?zip=17331,US&appid={apiKey}&units=imperial";

            using HttpClient client = new HttpClient();

            try
            {
                string response = await client.GetStringAsync(url);
                using JsonDocument doc = JsonDocument.Parse(response);
                {
                    var list = doc.RootElement.GetProperty("list");
                    DataTable table = new DataTable();
                    table.Columns.Add("Date/Time");
                    table.Columns.Add("Temperature (°F)");
                    table.Columns.Add("Condition");

                    foreach (var item in list.EnumerateArray())
                    {
                        string date = item.GetProperty("dt_txt").GetString();
                        double temp = item.GetProperty("main").GetProperty("temp").GetDouble();
                        string desc = item.GetProperty("weather")[0].GetProperty("description").GetString();

                        table.Rows.Add(date, $"{temp:F1}", desc);
                    }

                    forecastGrid.DataSource = table;
                    forecastGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    forecastGrid.ReadOnly = true;
                    forecastGrid.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching forecast: " + ex.Message);
            }
        }

        /// <summary>
        /// Optional: Handles cell clicks in the forecast grid.
        /// </summary>
        private void forecastGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Reserved for future use
        }

        /// <summary>
        /// Opens the SearchWeatherForm to look up other cities.
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            SearchWeatherForm searchForm = new SearchWeatherForm();
            searchForm.Show();
            this.Hide();

            searchForm.FormClosed += (s, args) => this.Show();
        }

        /// <summary>
        /// Optional: Handles clicks on the NameLabel.
        /// </summary>
        private void label1_Click(object sender, EventArgs e)
        {
            // Reserved for future use
        }
    }
}