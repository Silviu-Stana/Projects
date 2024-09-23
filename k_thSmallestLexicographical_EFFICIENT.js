/**
 * @param {number} n
 * @param {number} k
 * @return {number}
 */
var findKthNumber = function (n, k) {
        let curr = 1;
        k--; //we are subtracting the 1st element

        while (k > 0) {
                let steps = countSteps(curr, n);
                console.log('steps: ' + steps);

                if (steps <= k) {
                        k -= steps; //remove all children of current digit
                        curr++;
                } else {
                        k--; //only decrease 1 step as we move on to the next digit
                        curr *= 10; //since we start navigating under the current number
                }
                console.log('k: ' + k);
                console.log('curr: ' + curr);
        }

        console.log('Result: (position of K in the array)');

        return curr; //curr represents the position of the k'th element
};

function countSteps(curr, n) {
        let steps = 0;
        let first = curr;
        let last = curr;

        while (first <= n) {
                //there are still more sub-children under that number
                steps += Math.min(last, n) - first + 1;
                first = first * 10;
                last = last * 10 + 9;
        }

        return steps;
}

console.log(findKthNumber(9885387, 8907623));
//console.log(findKthNumber(13, 2)); // [1,10,11,12,13,2,3,4,5,6,7,8,9]  // return 10

//And this is the ultra fast solution! It returns Immediately!

//HERE ARE THE STEPS DEBUGGED STEP BY STEP.
//it looks like the algorithm subtracts always subtracts numbers with 1 repeated multiple times
//from the remaining 'k' value
//and so for each digit in a number, it can run a maximum of 9 times
//the complexity of memory is O(1) since we are not storing anything
//the actual algorithm itself rusn O(log n)

//Funny enough, the only times the step number is different from 1111.... is when steps>k so it can't decrease it anymore
//This persists all the way until the end, when it only subtract -11 or -1 each time.
/*
steps: 1111111
k: 7796511
curr: 2
steps: 1111111
k: 6685400
curr: 3
steps: 1111111
k: 5574289
curr: 4
steps: 1111111
k: 4463178
curr: 5
steps: 1111111
k: 3352067
curr: 6
steps: 1111111
k: 2240956
curr: 7
steps: 1111111
k: 1129845
curr: 8
steps: 1111111
k: 18734
curr: 9
steps: 996499
k: 18733
curr: 90
steps: 111111
k: 18732
curr: 900
steps: 11111
k: 7621
curr: 901
steps: 11111
k: 7620
curr: 9010
steps: 1111
k: 6509
curr: 9011
steps: 1111
k: 5398
curr: 9012
steps: 1111
k: 4287
curr: 9013
steps: 1111
k: 3176
curr: 9014
steps: 1111
k: 2065
curr: 9015
steps: 1111
k: 954
curr: 9016
steps: 1111
k: 953
curr: 90160
steps: 111
k: 842
curr: 90161
steps: 111
k: 731
curr: 90162
steps: 111
k: 620
curr: 90163
steps: 111
k: 509
curr: 90164
steps: 111
k: 398
curr: 90165
steps: 111
k: 287
curr: 90166
steps: 111
k: 176
curr: 90167
steps: 111
k: 65
curr: 90168
steps: 111
k: 64
curr: 901680
steps: 11
k: 53
curr: 901681
steps: 11
k: 42
curr: 901682
steps: 11
k: 31
curr: 901683
steps: 11
k: 20
curr: 901684
steps: 11
k: 9
curr: 901685
steps: 11
k: 8
curr: 9016850
steps: 1
k: 7
curr: 9016851
steps: 1
k: 6
curr: 9016852
steps: 1
k: 5
curr: 9016853
steps: 1
k: 4
curr: 9016854
steps: 1
k: 3
curr: 9016855
steps: 1
k: 2
curr: 9016856
steps: 1
k: 1
curr: 9016857
steps: 1
k: 0
curr: 9016858
9016858
*/
