import react from 'react'

var RandomImage = function () {
        return <img src={'https://picsum.photos/' + Math.floor(Math.random() * 200 + 1000)} style={{ padding: '2px' }}></img>
}

export default RandomImage
