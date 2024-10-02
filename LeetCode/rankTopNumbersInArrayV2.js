/**
 * @param {number[]} arr
 * @return {number[]}
 */
var arrayRankTransform = function (arr) {
        let rankArr = arr.toSorted((a, b) => a - b);

        let rank = 1;

        let hashMap = new Map();

        for (let i = 0; i < rankArr.length; i++) {
                if (!hashMap.has(rankArr[i])) {
                        hashMap.set(rankArr[i], rank);
                        rank++;
                }
        }

        return arr.map((num) => hashMap.get(num));
};

console.log(arrayRankTransform([37, 12, 28, 9, 100, 56, 80, 5, 12])); //expected output: [5,3,4,2,8,6,7,1,3]

//On the other hand, Solution V2 works all the time, using a hash map!
