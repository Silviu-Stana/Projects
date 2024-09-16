function digitize(n) {
        n = n.toString();
        console.log(n);

        n = n.split("");
        console.log(n);

        n = n.reverse();
        console.log(n);

        return n;
}

//Simplified way.
function digitize(n) {
        return n.toString().split("").reverse().map(Number);
}

console.log(digitize(13579));
