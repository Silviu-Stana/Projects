function dnaStrand(dna) {
        let dnaArray = dna.split('')

        for (let i = 0; i < dnaArray.length; i++) {
                switch (dnaArray[i]) {
                        case 'A':
                                dnaArray[i] = 'T'
                                break
                        case 'T':
                                dnaArray[i] = 'A'
                                break
                        case 'C':
                                dnaArray[i] = 'G'
                                break
                        case 'G':
                                dnaArray[i] = 'C'
                                break
                }
        }

        return dnaArray.join('')
}

console.log(dnaStrand('CCCC'))
