import react from 'react'
import reactDom from 'react-dom'
import '../public/style.css'

let name = 'Seal'
let currentYear = new Date().getFullYear()

reactDom.render(
        <div>
                <p>Created by {name}</p>
                <p>Copyright {currentYear}</p>
        </div>,
        document.getElementById('root')
)
