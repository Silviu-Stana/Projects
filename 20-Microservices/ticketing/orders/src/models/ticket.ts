import mongoose from 'mongoose';
import { Order, OrderStatus } from './order';

interface TicketAttributes {
    id?: string;
    title: string;
    price: number;
}

export interface TicketDoc extends mongoose.Document {
    title: string;
    price: number;
    isReserved(): Promise<boolean>;
}

interface TicketModel extends mongoose.Model<TicketDoc> {
    build(attrs: TicketAttributes): TicketDoc;
}

const ticketSchema = new mongoose.Schema<TicketDoc, TicketModel>(
    {
        title: { type: String, required: true },
        price: { type: Number, required: true, min: 0 },
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

ticketSchema.statics.build = (attrs: TicketAttributes) => {
    return new Ticket({
        _id: attrs.id,
        title: attrs.title,
        price: attrs.price,
    });
};

ticketSchema.methods.isReserved = async function () {
    // this = the ticket doc we just called 'isReserved()' on

    //if Status of our ticket is NOT "Cancelled", it means it is reserved.
    const existingOrder = await Order.findOne({
        ticket: this,
        status: {
            $in: [OrderStatus.Created, OrderStatus.AwaitingPayment, OrderStatus.Completed],
        },
    });

    return !!existingOrder; //converts "null" to boolean, with a value of "true", then back to "false"
};

const Ticket = mongoose.model<TicketDoc, TicketModel>('Ticket', ticketSchema);

export default Ticket;
