function sortArray(array) {
        let oddNums = [];
        let oddCounter = 0;

        for (let i = 0; i < array.length; i++) {
                if (array[i] % 2 === 1 || array[i] % 2 === -1) {
                        oddNums.push(array[i]);
                }
        }

        oddNums = oddNums.sort((a, b) => a - b);

        for (let i = 0; i < array.length; i++) {
                if (array[i] % 2 === 1 || array[i] % 2 === -1) {
                        array[i] = oddNums[oddCounter++];
                }
        }

        return array;
}

console.log(sortArray([5, 3, 2, 8, 1, 4]));
