import react from 'react'
import reactDom from 'react-dom'
import './assets/style.css'
import App from './components/App'

var currentTime = new Date().getHours()
var h1Text = ''

const timeTextColor = {
        color: 'blue',
}

reactDom.render(
        <div>
                <App />
        </div>,
        document.getElementById('root')
)
