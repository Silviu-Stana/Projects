import mongoose from 'mongoose';

//Required props to create user
interface UserAttributes {
    email: string;
    password: string;
}

const userSchema = new mongoose.Schema({
    email: {
        type: String,
        required: true,
    },
    password: {
        type: String,
        required: true,
    },
});

const User = mongoose.model('User', userSchema);

const buildUser = (attrs: UserAttributes) => {
    return new User(attrs);
};

export { User, buildUser };
