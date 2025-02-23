export abstract class CustomError extends Error {
    abstract statusCode: number;

    constructor(message: string) {
        super(message); //the supper is just for Console logging purposes

        //Only for extending build in class
        Object.setPrototypeOf(this, CustomError.prototype);
    }

    abstract serializeErrors(): { message: string; field?: string }[];
}
