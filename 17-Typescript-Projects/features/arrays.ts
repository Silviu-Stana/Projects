const carMakers = ['ford', 'toyota', 'chevy'];
const dates = [new Date(), new Date()];

//This
const carsByMake = [['f140'], ['corolla'], ['camaro']];
//Or this
const carsByMake2: string[][] = [];

//Infers when extracting values
const car2 = carMakers[0];
const myCar = carMakers.pop();

//Prevent incompatible values
carMakers.push('wow');

//Help with "map"
carMakers.map((car: string): string => {
      return car;
});

//Flexible types
const importantDates: (Date | string)[] = [new Date(), '2030-10-10'];
importantDates.push('2030-10-10');
importantDates.push(new Date());
