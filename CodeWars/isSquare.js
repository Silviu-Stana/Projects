/*
Given an integral number, determine if it's a square number:

In mathematics, a square number or perfect square is an integer that is the square of an integer; in other words, it is the product of some integer with itself.

The tests will always use some integral number, so don't worry about that in dynamic typed languages.
*/

var isSquare = function (n) {
        if (n < 0) return false;
        else if (n === 0) return true;
        else if (Number.isInteger(Math.sqrt(n))) return true;
        return false;
};

/*
Needle in a Haystack
*/
function findNeedle(haystack) {
        return (
                "found the needle at position " +
                haystack.findIndex((n) => n === "needle")
        );
}
