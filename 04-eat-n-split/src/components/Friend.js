import { Button } from './Button';

export function Friend({ friend, onSelect, selected }) {
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
