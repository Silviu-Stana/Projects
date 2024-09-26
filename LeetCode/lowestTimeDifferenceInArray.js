/**
 * @param {string[]} timePoints
 * @return {number}
 */
var findMinDifference = function (timePoints) {
        let map = new Map()

        //convert to minutes
        for (let i = 0; i < timePoints.length; i++) {
                let first2Digits = parseInt(timePoints[i].substring(0, 2))
                let second2Digits = parseInt(timePoints[i].substring(3, 5))

                if (first2Digits >= 12) {
                        first2Digits = 24 - first2Digits
                        timePoints[i] = first2Digits * 60 - second2Digits
                } else if (first2Digits < 12) {
                        timePoints[i] = first2Digits * 60 + second2Digits

                        console.log(timePoints[i])
                }
        }

        let min = 9999999999
        //find minimum subtraction (with Absolute function so that it's always positive number)
        for (let i = 0; i < timePoints.length; i++) {
                for (let j = i + 1; j < timePoints.length; j++) {
                        if (Math.abs(timePoints[i] - timePoints[j]) < min) min = Math.abs(timePoints[i] - timePoints[j])
                }
        }

        return min
}

console.log(findMinDifference(['12:12', '00:13']))

//My solution. passes 71/114 cases.
