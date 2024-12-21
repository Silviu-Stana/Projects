class Vehicle {
      drive(): void {
            console.log('chugga chugga');
      }

      honk(): void {
            console.log('honk');
      }
}

const vehicle = new Vehicle();

class Car extends Vehicle {}

const car = new Car();

car.drive();
car.honk();
