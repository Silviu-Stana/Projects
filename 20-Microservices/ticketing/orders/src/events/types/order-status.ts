export enum OrderStatus {
    //Order has been created, but ticket it is trying to order has NOT been reserved
    Create = 'created',
    //Ticket the order is trying to reserve has already been reserved,
    //or when the user cancelled the order
    //or order expires before payment
    Cancelled = 'cancelled',
    //Order successfully reserved the ticket
    AwaitingPayment = 'awaiting:payment',
    //Order reserved + Successful Payment
    Complete = 'complete',
}
