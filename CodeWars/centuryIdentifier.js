function century(year) {
        if (year % 100 === 0) {
                if (year > 100) {
                        let digitCount = year.toString().length;
                        return parseInt(
                                year.toString().substring(0, digitCount - 2)
                        );
                } else return 0;
        } else {
                if (year > 100) {
                        let digitCount = year.toString().length;
                        return (
                                parseInt(
                                        year
                                                .toString()
                                                .substring(0, digitCount - 2)
                                ) + 1
                        );
                } else return 1;
        }
}
//

//Simple version:
function century2(year) {
        return Math.ceil(year / 100); //using ceiling method to round up to nearest century (100)
}
