import React, { useState } from 'react'

function ToDoList() {
        const [text, setText] = useState('')
        const [items, setItems] = useState([])

        var listItems = []

        function handleChange(event) {
                setText(event.target.value)
        }

        function handleClick() {
                setItems([...items, text])
                setText('')
        }

        return (
                <div className="container">
                        <div className="heading">
                                <h1>To-Do List</h1>
                        </div>
                        <div className="form">
                                <input onChange={handleChange} type="text" value={text} />
                                <button onClick={handleClick}>
                                        <span>Add</span>
                                </button>
                        </div>
                        <div>
                                <ul>
                                        {items.map((item) => (
                                                <li>{item}</li>
                                        ))}
                                </ul>
                        </div>
                </div>
        )
}

export default ToDoList
