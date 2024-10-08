import { useState } from 'react';

const initialItems = [
        { id: 1, description: 'Passports', quantity: 2, packed: false },
        { id: 2, description: 'Socks', quantity: 12, packed: true },
        { id: 3, description: 'Charger', quantity: 1, packed: false },
];

export default function App() {
        const [items, setItmes] = useState([...initialItems]);

        function handleAddItems(item) {
                setItmes((items) => [...items, item]);
        }

        return (
                <div className="app">
                        <Logo />
                        <Form onAddItems={handleAddItems} />
                        <PackingList items={items} />
                        <Stats />
                </div>
        );
}

function Logo() {
        return <h1>🌴Far Away💼</h1>;
}
function Form({ onAddItems }) {
        const [description, setDescription] = useState('');
        const [amount, setAmount] = useState(1);

        function handleSubmit(event) {
                event.preventDefault();
                console.log(event);

                if (!description) return;

                const newItem = { description, amount, packed: false, id: Date.now() };
                console.log(newItem);

                onAddItems(newItem);

                setDescription('');
                setAmount(1);
        }

        return (
                <form className="add-form" onSubmit={handleSubmit}>
                        <h3>What do you need for your 😍 trip?</h3>
                        <select value={amount} onChange={(e) => setAmount(Number(e.target.value))}>
                                {Array.from({ length: 20 }, (_, index) => index + 1).map((num) => (
                                        <option value={num} key={num}>
                                                {num}
                                        </option>
                                ))}
                        </select>
                        <input type="text" placeholder="Item..." value={description} onChange={(e) => setDescription(e.target.value)}></input>
                        <button>Add</button>
                </form>
        );
}
function PackingList({ items }) {
        return (
                <div className="list">
                        <ul>
                                {items.map((item) => (
                                        <Item item={item} key={item.id} />
                                ))}
                        </ul>
                </div>
        );
}

function Item({ item }) {
        return (
                <li>
                        <span style={item.packed ? { textDecoration: 'line-through' } : {}}>
                                {item.quantity} {item.description}
                        </span>
                        <button>❌</button>
                </li>
        );
}

function Stats() {
        return (
                <footer className="stats">
                        <em>💼You have X items on your list, and you already packed X (X%)</em>
                </footer>
        );
}
