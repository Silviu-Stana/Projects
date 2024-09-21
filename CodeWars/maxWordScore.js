function high(x) {
        const points = {
                a: 1,
                b: 2,
                c: 3,
                d: 4,
                e: 5,
                f: 6,
                g: 7,
                h: 8,
                i: 9,
                j: 10,
                k: 11,
                l: 12,
                m: 13,
                n: 14,
                o: 15,
                p: 16,
                q: 17,
                r: 18,
                s: 19,
                t: 20,
                u: 21,
                v: 22,
                w: 23,
                x: 24,
                y: 25,
                z: 26,
        };

        let scores = [];

        x = x.split(' ');

        for (let i = 0; i < x.length; i++) {
                scores[i] = 0;

                for (let j = 0; j < x[i].length; j++) {
                        let currentLetter = x[i].substring(j, j + 1);
                        scores[i] += points[currentLetter];
                }
        }

        let indexOfMax = scores.findIndex((element) => element === Math.max(...scores));

        return x[indexOfMax];
}

//Highest scoring word: "volcano"
console.log(high('what time are we climbing up the volcano'));
