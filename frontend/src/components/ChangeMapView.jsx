import { useEffect } from "react";
import { useMap } from "react-leaflet";

function ChangeMapView({ center, zoom }) {
  const map = useMap();

  useEffect(() => {
    if (center) {
      map.setView(center, zoom);
    }
  }, [center, zoom, map]);

  return null;
}

export default ChangeMapView;