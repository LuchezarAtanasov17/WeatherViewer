import { Marker } from "react-leaflet";
import L from "leaflet";

const markerIcon = new L.Icon({
  iconUrl: "https://unpkg.com/leaflet@1.9.4/dist/images/marker-icon.png",
  iconSize: [25, 41],
  iconAnchor: [12, 41],
  popupAnchor: [1, -34],
  shadowUrl: "https://unpkg.com/leaflet@1.9.4/dist/images/marker-shadow.png",
  shadowSize: [41, 41],
});

function DraggableMarker({ position, onMove }) {
  const handleDragEnd = (e) => {
    const { lat, lng } = e.target.getLatLng();
    onMove(lat, lng);
  };

  return (
    <Marker
      key={`${position[0]}-${position[1]}`}
      position={position}
      draggable={true}
      icon={markerIcon}
      eventHandlers={{ dragend: handleDragEnd }}
    />
  );
}

export default DraggableMarker;
