function validatePIN(pin) {
        if (isNaN(parseInt(pin))) return false

        return pin.length === 4 || pin.length === 6
}

console.log(validatePIN('a234'))
