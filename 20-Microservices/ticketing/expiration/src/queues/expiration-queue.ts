import Queue from 'bull';

interface Payload {
    orderId: string;
}

const expirationQueue = new Queue<Payload>('order:expiration', {
    redis: {
        host: process.env.REDIS_HOST,
    },
});

//called everytime a job is placed in the queue
expirationQueue.process(async (job) => {
    console.log(
        'I want to pubish an expiration:complete event for orderId',
        job.data.orderId
    );
});

export { expirationQueue };
