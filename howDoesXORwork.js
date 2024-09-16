//It uses (power of 2) number to flip bit the bit from 0th to 4th

// the ^= compares the mask bit by bit with the shift operation 1<<0 (which is equal to 00001, or shifting 0 bits to the left)
//every bit that is DIFFERENT from the mask is set to 1
//every bit that is the SAME as the mask is set to 0

let mask = 0
mask ^= 1 << 0
//When converted to decimal, it seems  to add 2^0 to the mask. (where 0 is the number of shifts to the left we do before we flip a bit)

console.log(mask)
mask ^= 1 << 1 //mask+= 2^1

console.log(mask)
mask ^= 1 << 2 //mask+= 2^2

//And if you flip that bit back, it subtracts 2^2 from the mask

console.log(mask)
mask ^= 1 << 3
console.log(mask)
mask ^= 1 << 4
console.log(mask)
