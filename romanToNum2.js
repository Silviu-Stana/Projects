//This 2nd version should be a lot more efficient.

/**
 * @param {string} s
 * @return {number}
 */
var romanToInt = function (s) {
        let sum = 0
        let Roman = {
                I: 1,
                V: 5,
                X: 10,
                L: 50,
                C: 100,
                D: 500,
                M: 1000,
        }

        for (let i = 0; i < s.length; i++) {
                console.log(i)

                if (i === s.length - 1) {
                        sum += Roman[s[i]]
                        break
                }

                if (Roman[s[i]] >= Roman[s[i + 1]]) sum += Roman[s[i]]
                else {
                        sum += Roman[s[i + 1]] - Roman[s[i]]
                        i++
                }
        }

        console.log(s)

        return sum
}

console.log(romanToInt('MMMXLV'))
console.log(romanToInt('III'))
console.log(romanToInt('MCDLXXVI'))
