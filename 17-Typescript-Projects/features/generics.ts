class ArrayOfNumbers {
      constructor(public collection: number[]) {}

      get(index: number): number {
            return this.collection[index];
      }
}

class ArrayOfStrings {
      constructor(public collection: string[]) {}

      get(index: number): string {
            return this.collection[index];
      }
}

class ArrayOf<T> {
      constructor(public collection: T[]) {}

      get(index: number): T {
            return this.collection[index];
      }
}

const arr = new ArrayOf<string>(['a', 'b']);

//Generics funcs
function printStrings(arr: string[]): void {
      for (let i = 0; i < arr.length; i++) console.log(arr[i]);
}

function printNumbers(arr: number[]): void {
      for (let i = 0; i < arr.length; i++) console.log(arr[i]);
}

function printAnything<T>(arr: T[]): void {
      for (let i = 0; i < arr.length; i++) console.log(arr[i]);
}

printAnything<string>(['a', 'b']);

//Generic Constraints
class Car2 {
      print() {
            console.log('I am a Car');
      }
}

class House {
      print() {
            console.log('I am a House');
      }
}

interface Printable {
      print(): void;
}

function printHousesOrCars<T extends Printable>(arr: T[]): void {
      for (let i = 0; i < arr.length; i++) arr[i].print();
}

printHousesOrCars<House | Car2>([new House(), new Car2()]);
