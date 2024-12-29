import 'reflect-metadata';

@controller
class Plane {
      color: string = 'red';

      @get('/login')
      fly(): void {
            console.log('vrrrrr');
      }
}

function get(path: string) {
      return function (target: Plane, key: string): void {
            Reflect.defineMetadata('path', path, target, key);
      };
}

//typeof Plane - is a reference to the constructor
function controller(target: typeof Plane) {
      for (let key in target.prototype) {
            const path = Reflect.getMetadata('path', target.prototype, key);
            console.log(path);

            //router.get(path, target.prototype[key])
      }
}
