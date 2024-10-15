import './styles.css';
import { useState } from 'react';

const faqs = [
        {
                title: 'Where are these chairs assembled?',
                text: 'Lorem ipsum dolor sit amet consectetur, adipisicing elit. Accusantium, quaerat temporibus quas dolore provident nisi ut aliquid ratione beatae sequi aspernatur veniam repellendus.',
        },
        {
                title: 'How long do I have to return my chair?',
                text: 'Pariatur recusandae dignissimos fuga voluptas unde optio nesciunt commodi beatae, explicabo natus.',
        },
        {
                title: 'Do you ship to countries outside the EU?',
                text: 'Excepturi velit laborum, perspiciatis nemo perferendis reiciendis aliquam possimus dolor sed! Dolore laborum ducimus veritatis facere molestias!',
        },
];

export default function App() {
        return (
                <div>
                        <Accordion data={faqs} />
                </div>
        );
}

function Accordion({ data }) {
        const [currentOpen, setIsOpen] = useState(null);

        return (
                <ul className="accordion">
                        {data.map((item, i) => (
                                <li>
                                        <AccordionItem currentOpen={currentOpen} onOpen={setIsOpen} num={i} key={item.title} title={item.title}>
                                                {' '}
                                                {item.text}
                                        </AccordionItem>
                                </li>
                        ))}
                </ul>
        );
}

function AccordionItem({ num, title, currentOpen, onOpen, children }) {
        const isOpen = num === currentOpen;

        function handleToggle(id) {
                onOpen(isOpen ? null : num);
        }

        return (
                <div className={isOpen ? 'item open' : 'item'} onRate={() => handleToggle(num)}>
                        <p className="number">{num < 9 ? '0' + (num + 1) : num + 1}</p>
                        <p className="text">{title}</p>
                        <p className="icon">{isOpen ? '-' : '+'}</p>

                        {isOpen && <div className="content-box">{children}</div>}
                </div>
        );
}
