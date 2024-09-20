/**
 * @param {number} x
 * @return {boolean}
 */
var isPalindrome = function (x) {
        let nums = x.toString().split('')
        console.log(nums)

        let nums2 = nums.toReversed()
        console.log(nums2)

        nums = nums.join('')
        nums2 = nums2.join('')

        console.log(nums === nums2)

        return nums === nums2
}

isPalindrome(121)
