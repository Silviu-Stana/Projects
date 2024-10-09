import express from 'express'
const app = express();
const port = 3000;


app.get('/', (req, res)=>{
        res.send('wow!');
})

app.get('/contact', (req, res)=>{
        res.send('contact!');
})

app.get('/about', (req, res)=>{
        res.send('about!');
})


app.listen(port, ()=>{
        console.log(`Server running on port ${port}`);
})
