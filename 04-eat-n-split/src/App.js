import { useState } from 'react';
const initialFriends = [
        {
                id: 118836,
                name: 'Clark',
                image: 'https://i.pravatar.cc/48?u=118836',
                balance: -7,
        },
        {
                id: 933372,
                name: 'Sarah',
                image: 'https://i.pravatar.cc/48?u=933372',
                balance: 20,
        },
        {
                id: 499476,
                name: 'Anthony',
                image: 'https://i.pravatar.cc/48?u=499476',
                balance: 0,
        },
];

export default function App() {
        const [selected, setSelected] = useState(null);
        const [friendsList, setFriendsList] = useState(initialFriends);

        let currentFriend = friendsList.filter((f) => f.id === selected);

        function handleSplitBill(value) {
                setFriendsList((friends) => friends.map((friend) => (friend.id === selected ? { ...friend, balance: friend.balance + value } : friend)));
                setSelected(null);
        }

        return (
                <div className="app">
                        <div className="sidebar">
                                <FriendList friends={friendsList} selected={selected} onSelect={setSelected} />
                                <FormAddFriend friends={friendsList} onAddFriend={setFriendsList} />
                        </div>
                        {selected && <FormSplitBill currentFriend={currentFriend} friends={friendsList} selected={selected} onSplitBill={handleSplitBill} />}
                </div>
        );
}

function FriendList({ onSelect, selected, friends }) {
        return (
                <ul>
                        {friends.map((friend) => (
                                <Friend onSelect={onSelect} selected={selected} friend={friend} key={friend.id} />
                        ))}
                </ul>
        );
}

function Friend({ friend, onSelect, selected }) {
        function handleSelect() {
                if (selected === friend.id) onSelect(null);
                else onSelect(friend.id);
        }

        return (
                <li>
                        <img src={friend.image} alt={friend.name} />
                        <h3>{friend.name}</h3>
                        {friend.balance < 0 && (
                                <p className="red">
                                        You owe {friend.name} {friend.balance}$
                                </p>
                        )}
                        {friend.balance === 0 && <p></p>}
                        {friend.balance > 0 && (
                                <p className="green">
                                        {' '}
                                        {friend.name} owes you {friend.balance}$
                                </p>
                        )}

                        <Button onClick={handleSelect}>{selected === friend.id ? 'Close' : 'Select'}</Button>
                </li>
        );
}

function Button({ children, onClick }) {
        return (
                <button onClick={onClick} className="button">
                        {children}
                </button>
        );
}

function FormAddFriend({ friends, onAddFriend }) {
        const [visible, setIsVisible] = useState(false);
        const [newFriendName, setNewFriendName] = useState('');
        const [imageUrl, setImageUrl] = useState('https://i.pravatar.cc/48');

        if (!visible) return <Button onClick={() => setIsVisible(!visible)}>Add Friend</Button>;

        function handleAddFriend(event) {
                event.preventDefault();
                if (!newFriendName || !imageUrl) return;

                onAddFriend([...friends, { name: newFriendName, id: crypto.randomUUID(), balance: 0, image: imageUrl }]);
                setNewFriendName('');
                setIsVisible(!visible);
        }

        if (visible)
                return (
                        <>
                                <form className="form-add-friend">
                                        <label>👨Friend name</label>
                                        <input type="text" onChange={(event) => setNewFriendName(event.target.value)} value={newFriendName}></input>
                                        <label>📷Image url</label>
                                        <input type="text" onChange={(event) => setImageUrl(event.target.value)} value={imageUrl}></input>
                                        <Button onClick={handleAddFriend}>Add Friend</Button>
                                </form>
                                <Button onClick={() => setIsVisible(!visible)}>Close</Button>
                        </>
                );
}

function FormSplitBill({ currentFriend, friends, onSplitBill, selected }) {
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
