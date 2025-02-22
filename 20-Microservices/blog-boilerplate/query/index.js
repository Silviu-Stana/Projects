const express = require('express');
const bodyParser = require('body-parser');
const cors = require('cors');
const axios = require('axios');

const app = express();
app.use(bodyParser.json());
app.use(cors());

const posts = {};

app.get('/posts', (req, res) => {
    res.send(posts);
});

const handleEvent = (type, data) => {
    if (type === 'PostCreated') {
        const { id, title } = data;
        posts[id] = { id, title, comments: [] };
    }

    if (type === 'CommentCreated') {
        const { id, content, postId, status } = data;
        const post = posts[postId];
        post.comments.push({ id, content, status });
    }

    if (type === 'CommentUpdated') {
        const { id, content, postId, status } = data;
        const post = posts[postId];
        const comment = post.comments.find((c) => c.id === id);
        comment.content = content;
        comment.status = status;
    }
};

app.post('/events', (req, res) => {
    const { type, data } = req.body;

    handleEvent(type, data);

    res.send({}); //we still need to send back a response at least to let them know we got an event and processed it
});

app.listen(4002, async () => {
    console.log('Listen on 4002');
    try {
        const res = await axios.get('http://event-bus-srv:4005/events');

        for (let event of res.data) {
            console.log('Received event: ', event.type);
            handleEvent(event.type, event.data);
        }
    } catch (err) {
        console.log(err.message);
    }
});
