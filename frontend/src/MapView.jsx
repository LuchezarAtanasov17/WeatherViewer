import { useState, useEffect, useCallback } from "react";
import { MapContainer, TileLayer, useMapEvents } from "react-leaflet";
import ChangeMapView from "./ChangeMapView";
import WeatherInfo from "./WeatherInfo";
import DraggableMarker from "./DraggableMarker";
import "leaflet/dist/leaflet.css";
import "./MapView.css";

const fallbackPosition = [42.6977, 23.3219];
const apiBaseUrl = import.meta.env.VITE_API_BASE_URL;

function MapView() {
  const [position, setPosition] = useState(fallbackPosition);
  const [weather, setWeather] = useState(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  const fetchWeather = useCallback(async (lat, lon) => {
    try {
      setLoading(true);
      setError(null);
      const response = await fetch(`${apiBaseUrl}/weather?lat=${lat}&lon=${lon}`);
      if (!response.ok) throw new Error(await response.text());
      const data = await response.json();
      setWeather(data);
    } catch (err) {
      console.error(err);
      setError(err.message);
      setWeather(null);
    } finally {
      setLoading(false);
    }
  }, []);

  useEffect(() => {
    if (!navigator.geolocation) {
      console.warn("The geolocation is not supported in this browser.");
      setPosition(fallbackPosition);
      fetchWeather(...fallbackPosition);
      return;
    }

    navigator.geolocation.getCurrentPosition(
      (pos) => {
        const { latitude, longitude } = pos.coords;
        setPosition([latitude, longitude]);
        fetchWeather(latitude, longitude);
      },
      (error) => {
        console.warn("Грешка при геолокация:", error);
        setPosition(fallbackPosition);
        fetchWeather(...fallbackPosition);
      },
      { enableHighAccuracy: true, timeout: 10000 }
    );
  }, [fetchWeather]);

  function MapClickHandler() {
    useMapEvents({
      click: (e) => {
        const { lat, lng } = e.latlng;
        setPosition([lat, lng]);
        fetchWeather(lat, lng);
      },
    });
    return null;
  }

  const handleMarkerMove = (lat, lon) => {
    setPosition([lat, lon]);
    fetchWeather(lat, lon);
  };

  return (
    <div className="map-wrapper" style={{ display: "flex" }}>
      <MapContainer
        center={position}
        zoom={13}
        className="map-container"
      >
        <TileLayer
          url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
          attribution='&copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors'
        />
        <ChangeMapView center={position} zoom={13} />

        <MapClickHandler />

        <DraggableMarker position={position} onMove={handleMarkerMove} />
      </MapContainer>

      <div className="info-panel">
        <WeatherInfo weather={weather} loading={loading} error={error} />
      </div>
    </div>
  );
}

export default MapView;