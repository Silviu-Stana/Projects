import { useState, useEffect } from 'react';

export function useLocalStorageState(initialState, key) {
        const [value, setValue] = useState(function () {
                //useState can accept a callback function as it's initial state
                const storedValue = localStorage.getItem(key);

                return storedValue ? JSON.parse(storedValue) : initialState;
        });

        useEffect(
                function () {
                        localStorage.setItem('watched', JSON.stringify(value));
                },
                [value, key]
        );

        return [value, setValue];
}
