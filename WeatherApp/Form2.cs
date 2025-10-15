using System;
using System.Data;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherApp
{
    public partial class SearchWeatherForm : Form
    {
        // Your OpenWeatherMap API key
        private readonly string apiKey = "YOUR_API_KEY_HERE";

        public SearchWeatherForm()
        {
            InitializeComponent();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string city = txtCity.Text.Trim();

            if (string.IsNullOrWhiteSpace(city))
            {
                MessageBox.Show("Please enter a city name.", "Input Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string currentUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=imperial";
            string forecastUrl = $"https://api.openweathermap.org/data/2.5/forecast?q={city}&appid={apiKey}&units=imperial";

            await FetchCurrentWeatherAsync(currentUrl);
            await FetchForecastAsync(forecastUrl);
        }

        private async Task FetchCurrentWeatherAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string response = await client.GetStringAsync(url);
                    using (JsonDocument doc = JsonDocument.Parse(response))
                    {
                        var root = doc.RootElement;

                        double temp = root.GetProperty("main").GetProperty("temp").GetDouble();
                        string desc = root.GetProperty("weather")[0].GetProperty("description").GetString();
                        int humidity = root.GetProperty("main").GetProperty("humidity").GetInt32();
                        string name = root.GetProperty("name").GetString();

                        lblHeader.Text = $"Weather in {name}";
                        lblTemp.Text = $"Temperature: {temp:F1} °F";
                        lblDesc.Text = $"Condition: {desc}";
                        lblHumidity.Text = $"Humidity: {humidity}%";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching current weather: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task FetchForecastAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string response = await client.GetStringAsync(url);
                    using (JsonDocument doc = JsonDocument.Parse(response))
                    {
                        var list = doc.RootElement.GetProperty("list");

                        DataTable table = new DataTable();
                        table.Columns.Add("Date/Time");
                        table.Columns.Add("Temp (°F)");
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
                    MessageBox.Show("Error fetching forecast: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); // simply close this form and return to the main form
        }
    }
}
