/*
So, if we are to start our Tribonacci sequence with [1, 1, 1] as a starting input (AKA signature), we have this sequence:

[1, 1 ,1, 3, 5, 9, 17, 31, ...]
But what if we started with [0, 0, 1] as a signature? As starting with [0, 1] instead of [1, 1] basically shifts the common Fibonacci sequence by once place, you may be tempted to think that we would get the same sequence shifted by 2 places, but that is not the case and we would get:

[0, 0, 1, 1, 2, 4, 7, 13, 24, ...]
Well, you may have guessed it by now, but to be clear: you need to create a fibonacci function that given a signature array/list, returns the first n elements - signature included of the so seeded sequence.

Signature will always contain 3 numbers; n will always be a non-negative number; if n == 0, then return an empty array (except in C return NULL) and be ready for anything else which is not clearly specified ;)
*/

function tribonacci(signature, n) {
        let fibo = signature;

        for (let i = 3; i < n; i++) {
                fibo[i] = fibo[i - 1] + fibo[i - 2] + fibo[i - 3];
        }

        //handle cases where we want to return 0 numbers, with empty array, or fewer numbers than the signature
        if (n < 3) fibo = fibo.splice(0, n);

        return fibo;
}
