/*
Given an array of integers.

Return an array, where the first element is the count of positives numbers and the second element is sum of negative numbers. 0 is neither positive nor negative.

If the input is an empty array or is null, return an empty array.

Example
For input [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, -11, -12, -13, -14, -15], you should return [10, -65].
*/

function countPositivesSumNegatives(input) {
        // your code here
        let count = 0
        let negativeSum = 0

        //edge case if we feed it null
        if (input !== null)
                input.forEach((c) => {
                        if (c > 0) count++
                        else negativeSum += c
                })

        //edge case if array is empty
        if (count === 0 && negativeSum === 0) return []
        return [count, negativeSum]
}
