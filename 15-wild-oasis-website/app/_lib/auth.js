import NextAuth from 'next-auth';
import Google from 'next-auth/providers/google';
import { createGuest, getGuest } from './data-service';

export const authConfig = {
      providers: [
            Google({
                  clientId: process.env.AUTH_GOOGLE_ID,
                  clientSecret: process.env.AUTH_GOOGLE_SECRET,
            }),
      ],
      callbacks: {
            authorized({ auth, request }) {
                  return !!auth?.user; //!! convert to boolean. if there's a sure, /account visit is authorized
            },
            async signIn({ user, account, profile }) {
                  try {
                        const existingGuest = await getGuest(user.email);

                        //if it's "null"
                        //we use "await" otherwise, the user won't exist when it immediately
                        //runs in the next "session" callback
                        if (!existingGuest) await createGuest({ email: user.email, fullName: user.name });

                        return true;
                  } catch {
                        return false;
                  }
            },
            //"session" callback runs after "signIn"
            //this callback helps us find the "id" the user has in the database
            async session({ session, user }) {
                  const guest = await getGuest(session.user.email);
                  session.user.guestId = guest.id;
                  return session;
            },
      },
      pages: {
            signIn: '/login',
      },
};

export const {
      auth,
      signIn,
      signOut,
      handlers: { GET, POST },
} = NextAuth(authConfig);
