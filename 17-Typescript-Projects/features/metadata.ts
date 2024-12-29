import 'reflect-metadata';

@printMetadata
class Plane {
      color: string = 'red';

      @markFunction('HI THERE')
      fly(): void {
            console.log('vrrrrr');
      }
}

function markFunction(secretInfo: string) {
      return function (target: Plane, key: string): void {
            Reflect.defineMetadata('secret', secretInfo, target, key);
      };
}
// const secret = Reflect.getMetadata('secret', Plane.prototype, 'fly');

//typeof Plane - is a reference to the constructor
function printMetadata(target: typeof Plane) {
      for (let key in target.prototype) {
            const secret = Reflect.getMetadata('secret', target.prototype, key);
            console.log(secret);
      }
}
