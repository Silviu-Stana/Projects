import { useState } from 'react';
import './styles.css';

export default function TipCalculator() {
        const [bill, setBill] = useState('');
        const [percentage1, setPercentage1] = useState(0);
        const [percentage2, setPercentage2] = useState(0);

        return (
                <div>
                        <BillInput bill={bill} onSetBill={setBill} />
                        <SelectPercentage onSetPercentage={setPercentage1}>How did you like the service?</SelectPercentage>
                        <SelectPercentage onSetPercentage={setPercentage2}>How did your friend like the service?</SelectPercentage>

                        {bill > 0 && (
                                <>
                                        <Output bill={bill} percentage1={percentage1} percentage2={percentage2} />
                                        <Reset onSetBill={setBill} bill={bill} />
                                </>
                        )}
                </div>
        );
}

function BillInput({ onSetBill, bill }) {
        function handleBill(event) {
                const value = event.target.value;
                // Only allow numbers and decimal point
                if (/^\d*\.?\d*$/.test(value)) {
                        onSetBill(value);
                }
        }

        return (
                <div>
                        <label>How much was the bill?</label>
                        <input type="text" onChange={handleBill} value={bill} />
                </div>
        );
}

function SelectPercentage({ onSetPercentage, children }) {
        return (
                <div>
                        <label>{children}</label>
                        <select onChange={(event) => onSetPercentage(Number(event.target.value))} type="select">
                                <option value="0">Dissatisfied (0%)</option>
                                <option value="5">It was okay (5%)</option>
                                <option value="10">It was good (10%)</option>
                                <option value="20">Absolutely amazing (20%)</option>
                        </select>
                </div>
        );
}

function Output({ bill, percentage1, percentage2 }) {
        let p1 = percentage1 / 100;
        let p2 = percentage2 / 100;

        let total = Number(bill) + Number((bill * p1) / 2) + Number((bill * p2) / 2);

        return (
                <h3>
                        You pay ${total} (${bill} + ${total - bill})
                </h3>
        );
}

function Reset({ onSetBill, bill }) {
        return bill !== '' && <button onClick={() => onSetBill('')}>Reset</button>;
}
