/*
accum("abcd") -> "A-Bb-Ccc-Dddd"
accum("RqaEzty") -> "R-Qq-Aaa-Eeee-Zzzzz-Tttttt-Yyyyyyy"
accum("cwAt") -> "C-Ww-Aaa-Tttt"
*/

function accum(s) {
        // your code
        let chars = ''

        for (let i = 0; i < s.length; i++) {
                for (let j = 0; j < i + 1; j++) {
                        if (j === 0) chars += s[i].toUpperCase()
                        else chars += s[i].toLowerCase()
                }

                if (i === s.length - 1) break
                chars += '-'
        }

        return chars
}

//Simple way to do it:
function accum2(s) {
        return s
                .split('')
                .map((char, index) => char.toUpperCase() + char.toLowerCase().repeat(index))
                .join('-')
}

console.log(accum2('abcd'))
