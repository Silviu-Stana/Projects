function persistence(num) {
        let count = 0;
        while (num > 9) {
                num = num
                        .toString()
                        .split('')
                        .map(Number)
                        .reduce((a, b) => a * b);

                console.log(num);

                count++;
        }
        console.log(count + ' times');
        return count;
}

persistence(25);
