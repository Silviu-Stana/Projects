//New solution which passes all test cases.

/**
 * @param {string[]} timePoints
 * @return {number}
 */
var findMinDifference = function (timePoints) {
        //convert to minutes
        for (let i = 0; i < timePoints.length; i++) {
                timePoints[i] = parseInt(timePoints[i].substring(0, 2)) * 60 + parseInt(timePoints[i].substring(3, 5))
        }

        //sort times in ascending order
        timePoints.sort((a, b) => a - b)

        let min = Infinity
        //find minimum subtraction (with Absolute function so that it's always positive number)
        for (let i = 0; i < timePoints.length - 1; i++) {
                min = Math.min(min, Math.abs(timePoints[i + 1] - timePoints[i]))
        }

        //handle final edge case, where we compare last timeStamp with the first one
        min = Math.min(min, 24 * 60 - timePoints[timePoints.length - 1] + timePoints[0])

        return min
}

console.log(findMinDifference(['00:00', '00:00']))
