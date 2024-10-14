import { useState } from 'react';
import { Button } from './Button';

export function FormAddFriend({ friends, onAddFriend }) {
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
