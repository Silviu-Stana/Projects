// <!-- Describe your approach to solving the problem. -->
// I tried using findIndex to search the entire array, excluding the element currently being searched.

// - Time complexity: 440ms
// - Space complexity: O(n^2)

/**
 * @param {number[]} nums
 * @param {number} target
 * @return {number[]}
 */
var twoSum = function (nums, target) {
    for(let i=0; i<nums.length; i++)
    {
        let foundIndex = nums.findIndex((num, index)=> index !== i &&  num + nums[i] === target);

        if(foundIndex>-1) return [i, foundIndex];
    }
};

console.log(twoSum([2,7,10,1], 9));