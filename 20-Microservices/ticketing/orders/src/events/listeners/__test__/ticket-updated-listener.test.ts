import mongoose from 'mongoose';
import Ticket from '../../../models/ticket';
import { natsWrapper } from '../../../nats-wrapper';
import { TicketUpdatedListener } from '../ticket-updated-listener';
import { TicketUpdatedEvent } from '@sealsdev/commonservice';
import { Message } from 'node-nats-streaming';

const setup = async () => {
    const listener = new TicketUpdatedListener(natsWrapper.client);
    //create ticket
    const ticket = await Ticket.build({ id: new mongoose.Types.ObjectId().toHexString(), title: 'concert', price: 20 });
    await ticket.save();

    //create fake Data object
    const data: TicketUpdatedEvent['data'] = {
        id: ticket.id,
        version: ticket.version + 1,
        title: 'new title',
        price: 999,
        userId: 'adwguoai',
    };

    //create fake Message object
    //@ts-ignore
    const msg: Message = {
        ack: jest.fn(),
    };

    ///TODO: why do we save all of these?
    return { msg, data, ticket, listener };
};

it('finds, updates, and saves a ticket', async () => {});

it('acks the message', async () => {});
