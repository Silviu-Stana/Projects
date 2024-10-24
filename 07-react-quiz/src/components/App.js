import Header from './Header';
import Main from './Main';
import Loader from './Loader';
import Error from './Error';
import Question from './Question';
import NextQuestion from './NextQuestion';
import { useEffect, useReducer } from 'react';
import StartScreen from './StartScreen';

const initialState = {
        questions: [],
        status: 'loading', //loading, error, ready, active, finished
        index: 0,
        answer: null,
        points: 0,
};

function reducer(state, action) {
        switch (action.type) {
                case 'dataReceived':
                        return { ...state, questions: action.payload, status: 'ready' };
                case 'dataFailed':
                        return { ...state, status: 'error' };
                case 'start':
                        return { ...state, status: 'active', index: 0 };
                case 'newAnswer':
                        const question = state.questions.at(state.index);
                        return {
                                ...state,
                                answer: action.payload,
                                points: action.payload === question.correctOption ? state.points + question.points : state.points,
                        };
                case 'nextQuestion':
                        return { ...state, index: state.index + 1, answer: null };

                default:
                        throw new Error('Action unknown');
        }
}

export default function App() {
        const [{ questions, status, index, answer }, dispatch] = useReducer(reducer, initialState);
        let numQuestions = questions.length;

        useEffect(function () {
                fetch('http://localhost:8000/questions')
                        .then((res) => res.json())
                        .then((data) => dispatch({ type: 'dataReceived', payload: data }))
                        .catch((err) => dispatch({ type: 'dataFailed' }));
        }, []);

        return (
                <div className="app">
                        <Header />

                        <Main>
                                {status === 'loading' && <Loader />}
                                {status === 'error' && <Error />}
                                {status === 'ready' && <StartScreen numQuestions={numQuestions} dispatch={dispatch} />}
                                {status === 'active' && (
                                        <>
                                                <Question question={questions[index]} dispatch={dispatch} answer={answer} />
                                                <NextQuestion dispatch={dispatch} answer={answer} />
                                        </>
                                )}
                        </Main>
                </div>
        );
}
