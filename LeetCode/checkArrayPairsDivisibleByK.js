/**
 * @param {number[]} arr
 * @param {number} k
 * @return {boolean}
 */
var canArrange = function (arr, k) {
        let remainder = new Array(k).fill(0);

        for (let i = 0; i < arr.length; i++) {
                let restCalc = arr[i] % k;

                if (restCalc < 0) restCalc += k;

                remainder[restCalc]++;
        }

        console.log(remainder);

        if (remainder[0] % 2 !== 0) return false;

        for (let i = 1; i < k / 2; i++) {
                if (remainder[i] !== remainder[k - i]) return false;
        }

        return true;
};

console.log(canArrange([1, 2, 3, 4, 5, 10, 6, 7, 8, 9], 5)); //expected true, passed
console.log(canArrange([1, 2, 3, 4, 5, 6], 7)); //expected true, passed

//Works with negative numbers too! All we have to do is add k to the remainder number, which will make it positive, while also staying smaller than k (positive remainder)!
