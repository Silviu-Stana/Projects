import { useState } from 'react';

export default function Challenge1() {
        return (
                <div className="Challenge1">
                        <Counter />
                </div>
        );
}

function Counter() {
        const [step, setStep] = useState(1);
        const [count, setCount] = useState(0);

        let today = new Date();

        //Some practice with setState callback functions! Incrementing the current state
        //(in a more proper way)
        return (
                <div>
                        <button onClick={() => setStep((s) => s - 1)}>-</button>
                        Step: {step}
                        <button onClick={() => setStep((s) => s + 1)}>+</button>
                        <br />
                        <button onClick={() => setCount((c) => c - 1 * step)}>-</button>
                        Count: {count}
                        <button onClick={() => setCount((c) => c + 1 * step)}>+</button>
                        <br />
                        <br />
                        30 days from today is {new Date(new Date().setDate(new Date().getDate() + count)).toDateString()}
                </div>
        );
}
