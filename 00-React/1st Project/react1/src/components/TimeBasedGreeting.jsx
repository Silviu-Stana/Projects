import react from 'react'

function TimeBasedGreeting() {
        var currentTime = new Date().getHours()
        var h1Text = ''

        const timeTextColor = {
                color: 'blue',
        }

        if (currentTime < 12) {
                h1Text = 'Good Morning'
                timeTextColor.color = 'red'
        } else if (currentTime < 18) {
                h1Text = 'Good Afternoon'
                timeTextColor.color = 'green'
        } else if (currentTime < 24) {
                h1Text = 'Good Evening'
                timeTextColor.color = 'blue'
        }

        return <h1 style={timeTextColor}>{h1Text}</h1>
}

export default TimeBasedGreeting
