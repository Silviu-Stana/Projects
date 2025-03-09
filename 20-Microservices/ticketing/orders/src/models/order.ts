import mongoose from 'mongoose';

interface OrderAttributes {
    userId: string;
    status: string;
    expiresAt: Date;
    ticket: TicketDoc;
}

interface OrderDoc extends mongoose.Document {
    userId: string;
    status: string;
    expiresAt: Date;
    ticket: TicketDoc;
}

interface OrderModel extends mongoose.Model<OrderDoc> {
    build(attrs: OrderAttributes): OrderDoc;
}

const orderSchema = new mongoose.Schema<OrderDoc, OrderModel>(
    {
        userId: { type: String, required: true },
        status: { type: String, required: true },
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
