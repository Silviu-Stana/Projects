function twiceAsOld(dadYearsOld, sonYearsOld) {
        // your code here
        let years = 0

        if (sonYearsOld / dadYearsOld < 0.5)
                while (sonYearsOld / dadYearsOld < 0.5) {
                        years++
                        sonYearsOld++
                        dadYearsOld++
                }
        if (sonYearsOld / dadYearsOld > 0.5)
                while (sonYearsOld / dadYearsOld > 0.5) {
                        years++
                        sonYearsOld--
                        dadYearsOld--
                }

        return years
}
console.log(twiceAsOld(55, 30))
