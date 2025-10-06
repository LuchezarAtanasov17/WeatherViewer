import { Marker } from "react-leaflet";
import markerIcon from "../utils/markerIcon";

function DraggableMarker({ position, onMove }) {
  const handleDragEnd = (e) => {
    const { lat, lng } = e.target.getLatLng();
    onMove(lat, lng);
  };

  return (
    <Marker
      key={`${position[0]}-${position[1]}`}
      position={position}
      draggable
      icon={markerIcon}
      eventHandlers={{ dragend: handleDragEnd }}
    />
  );
}

export default DraggableMarker;
