/**
 * @param {number[]} arr
 * @return {number[]}
 */
var arrayRankTransform = function (arr) {
        let rankArr = arr.toSorted((a, b) => a - b);
        console.log(rankArr);
        let rank = 1;

        //We need this function to use: replaceAll
        arr = arr.join(' ');

        for (let i = 0; i < rankArr.length - 1; i++) {
                arr = arr.replaceAll(rankArr[i].toString(), rank.toString());

                if (rankArr[i] !== rankArr[i + 1]) rank++;
        }

        arr = arr.replaceAll(rankArr[rankArr.length - 1].toString(), rank.toString());

        //After we are done, convert back to numbers.
        arr = arr.split(' ').map(Number);

        return arr;
};

console.log(arrayRankTransform([37, 12, 28, 9, 100, 56, 80, 5, 12]));
//Unfortunately this solution ALMOST always works, except for ocassional partial strings. for example the number 56 reads 5 and replace it with 1 =>16 instead of replacing 56 with 6
