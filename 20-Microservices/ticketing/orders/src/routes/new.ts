import { requireAuth, validateRequest } from '@sealsdev/commonservice';
import express, { Request, Response } from 'express';
import { body } from 'express-validator';

const router = express.Router();

router.post(
    '/api/orders',
    requireAuth,
    [
        body('ticket').not().isEmpty().withMessage('ticketId must be provided'),
        body('productId').isMongoId().withMessage('Invalid MongoDB ObjectId'),
        // Alternative way of validating mongo id:
        //custom((input: string) => mongoose.Types.ObjectId.isValid(input))...
    ],
    validateRequest,
    async (req: Request, res: Response) => {
        res.send({}); //{ orderId: req.body.orderId }
    }
);

export { router as newOrderRouter };
