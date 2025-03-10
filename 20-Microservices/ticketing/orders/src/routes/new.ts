import { BadRequestError, NotFoundError, OrderStatus, requireAuth, validateRequest } from '@sealsdev/commonservice';
import express, { Request, Response } from 'express';
import { body } from 'express-validator';
import { Ticket } from '../models/ticket';
import { Order } from '../models/order';

const router = express.Router();

const EXPIRATION_WINDOW_SECONDS = 15 * 60;

router.post(
    '/api/orders',
    requireAuth,
    [
        body('ticketId').not().isEmpty().withMessage('ticketId must be provided'),
        body('ticketId').isMongoId().withMessage('Invalid MongoDB ObjectId'),
        // Alternative way of validating mongo id:
        //custom((input: string) => mongoose.Types.ObjectId.isValid(input))...
    ],
    validateRequest,
    async (req: Request, res: Response) => {
        const { ticketId } = req.body;

        //Find ticket user is trying to order in database
        const ticket = await Ticket.findById(ticketId);
        if (!ticket) throw new NotFoundError();

        //Make sure ticket not reserved
        const isReserved = await ticket.isReserved();
        if (isReserved) throw new BadRequestError('Ticket is already reserved.');

        //Calculate expiration date
        const expiration = new Date();
        expiration.setSeconds(expiration.getSeconds() + EXPIRATION_WINDOW_SECONDS);

        //Build the order and save to DB
        const order = Order.build({
            userId: req.currentUser!.id,
            status: OrderStatus.Created,
            expiresAt: expiration,
            ticket: ticket,
        });

        //order:created event

        res.status(201).send(order);
    }
);

export { router as newOrderRouter };
