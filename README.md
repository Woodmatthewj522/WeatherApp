# 🌤️ MattsWeatherApp

A sleek Windows Forms weather dashboard built with C# and .NET, powered by the OpenWeatherMap API. It fetches real-time weather and 5-day forecasts for Hanover, PA (zip 17331), with future support for city-based search.

---

## 🚀 Features

- **Current Weather**: Displays temperature, humidity, and conditions.
- **5-Day Forecast**: Populates a scrollable DataGridView with hourly data.
- **Responsive UI**: Anchored labels and auto-sized grid columns.
- **Modular Design**: Clean separation of fetch logic, UI updates, and event handling.
- **City Search**: Launches a secondary form for custom location lookup (WIP).

---

## 🛠 Technologies

- **Language**: C#
- **Framework**: .NET Windows Forms
- **API**: [OpenWeatherMap](https://openweathermap.org/api)
- **UI Components**: DataGridView, Labels, Buttons

---

## 📦 Setup

1. Clone the repo:
   ```bash
   git clone https://github.com/yourusername/MattsWeatherApp.git
   ```
2. Open the solution in Visual Studio.
3. Replace the API key in Form1.cs and Form2.cs (Might be MattsWeatherApp.cs)
   -private readonly string apiKey = "YOUR_API_KEY_HERE";
4. Run the project!
#
## 🧠 Developer Notes

- `UpdateNameLabel()` positions your name and date dynamically at the bottom-left of the form.
- `btnGetWeather_Click()` triggers both current weather and forecast fetches using OpenWeatherMap.
- `FetchWeatherAsync()` parses JSON and updates temperature, condition, and humidity labels.
- `FetchForecastAsync()` populates a DataGridView with 5-day hourly forecast data.
- `SearchWeatherForm` is a placeholder for future city-based weather lookup.

---

## 📌 To-Do

- [ ] Add support for user-entered zip codes or city names.
- [ ] Cache recent searches for faster access.
- [ ] Add weather icons or visual feedback for conditions.
- [ ] Improve error handling and add offline mode.

---

## 🧙‍♂️ Author

**Matthew Wood**  
10/14/25

---

## 📄 License

This project is licensed under the MIT License. See `LICENSE` for details.
