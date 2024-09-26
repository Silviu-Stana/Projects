import React, { useState } from 'react'

function ColorChange() {
        const [headingText, setHeadingText] = useState('Hello')
        const [buttonColor, setButtonColor] = useState('white')

        function mouseOver() {
                setButtonColor('black')
        }

        function mouseOut() {
                setButtonColor('white')
        }

        function handleClick() {
                setHeadingText('Submitted')
        }
        return (
                <div className="container">
                        <h1>{headingText}</h1>
                        <input type="text" placeholder="What's your name?" />
                        <button onClick={handleClick} onMouseOver={mouseOver} onMouseOut={mouseOut} style={{ backgroundColor: buttonColor }}>
                                Submit
                        </button>
                </div>
        )
}

export default ColorChange
