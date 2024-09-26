/**
 * @param {number} n
 * @param {number} k
 * @return {number}
 */
var findKthNumber = function (n, k) {
        //localeCompare on array of numbers from 1 to n (will sort it lexicographically)
        let array = [];

        for (let i = 1; i <= n; i++) {
                array.push(i);
        }

        //localeCompare function only works on a string. map every element to string
        array = array.map((a) => a.toString());

        array.sort((a, b) => a.localeCompare(b));

        //once the array is create, pick the k'th number
        return Number(array[k - 1]); //-1 because array starts from 0
};

console.log(findKthNumber(9885387, 8907623));

//I succeded the hard challenge, but this is an inefficient solution, and it takes a couple of seconds to compute with very large numbers (around 10 million or so...)

//And efficient solution would make use of tries.
