/*
Given the triangle of consecutive odd numbers:

             1
          3     5
       7     9    11
   13    15    17    19
21    23    25    27    29
...
Calculate the sum of the numbers in the nth row of this triangle (starting at index 1) e.g.: (Input --> Output)

1 -->  1
2 --> 3 + 5 = 8
*/

function rowSumOddNumbers(n) {
        //n row has n elements
        if (n === 0) return 0
        if (n === 1) return 1

        let sum = 0

        //1st element on each line = (n-1)*2
        for (let i = 0; i < n; i++) {
                sum += n * (n - 1) + 1 + i * 2
        }

        return sum
}
