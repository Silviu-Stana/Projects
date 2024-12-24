class Vehicle {
      constructor(public color: string) {}

      public drive(): void {
            console.log('chugga chugga');
      }

      public honk(): void {
            console.log('honk');
      }
}

const vehicle = new Vehicle('orange');

class Car extends Vehicle {
      constructor(public wheels: number, color: string) {
            super(color);
      }

      drive(): void {
            console.log('vroom');
      }

      startDriving(): void {
            this.drive();
      }
}

const car = new Car(4, 'red');
