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
                        <span>Step: {step}</span>
                        <button onClick={() => setStep((s) => s + 1)}>+</button>
                        <br />

                        <button onClick={() => setCount((c) => c - 1 * step)}>-</button>
                        <span>Count: {count}</span>
                        <button onClick={() => setCount((c) => c + 1 * step)}>+</button>

                        <p>
                                {count === 0 ? 'Today is ' : count > 0 ? `${count} days from today is ` : `${Math.abs(count)} days ago was `}{' '}
                                {new Date(new Date().setDate(new Date().getDate() + count)).toDateString()}
                        </p>
                </div>
        );
}
