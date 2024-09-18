function reverseWords(str) {
        //First reverse all letters (and order of words)
        str = str.split('').reverse().join('')

        //Then reverse only the order of words, which will bring it back to it's original word order! (but characters will still be flipped)
        return str.split(' ').reverse().join(' ')
}
