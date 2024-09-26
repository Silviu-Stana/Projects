/**
 * @param {string[]} strs
 * @return {string}
 */
var longestCommonPrefix = function (strs) {
        let max = 0;

        if (strs.length === 0) return '';
        if (strs.length === 1) return strs[0];

        for (let current = 0; current < strs[0].length; current++) {
                let letter = strs[0].substring(current, current + 1);

                for (let i = 1; i < strs.length; i++) {
                        if (strs[i].substring(current, current + 1) !== letter) return strs[0].substring(0, max);
                }
                max++;
        }

        return strs[0].substring(0, max);
};

console.log(longestCommonPrefix(['flower', 'flow', 'flight']));
