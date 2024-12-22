//Instructions to every other class//on how they can be an argument to "addMarker"
export interface Mappable {
      location: {
            lat: number;
            lng: number;
      };
      markerContent(): string;
      color: string;
}

export class CustomMap {
      private googleMap: google.maps.Map;

      constructor(divId: string) {
            const mapElement = document.getElementById(divId);
            if (mapElement) {
                  this.googleMap = new google.maps.Map(mapElement, {
                        zoom: 1,
                        center: {
                              lat: 0,
                              lng: 0,
                        },
                  });
            } else {
                  console.error('Map element not found');
            }
      }

      addMarker(mappable: Mappable): void {
            //With "|" you are only allowed to use properties that those 2 classes have in common.
            const marker = new google.maps.Marker({
                  map: this.googleMap,
                  position: {
                        lat: mappable.location.lat,
                        lng: mappable.location.lng,
                  },
            });

            marker.addListener('click', () => {
                  const infoWindow = new google.maps.InfoWindow({
                        content: mappable.markerContent(),
                  });

                  infoWindow.open(this.googleMap, marker);
            });
      }
}
