import { useEffect } from 'react';

export function useKey(key, onKeyPress) {
        useEffect(
                function () {
                        function callback(e) {
                                if (e.code.toLowerCase() === key.toLowerCase()) {
                                        onKeyPress();
                                        //console.log('CLOSING')
                                }
                        }

                        document.addEventListener('keydown', callback);

                        //Make sure you delete that event listener, otherwise they keep stacking (being added)
                        return () => document.removeEventListener('keydown', callback);
                },
                [onKeyPress, key]
        );
}
