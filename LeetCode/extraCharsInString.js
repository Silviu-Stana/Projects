/**
 * @param {string} s
 * @param {string[]} dictionary
 * @return {number}
 */
var minExtraChar = function (s, dictionary) {
        //find index of each dictionary word inside "s"
        for (let i = 0; i < dictionary.length; i++) {
                s = s.replaceAll(dictionary[i], '');
        }

        return s.length;
        //remove it from 's'
};

console.log(minExtraChar('leetscode', ['leet', 'code', 'leetcode'])); //expected 1
//the solution off the top of my brain: 945 / 2028 testcases passed, failed this one:
console.log(minExtraChar('dwmodizxvvbosxxw', ['ox', 'lb', 'diz', 'gu', 'v', 'ksv', 'o', 'nuq', 'r', 'txhe', 'e', 'wmo', 'cehy', 'tskz', 'ds', 'kzbu'])); //expected 7
