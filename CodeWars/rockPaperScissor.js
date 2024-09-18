const rps = (p1, p2) => {
        let weapons = {
                rock: { win: 'scissors', lose: 'paper' },
                paper: { win: 'rock', lose: 'scissors' },
                scissors: { win: 'paper', lose: 'rock' },
        }

        //First check if weapon even exists.
        if (!weapons[p1]) return 'Player 1 has invalid weapon!'
        if (!weapons[p2]) return 'Player 2 has invalid weapon!'

        if (weapons[p1].win === p2) return 'Player 1 won!'
        if (weapons[p1].lose === p2) return 'Player 2 won!'
        else if (p1 === p2) return 'Draw!'
}

console.log(rps('scissors', 'paper'))
console.log(rps('scissors', 'rock'))
console.log(rps('paper', 'paper'))
console.log(rps('pot', 'paper'))
