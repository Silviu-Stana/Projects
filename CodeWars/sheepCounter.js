function countSheeps(sheep) {
        var num = 0

        sheep.forEach((sheep) => {
                if (sheep === true) num++
        })

        return num
}

console.log(countSheeps([undefined, null, false, true]))
