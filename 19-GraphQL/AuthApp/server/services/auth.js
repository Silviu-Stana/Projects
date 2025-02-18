const mongoose = require('mongoose');
const passport = require('passport');
const LocalStrategy = require('passport-local').Strategy;

const User = mongoose.model('user');

// SerializeUser is used to provide some id token that can be saved in the users session.
passport.serializeUser((user, done) => {
    done(null, user.id);
});

//Given only a user's ID, we must return the user object.  This object is placed on 'req.user'.
passport.deserializeUser((id, done) => {
    User.findById(id, (err, user) => {
        done(err, user);
    });
});

// Login strategy: How to auth a user using a locally saved email and password combination.
// 2 failure points here: email might not exist in our DB or password might not match
// In both cases, we call the 'done' callback, including a string that messages why auth process failed.
// This string is provided back to the GraphQL client.
passport.use(
    new LocalStrategy({ usernameField: 'email' }, (email, password, done) => {
        User.findOne({ email: email.toLowerCase() }, (err, user) => {
            if (err) {
                return done(err);
            }
            if (!user) {
                return done(null, false, 'Invalid Credentials');
            }
            user.comparePassword(password, (err, isMatch) => {
                if (err) {
                    return done(err);
                }
                if (isMatch) {
                    return done(null, user);
                }
                return done(null, false, 'Invalid credentials.');
            });
        });
    })
);

// Create new account. Does user already exists? If not, After the user is created, it is
// provided to the 'req.logIn' function. (a part of Passport JS)
// Notice the Promise created in the second 'then' statement.  This is done
// because Passport only supports callbacks, while GraphQL only supports promises
// for async code!  Awkward!
function signup({ email, password, req }) {
    const user = new User({ email, password });
    if (!email || !password) {
        throw new Error('You must provide an email and password.');
    }

    return User.findOne({ email })
        .then((existingUser) => {
            if (existingUser) {
                throw new Error('Email in use');
            }
            return user.save();
        })
        .then((user) => {
            return new Promise((resolve, reject) => {
                req.logIn(user, (err) => {
                    if (err) {
                        reject(err);
                    }
                    resolve(user);
                });
            });
        });
}

// Log in:  invoke the 'local-strategy' defined above in this
// 'passport.authenticate' func returns a func, as its indended to be used as a Express middleware
// A compatibility layer to make it work nicely with GraphQL,
//(GraphQL always expects to see a promise for async code)
function login({ email, password, req }) {
    return new Promise((resolve, reject) => {
        passport.authenticate('local', (err, user) => {
            if (!user) {
                reject('Invalid credentials.');
            }

            req.login(user, () => resolve(user));
        })({ body: { email, password } });
    });
}

module.exports = { signup, login };
