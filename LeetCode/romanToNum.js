/**
 * @param {string} s
 * @return {number}
 */
var romanToInt = function (s) {
        let sum = 0
        s = s.replace('IV', (match) => {
                sum += 4
                return '' //replacement string
        })

        s = s.replace('IX', (match) => {
                sum += 9
                return '' //replacement string
        })

        s = s.replace('XL', (match) => {
                sum += 40
                return '' //replacement string
        })

        s = s.replace('XC', (match) => {
                sum += 90
                return '' //replacement string
        })

        s = s.replace('CD', (match) => {
                sum += 400
                return '' //replacement string
        })

        s = s.replace('CM', (match) => {
                sum += 900
                return '' //replacement string
        })

        s = s.split('')

        sum += s.filter((num) => num === 'I').length * 1
        sum += s.filter((num) => num === 'V').length * 5
        sum += s.filter((num) => num === 'X').length * 10
        sum += s.filter((num) => num === 'L').length * 50
        sum += s.filter((num) => num === 'C').length * 100
        sum += s.filter((num) => num === 'D').length * 500
        sum += s.filter((num) => num === 'M').length * 1000

        console.log(s)

        return parseInt(sum)
}

console.log(romanToInt('MMMXLV'))
console.log(romanToInt('III'))
console.log(romanToInt('MCDLXXVI'))
