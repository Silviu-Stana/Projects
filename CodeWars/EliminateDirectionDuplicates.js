function dirReduc(arr) {
        let i = 0;

        while (i < arr.length - 1) {
                if (
                        (arr[i] === 'NORTH' && arr[i + 1] === 'SOUTH') ||
                        (arr[i] === 'SOUTH' && arr[i + 1] === 'NORTH') ||
                        (arr[i] === 'EAST' && arr[i + 1] === 'WEST') ||
                        (arr[i] === 'WEST' && arr[i + 1] === 'EAST')
                ) {
                        // Remove the pair
                        arr.splice(i, 2);
                        // Reset index to start from the beginning
                        i = 0;
                } else {
                        i++;
                }
        }

        return arr;
}
console.log(dirReduc(['NORTH', 'SOUTH', 'SOUTH', 'EAST', 'WEST', 'NORTH', 'WEST']));
