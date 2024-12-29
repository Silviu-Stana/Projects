@classDecorator
class Boat {
      @testDecorator
      color: string = 'red';

      @testDecorator
      get formattedColor(): string {
            return `This boat color is ${this.color}`;
      }

      @logError('oops boat was sunk')
      pilot(@parameterDecorator speed: string): void {
            // throw new Error();
            if ((speed = 'fast')) console.log('swish');
            else console.log('nothing');
      }
}

function testDecorator(target: any, key: string) {
      console.log(key);
}

function classDecorator(constructor: typeof Boat) {
      console.log(constructor);
}

function parameterDecorator(target: any, key: string, index: number) {
      console.log(key, index);
}

function logError(errorMessage: string) {
      return function (target: any, key: string, desc: PropertyDescriptor): void {
            const method = desc.value;
            desc.value = function () {
                  try {
                        method();
                  } catch (e) {
                        console.log(errorMessage);
                  }
            };
      };
}
