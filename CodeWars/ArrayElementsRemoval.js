/*
If a value is present in b, all of its occurrences must be removed from the other:
arrayDiff([1,2,2,2,3],[2]) == [1,3]
*/

function arrayDiff(a, b) {
        for (let i = 0; i < b.length; i++) {
                a = a.filter((num) => num != b[i]);
        }

        return a;
}
