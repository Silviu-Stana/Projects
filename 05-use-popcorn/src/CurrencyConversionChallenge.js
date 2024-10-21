// `https://api.frankfurter.app/latest?amount=100&from=EUR&to=USD`

import { useEffect, useState } from 'react';

export default function App() {
        const [number, setNumber] = useState('');
        const [from, setFrom] = useState('USD');
        const [to, setTo] = useState('USD');
        const [result, setResult] = useState('');
        const [isLoading, setIsLoading] = useState(false);

        useEffect(
                function () {
                        async function fetchConversion() {
                                try {
                                        if (from !== to && number) {
                                                setIsLoading(true);
                                                const res = await fetch(`https://api.frankfurter.app/latest?amount=${number}&from=${from}&to=${to}`);
                                                const data = await res.json();

                                                console.log(data);
                                                setResult(data.rates[to]);
                                                setIsLoading(false);
                                        } else setResult('');
                                } catch (error) {
                                        console.log(error.message);
                                } finally {
                                }
                        }
                        fetchConversion();
                },
                [from, number, to]
        );

        return (
                <div>
                        <h2>Amount to convert:</h2>
                        <input type="text" onChange={(e) => setNumber(e.target.value)} value={number} />
                        <select onChange={(e) => setFrom(e.target.value)} value={from} disabled={isLoading}>
                                <option value="USD">USD</option>
                                <option value="EUR">EUR</option>
                                <option value="CAD">CAD</option>
                                <option value="INR">INR</option>
                        </select>
                        <select onChange={(e) => setTo(e.target.value)} value={to} disabled={isLoading}>
                                <option value="USD">USD</option>
                                <option value="EUR">EUR</option>
                                <option value="CAD">CAD</option>
                                <option value="INR">INR</option>
                        </select>
                        {/* <p>{result ? result : ""}</p> */}
                        <h2>{result ? result + to : ''}</h2>
                </div>
        );
}
