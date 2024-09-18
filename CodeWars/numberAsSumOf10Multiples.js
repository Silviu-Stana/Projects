/*
You will be given a number and you will need to return it as a string in Expanded Form. For example:

expandedForm(12); // Should return '10 + 2'
expandedForm(42); // Should return '40 + 2'
expandedForm(70304); // Should return '70000 + 300 + 4'
*/

function expandedForm(num) {
        // Your code here
        let multiplier = 1
        let left = num
        let numbers = []

        while (left > 0) {
                if (left % 10 !== 0) {
                        numbers.push((left % 10) * multiplier)
                        left -= left % 10
                }

                left /= 10
                multiplier *= 10
        }

        return numbers.reverse().join(' + ')
}

console.log(expandedForm(12))
console.log(expandedForm(42))
console.log(expandedForm(70304))
