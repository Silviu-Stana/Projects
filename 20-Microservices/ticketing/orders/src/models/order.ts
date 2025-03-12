import { OrderStatus } from '@sealsdev/commonservice';
export { OrderStatus };
import mongoose from 'mongoose';
import { TicketDoc } from './ticket';

interface OrderAttributes {
    userId: string;
    status: OrderStatus;
    expiresAt: Date;
    ticket: TicketDoc;
}

interface OrderDoc extends mongoose.Document {
    userId: string;
    status: OrderStatus;
    expiresAt: Date;
    ticket: TicketDoc;
    version: number;
}

interface OrderModel extends mongoose.Model<OrderDoc> {
    build(attrs: OrderAttributes): OrderDoc;
}

const orderSchema = new mongoose.Schema<OrderDoc, OrderModel>(
    {
        userId: { type: String, required: true },
        status: { type: String, required: true, enum: Object.values(OrderStatus), default: OrderStatus.Created },
        expiresAt: { type: mongoose.Schema.Types.Date },
        ticket: { type: mongoose.Schema.ObjectId, ref: 'Ticket' },
    },
    {
        toJSON: {
            transform(doc, ret) {
                ret.id = ret._id;
                delete ret._id;
            },
        },
    }
);

orderSchema.statics.build = (attrs: OrderAttributes) => {
    return new Order(attrs);
};

const Order = mongoose.model<OrderDoc, OrderModel>('Order', orderSchema);

export { Order };
