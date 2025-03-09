export const natsWrapper = {
    // an instance of a class is an object
    client: {
        publish: (subject: string, data: string, callback: () => void) => {
            callback();
        },
    },
};
