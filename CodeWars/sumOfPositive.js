/*
You get an array of numbers, return the sum of all of the positives ones.

Example [1,-4,7,12] => 1 + 7 + 12 = 20

Note: if there is nothing to sum, the sum is default to 0.
*/

function positiveSum(arr) {
        let sum=0;
        for(let i=0; i<arr.length; i++) if(arr[i]>0)sum+=arr[i];
        
        return sum;
      }

console.log(positiveSum([50,82,31,-3,-57,81,6,58,-94,-90,-33,-88,4,-12,49,49,-39,68,93,-15,-45,-94,-75,50,-33,-5,-16,-22,70,82,-86,-78,82,30,88,53,-75,1,-62,-2,93,-29,38,-26,13,-84,18,10,1,-65,21,24]))
//should equal 1245