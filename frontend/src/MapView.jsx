import { useState, useEffect } from "react";
import { MapContainer, TileLayer } from "react-leaflet";
import ChangeMapView from "./ChangeMapView";
import "leaflet/dist/leaflet.css";
import "./MapView.css";

const fallbackPosition = [42.6977, 23.3219];

function MapView() {
  const [position, setPosition] = useState(fallbackPosition);

  useEffect(() => {
    if (!navigator.geolocation) {
      console.warn("Геолокацията не се поддържа от този браузър.");
      setPosition(fallbackPosition);
      return;
    }

    navigator.geolocation.getCurrentPosition(
      (pos) => {
        const { latitude, longitude } = pos.coords;
        setPosition([latitude, longitude]);
      },
      (error) => {
        console.warn("Грешка при геолокация:", error);
        setPosition(fallbackPosition);
      },
      { enableHighAccuracy: true, timeout: 10000 }
    );
  }, []);

  return (
    <MapContainer
      center={position}
      zoom={13}
      className="map-container"
      style={{ height: "100vh", width: "100%" }}
    >
      <TileLayer
        url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
        attribution='&copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors'
      />
      <ChangeMapView center={position} zoom={13} />
    </MapContainer>
  );
}

export default MapView;