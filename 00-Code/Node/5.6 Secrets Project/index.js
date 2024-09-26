import express from 'express'
import axios from 'axios'

const app = express();
const port = 3000;

app.use(express.static('public'));

app.get('/', async (req, res) =>{
        const randomSecret = await axios.get('https://secrets-api.appbrewery.com/random');
        
        try{
        res.render('index.ejs', {content: JSON.stringify(randomSecret.data)});
        }
        catch(error){
                console.log(error.response.data);
                res.status(500);       
        }
        
        
        // console.log(JSON.stringify(randomSecret.data));
        
})

app.listen(port, () =>{
        console.log(`Server started on port ${port}`);
})

