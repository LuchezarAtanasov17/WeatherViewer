import "./WeatherInfo.css"

function WeatherInfo({ weather, loading, error }) {
  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error}</p>;
  if (!weather) {
    return <p>No data yet...</p>;
  }
return (
    <div className="weather-panel">
      <h2>Current weather</h2>
      <div className="weather-content">
        <div className="weather-main">
          <img
            src={`https://openweathermap.org/img/wn/${weather.icon}@2x.png`}
            alt={`иконка за ${weather.description}`}
            className="weather-icon"
          />
          <p className="description">{weather.description}</p>
        </div>

        <div className="weather-details">
          <p><span>🌡 Temperature:</span> {weather.temperature?.toFixed(1)}°C</p>
          <p><span>💧 Humidity:</span> {weather.humidity}%</p>
          <p><span>💨 Wind speed:</span> {weather.windSpeed} m/s</p>
          <p><span>🕒 Timezone:</span> {weather.timezone}</p>
        </div>
      </div>
    </div>
  );
}

export default WeatherInfo;