export default function Stats({ items }) {
        if (!items.length)
                return (
                        <p className="stats">
                                <em>Start adding items to your list!</em>
                        </p>
                );

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
