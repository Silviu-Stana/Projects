const express = require('express');
const { randomBytes } = require('crypto');
const bodyParser = require('body-parser');
const cors = require('cors');
const axios = require('axios');

const app = express();
app.use(bodyParser.json());
// app.use(bodyParser.urlencoded({ extended: true }));
app.use(cors());

const posts = {};

//Unused: this endpoint is just for testing
// app.get('/posts', (req, res) => {
//     res.send(posts);
// });

app.post('/posts/create', async (req, res) => {
    const id = randomBytes(4).toString('hex');
    const { title } = req.body;

    posts[id] = {
        id,
        title,
    };

    await axios.post('http://event-bus-srv:4005/events', {
        type: 'PostCreated',
        data: { id, title },
    });

    res.status(201).send(posts[id]);
});

app.post('/events', (req, res) => {
    console.log('Received event: ', req.body.type);
    res.send({});
});

app.listen(4000, () => {
    console.log('v55');
    console.log('Listen on 4000');
});
