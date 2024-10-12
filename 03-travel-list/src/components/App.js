import { useState } from 'react';
import Logo from './Logo';
import Form from './Form';
import PackingList from './PackingList';
import Stats from './Stats';

const initialItems = [
        { id: 1, description: 'Passports', quantity: 2, packed: false },
        { id: 2, description: 'Socks', quantity: 12, packed: true },
        { id: 3, description: 'Charger', quantity: 1, packed: false },
];

export default function App() {
        const [items, setItems] = useState(initialItems);

        function handleAddItems(item) {
                setItems((items) => [...items, item]);
        }

        function handleDeleteItems(id) {
                setItems((items) => items.filter((item) => item.id !== id));
        }

        function handleClearList() {
                const confirmed = window.confirm('Are you sure you want to delete all items?');
                if (confirmed) setItems([]);
        }

        //This is how we update an object in an array (for a piece of state)
        function handleToggleItem(id) {
                setItems((items) => items.map((item) => (item.id === id ? { ...item, packed: !item.packed } : item)));
        }

        return (
                <div className="app">
                        <Logo />
                        <Form onAddItems={handleAddItems} />
                        <PackingList onDeleteItem={handleDeleteItems} onToggleItem={handleToggleItem} onClearList={handleClearList} items={items} />
                        <Stats items={items} />
                </div>
        );
}
