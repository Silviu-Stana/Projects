interface Reportable {
      summary(): string;
}

const oldCivic = {
      name: 'civic',
      year: new Date(),
      broken: true,
      bonusProperty: true, //valid in typescript
      summary(): string {
            return `Name: ${this.name}`;
      },
};

const drink2 = {
      color: 'brown',
      carbonated: true,
      sugar: 40,
      summary(): string {
            return `My drink has ${this.sugar} grams of sugar`;
      },
};

// const itemSummary = (item: { name: string; year: number; broken: boolean }): void => {
const printSummary = (item: Reportable): void => {
      console.log(`Name: ${item.summary()}`);
};

printSummary(oldCivic);
printSummary(drink2);
