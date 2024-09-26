// <!-- Describe your approach to solving the problem. -->
// I tried using findIndex to search the entire array, excluding the element currently being searched.

// - Time complexity: 440ms
// - Space complexity: O(n^2)

/**
 * @param {number[]} nums
 * @param {number} target
 * @return {number[]}
 */
var twoSumV1Unoptimized = function (nums, target) {
    for(let i=0; i<nums.length; i++)
    {
        let foundIndex = nums.findIndex((num, index)=> index !== i &&  num + nums[i] === target);

        if(foundIndex>-1) return [i, foundIndex];
    }
};

var twoSumV2Optimized = function(nums, target) {
        let numMap = {}
    
        for(let i=0; i<nums.length; i++)
        {
            let difference = target-nums[i];
    
            //Pair found, return numbers.
            if(numMap.hasOwnProperty(difference)) return [i, numMap[difference]]
    
            //If no pair found, add it to the hash map.
            numMap[nums[i]]=i;
        }
    
        //Haven't found a match.
        return null;
    };

console.log(twoSumV2Optimized([2,7,10,1], 9));