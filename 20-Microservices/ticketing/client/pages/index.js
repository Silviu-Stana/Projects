import buildClient from '../api/buildClient';

//Runs on client
const LandingPage = ({ currentUser }) => {
    console.log(currentUser);
    return currentUser ? <h1>You are signed in</h1> : <h1>You are NOT signed in</h1>;
};

//This runs on the server
LandingPage.getInitialProps = async (context) => {
    const client = buildClient(context);
    const { data } = await client.get('/api/users/currentuser');
    return data;
};

export default LandingPage;
