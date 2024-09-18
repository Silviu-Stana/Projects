/*
Given a list of non-negative integers nums, arrange them such that they form the largest number and return it.
Since the result may be very large, so you need to return a string instead of an integer.

 
Example 1:
Input: nums = [10,2]
Output: "210"

Example 2:
Input: nums = [3,30,34,5,9]
Output: "9534330"
*/

/**
 * @param {number[]} nums
 * @return {string}
 */
var largestNumber = function (nums) {
        // Convert integers to strings
        let array = nums.map(String)

        // Custom sorting with a comparator function
        array.sort((a, b) => (b + a).localeCompare(a + b))

        // Build the largest number from the sorted array
        return array.join('')
}

console.log(largestNumber([10, 22, 3, 31, 300, 299]))
