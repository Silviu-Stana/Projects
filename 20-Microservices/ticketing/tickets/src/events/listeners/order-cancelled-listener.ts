import { Listener, Subjects } from '@sealsdev/commonservice';
import { OrderCancelledEvent } from '@sealsdev/commonservice';
import { queueGroupName } from './queue-group-name';
import { Message } from 'node-nats-streaming';
import Ticket from '../../models/ticket';
import { TicketUpdatedPublisher } from '../publishers/ticket-updated-publisher';

export class OrderCancelledListener extends Listener<OrderCancelledEvent> {
    readonly subject = Subjects.OrderCancelled;
    queueGroupName = queueGroupName;

    async onMessage(data: OrderCancelledEvent['data'], msg: Message) {
        //find ticket
        const ticket = await Ticket.findById(data.ticket.id);
        if (!ticket) throw new Error('Ticket not found');

        ticket.set({ orderId: undefined });
        await ticket.save();

        await new TicketUpdatedPublisher(this.client).publish({
            id: ticket.id,
            version: ticket.version,
            title: ticket.title,
            price: ticket.price,
            userId: ticket.userId,
            orderId: ticket.orderId,
        });

        msg.ack();
    }
}
