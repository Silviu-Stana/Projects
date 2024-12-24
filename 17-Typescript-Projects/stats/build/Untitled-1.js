"use strict";
class HoldAnything {
    add(a) {
        return a;
    }
}
const holdNumber = new HoldAnything();
holdNumber.data = 123;
const holdString = new HoldAnything();
holdString.data = 'Wow';
