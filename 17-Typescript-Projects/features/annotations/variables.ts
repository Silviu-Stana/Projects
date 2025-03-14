let apples = 5;
let speed: string = 'fast';
let hasName: boolean = true;
let nothingMuch: null = null;
let nothing: undefined = undefined;

let now: Date = new Date();

let colors: string[] = ['red', 'green', 'blue'];
let myNumbers: number[] = [1];
let truths: boolean[] = [true, false];

//Object Literal
let point: { x: number; y: number } = {
      x: 10,
      y: 20,
};

//This is still VARIABLE annotation of type function
const logNumber: (i: number) => void = (i: number) => {
      console.log(i);
};

//When to use annotations
//1 Funcs that return 'any' type
const json = '{"x":10, "y": 20}';
const coordinates: { x: number; y: number } = JSON.parse(json);
console.log(coordinates);

//2 When we declare a variable on 1 line
//and initialize it later
let words = ['red', 'green', 'blue'];
let foundWord: boolean;

for (let i = 0; i < words.length; i++) {
      if (words[i] === 'green') {
            foundWord = true;
      }
}

//3 Variable whose type cannot be inferred correctly
let numbers = [-10, -1, 12];
let numbersAboveZero: boolean | number = false;
for (let i = 0; i < numbers.length; i++) {
      if (numbers[i] > 0) {
            numbersAboveZero = numbers[i];
      }
}
