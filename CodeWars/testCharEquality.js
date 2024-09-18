// XO("ooxx") => true
// XO("xooxx") => false
// XO("ooxXm") => true
// XO("zpzpzpp") => true // when no 'x' and 'o' is present should return true
// XO("zzoo") => false

function XO(str) {
        //code here
        str = str.split('')

        let xCount = 0,
                oCount = 0

        for (let i = 0; i < str.length; i++) {
                if (str[i].toLowerCase() === 'o') oCount++
                else if (str[i].toLowerCase() === 'x') xCount++
        }

        if (oCount === xCount) return true
        else return false
}

//Takes them character by character and puts them in an array x[] or o[]
//   /x/gi means global identifier, case insensitive, so it finds both big X and small x letters
function XO2(str) {
        let x = str.match(/x/gi)
        let o = str.match(/o/gi)
        return (x && x.length) === (o && o.length)
}

console.log(XO2('Xxoo'))
