#!/usr/bin/env node
import express from 'express';

const app = express();

app.get('/', (req, res) => {
      res.send('hi');
});

app.listen(3005, () => {
      console.log('listen on 3005');
});
