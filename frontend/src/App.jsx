import "./App.css";
import MapView from "./MapView";
import WeatherInfo from "./WeatherInfo";

function App() {
  return (
    <div className="app-layout">
      <div className="map-section">
        <MapView />
      </div>
      <div className="info-panel">
        <h2>Данни от API</h2>
        <WeatherInfo/>  
      </div>
    </div>
  );
}

export default App;