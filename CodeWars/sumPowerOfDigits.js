/*
Given two positive integers n and p, we want to find a positive integer k, if it exists,
such that the sum of the digits of n raised to consecutive powers starting from p is equal to k * n.
If it is the case we will return k, if not return -1.

Note: n and p will always be strictly positive integers.

Examples:
n = 89; p = 1 ---> 1 since 8¹ + 9² = 89 = 89 * 1

n = 92; p = 1 ---> -1 since there is no k such that 9¹ + 2² equals 92 * k

n = 695; p = 2 ---> 2 since 6² + 9³ + 5⁴= 1390 = 695 * 2

n = 46288; p = 3 ---> 51 since 4³ + 6⁴+ 2⁵ + 8⁶ + 8⁷ = 2360688 = 46288 * 51
*/

function digPow(n, p) {
        let n2 = n
        let sum = 0

        //sum of digits to power of p++
        n2 = n2.toString().split('').map(Number)

        for (let i = 0; i < n2.length; i++) {
                sum += Math.pow(n2[i], p++)
        }

        if (sum % n === 0) return sum / n
        else return -1
}

console.log(digPow(89, 1))
