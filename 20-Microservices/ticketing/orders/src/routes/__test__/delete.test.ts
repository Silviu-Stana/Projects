import request from 'supertest';
import { app } from '../../app';
import { Ticket } from '../../models/ticket';
import { Order, OrderStatus } from '../../models/order';

it('marks an order as cancelled', async () => {
    //Create ticket
    const ticket = Ticket.build({
        title: 'concert',
        price: 20,
    });
    await ticket.save();

    const user = global.signin();

    //Create order
    const { body: order } = await request(app).post('/api/orders').set('Cookie', user).send({ ticketId: ticket.id }).expect(201);

    //Cancel order
    await request(app).delete(`/api/orders/${order.id}`).set('Cookie', user).send().expect(204);

    const updatedOrder = await Order.findById(order.id);

    //Make sure it updated to "cancelled"
    expect(updatedOrder!.status).toEqual(OrderStatus.Cancelled);
});

it.todo('emits an order cancelled event');
