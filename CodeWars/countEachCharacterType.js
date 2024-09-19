function count(string) {
        let FinalCount = {}

        while (string !== '') {
                let tempString = string.split('')

                //take first character in substring.
                let currentChar = tempString[0]

                //filter for that Character
                let currentCharCount = tempString.filter((char) => char === currentChar).length

                //store it in javascript object as key value pair: A: 3
                FinalCount[currentChar] = currentCharCount

                //Update string, removing all occurences of that character we just counted.
                string = string.replaceAll(currentChar, '')
        }

        return FinalCount
}

console.log(count('abbcccAAABBXXEHTTYEWET')) //{ a: 1, b: 2, c: 3, A: 3, B: 2, X: 2, E: 3,  H: 1, T: 3, Y: 1, W: 1 }
