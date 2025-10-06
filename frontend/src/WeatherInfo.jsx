function WeatherInfo({ weather, loading, error }) {
  if (loading) return <p>Loading...</p>;
  if (error) return <p>Грешка: {error}</p>;
  if (!weather) {
    return <p>No data yet...</p>;
  }
  return (
    <div className="weather-panel">
      <h2>Current weather</h2>
      <p><strong>{weather.description}</strong></p>
      <p>Temperature: {weather.temperature ?? "?"}°C</p>
      <p>Humidity: {weather.humidity ?? "?"}%</p>
      <p>Wind speed: {weather.windSpeed ?? "?"} m/s</p>
      <p>Timezone: {weather.timezone}</p>
      {weather.icon && (
        <img
          src={`https://openweathermap.org/img/wn/${weather.icon}@2x.png`}
          alt="icon"
        />
      )}
    </div>
  );
}

export default WeatherInfo;