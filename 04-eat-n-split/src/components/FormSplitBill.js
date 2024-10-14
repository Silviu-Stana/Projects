import { useState } from 'react';
import { Button } from './Button';

export function FormSplitBill({ currentFriend, friends, onSplitBill, selected }) {
        const [bill, setBill] = useState('');
        const [myPart, setMyPart] = useState('');
        const paidByFriend = bill ? bill - myPart : '';
        const [whoPays, setWhoPays] = useState('me');

        function handleSplitBill(event) {
                event.preventDefault();
                if (bill === '' || myPart === '') return;

                onSplitBill(whoPays === 'me' ? paidByFriend : -myPart);
        }

        return (
                <form onSubmit={handleSplitBill} className="form-split-bill">
                        <h2>Split a bill with {currentFriend[0].name}</h2>
                        <label>💰TOTAL:</label>
                        <input type="text" onChange={(event) => setBill(Number(event.target.value))} value={bill}></input>

                        <label>💰Your expense:</label>
                        <input type="text" onChange={(event) => setMyPart(Number(event.target.value))} value={myPart}></input>

                        <label>💰{currentFriend[0].name}'s expense:</label>
                        <input type="text" disabled value={paidByFriend}></input>

                        <label>🤑Who is paying the bill?</label>
                        <select type="text" value={whoPays} onChange={(e) => setWhoPays(e.target.value)}>
                                <option value="me">Me</option>
                                <option value="friend">{currentFriend[0].name}</option>
                        </select>

                        <Button>Split Bill</Button>
                </form>
        );
}
