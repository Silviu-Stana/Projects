import { useState } from 'react';

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

        //This is how we update an object in an array (for a piece of state)
        function handleToggleItem(id) {
                setItems((items) => items.map((item) => (item.id === id ? { ...item, packed: !item.packed } : item)));
        }

        return (
                <div className="app">
                        <Logo />
                        <Form onAddItems={handleAddItems} />
                        <PackingList onDeleteItem={handleDeleteItems} onToggleItem={handleToggleItem} items={items} />
                        <Stats items={items} />
                </div>
        );
}

function Logo() {
        return <h1>🌴Far Away💼</h1>;
}
function Form({ onAddItems }) {
        const [description, setDescription] = useState('');
        const [quantity, setQuantity] = useState(1);

        function handleSubmit(event) {
                event.preventDefault();
                console.log(event);

                if (!description) return;

                const newItem = { description, quantity: quantity, packed: false, id: Date.now() };
                console.log(newItem);

                onAddItems(newItem);

                setDescription('');
                setQuantity(1);
        }

        return (
                <form className="add-form" onSubmit={handleSubmit}>
                        <h3>What do you need for your 😍 trip?</h3>
                        <select value={quantity} onChange={(e) => setQuantity(Number(e.target.value))}>
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
function PackingList({ items, onDeleteItem, onToggleItem }) {
        return (
                <div className="list">
                        <ul>
                                {items.map((item) => (
                                        <Item onDeleteItem={onDeleteItem} onToggleItem={onToggleItem} item={item} key={item.id} />
                                ))}
                        </ul>
                </div>
        );
}

function Item({ item, onDeleteItem, onToggleItem }) {
        return (
                <li>
                        <input
                                type="checkbox"
                                checked={item.packed}
                                onChange={() => {
                                        onToggleItem(item.id);
                                }}
                        />
                        <span style={item.packed ? { textDecoration: 'line-through' } : {}}>
                                {item.quantity} {item.description}
                        </span>
                        <button onClick={() => onDeleteItem(item.id)}>❌</button>
                </li>
        );
}

function Stats({ items }) {
        const numItems = items.reduce((acc, cur) => (acc += cur.quantity), 0);
        const numPackedItems = items.reduce((acc, cur) => acc + (cur.packed ? cur.quantity : 0), 0);
        const percentage = ((numPackedItems / numItems) * 100).toFixed(2);

        return (
                <footer className="stats">
                        <em>
                                (
                                {Number(percentage) === 100
                                        ? '✅You got everything! Ready to go!!✅'
                                        : `💼You have ${numItems} items on your list, and you already packed ${numPackedItems} (${percentage} %)`}
                                )
                        </em>
                </footer>
        );
}
