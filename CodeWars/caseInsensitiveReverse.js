function isPalindrome(x) {
        x = x.toLowerCase()

        let y = x.split('').toReversed().join('')
        return x === y
}

console.log(isPalindrome('Aba'))
