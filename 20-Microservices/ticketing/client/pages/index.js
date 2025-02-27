import buildClient from '../api/buildClient';

//Runs on client
const LandingPage = ({ currentUser }) => {
    console.log(currentUser);
    return <h1>Landing Page</h1>;
};

//This runs on the server
LandingPage.getInitialProps = async (context) => {
    const client = buildClient(context);
    const { data } = await client.get('/api/users/currentuser');
    return data;
};

export default LandingPage;
