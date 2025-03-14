import { Listener, OrderStatus, Subjects } from '@sealsdev/commonservice';
import { ExpirationCompleteEvent } from '@sealsdev/commonservice';
import { queueGroupName } from './queue-group-name';
import { Message } from 'node-nats-streaming';
import { Order } from '../../models/order';

export class ExpirationCompleteListener extends Listener<ExpirationCompleteEvent> {
    readonly subject = Subjects.ExpirationComplete;
    queueGroupName = queueGroupName;

    async onMessage(data: ExpirationCompleteEvent['data'], msg: Message) {
        const order = await Order.findById(data.orderId);
        if (!order) throw new Error('Order not found');

        //no reset "ticket" property because we can keep for our user a history of products ordered
        order.set({ status: OrderStatus.Cancelled });
    }
}
