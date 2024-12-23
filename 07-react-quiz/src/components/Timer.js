import { useEffect } from 'react';
import { useQuiz } from '../contexts/QuizContext';

function Timer() {
        const { dispatch, secondsRemaining } = useQuiz();
        const mins = Math.floor(secondsRemaining / 60);
        const sec = secondsRemaining % 60;

        useEffect(
                function () {
                        const id = setInterval(function () {
                                dispatch({ type: 'tick' });
                        }, 1000);

                        //What a perfect use case for a cleanup function! (that runs on dismount)
                        return () => clearInterval(id);
                },
                [dispatch]
        );

        return (
                <div className="timer">
                        {mins < 10 ? '0' : ''}
                        {mins}:{sec < 10 ? '0' : ''}
                        {sec}
                </div>
        );
}

export default Timer;
