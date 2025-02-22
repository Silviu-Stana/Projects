const axios = require('axios');
const express = require('express');
const bodyParser = require('body-parser');

const app = express();
app.use(bodyParser.json());

app.post('/events', async (req, res) => {
    const { type, data } = req.body;

    if (type === 'CommentCreated') {
        const status = data.content.includes('orange') ? 'rejected' : 'approved';

        await axios.post('http://event-bus-srv:4005/events', {
            type: 'CommentModerated',
            data: { id: data.id, postId: data.postId, status, content: data.content },
        });
    }

    res.send({}); //if you dont send ANY response, the request is going to hang.
});

app.listen(4003, () => {
    console.log('Listen on 4003');
});
