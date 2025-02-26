import mongoose from 'mongoose';
import { app } from './app';

const start = async () => {
    //Typeguard for typescript to know: the environment variable is NOT undefined
    if (!process.env.JWT_KEY) throw new Error('JWT_KEY must be defined');

    try {
        await mongoose.connect('mongodb://auth-mongo-srv:27017/auth');
        console.log('Connected to MongoDB');
    } catch (err) {
        console.error(err);
    }

    app.listen(3000, () => {
        console.log('Listen on 3000!!!');
    });
};

start();
