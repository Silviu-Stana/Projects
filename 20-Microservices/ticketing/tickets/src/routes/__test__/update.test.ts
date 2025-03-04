import request from 'supertest';
import { app } from '../../app';
import mongoose from 'mongoose';

it('returns a 404 if id does not exist', async () => {
    const id = new mongoose.Types.ObjectId().toHexString();
    await request(app).put(`/api/tickets/${id}`).set('Cookie', global.signin()).send({ title: 'aowihdw', price: 20 }).expect(404);
});

it('returns a 401 if user not logged in', async () => {
    const id = new mongoose.Types.ObjectId().toHexString();
    //if we dont set a Cookie it means we are not logged in
    await request(app).put(`/api/tickets/${id}`).send({ title: 'aowihdw', price: 20 }).expect(401);
});

it('returns a 401 if user does not own ticket', async () => {});
it('returns a 400 if user provides invalid title or price', async () => {});
it('updates the ticket provided valid inputs', async () => {});
