import { useState } from 'react';
import { FormSplitBill } from './FormSplitBill';
import { FormAddFriend } from './FormAddFriend';
import { FriendList } from './FriendList';
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
