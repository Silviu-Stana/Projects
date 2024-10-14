import { Friend } from './Friend';

export function FriendList({ onSelect, selected, friends }) {
        return (
                <ul>
                        {friends.map((friend) => (
                                <Friend onSelect={onSelect} selected={selected} friend={friend} key={friend.id} />
                        ))}
                </ul>
        );
}
