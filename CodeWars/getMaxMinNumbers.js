function highAndLow(numbers) {
        numbers = numbers.split(' ').map(Number)
        let max = numbers[0]
        let min = numbers[0]

        numbers.forEach((num) => {
                if (num > max) max = num
                else if (num < min) min = num
        })

        return max + ' ' + min
}

//Simple version:
//The spread syntax (...) allows an iterable (like an array) to be expanded into individual elements.
//This is useful for passing elements of an array as separate arguments to functions that do not accept arrays directly.

function highAndLow2(numbers) {
        let nums = numbers.split(' ').map(Number)

        return Math.max(...nums) + ' ' + Math.min(...nums)
}

console.log(highAndLow2('8 3 -5 42 -1 0 0 -9 4 7 4 -4')) //42 -9
