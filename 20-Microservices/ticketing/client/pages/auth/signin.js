import { useState } from 'react';
import { useRequest } from '../../hooks/useRequest';
import { useRouter } from 'next/router';

const Signup = () => {
    const router = useRouter();
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const { doRequest, errors } = useRequest({
        url: '/api/users/signin',
        method: 'post',
        body: { email, password },
        onSuccess: () => router.push('/'),
    });

    const onSubmit = async (event) => {
        event.preventDefault();

        await doRequest();
    };

    return (
        <form onSubmit={onSubmit}>
            <h1>Signin</h1>
            <div className="form-group">
                <label>Email address</label>
                <input value={email} onChange={(e) => setEmail(e.target.value)} className="form-control" />
            </div>
            <div className="form-group">
                <label>Password</label>
                <input value={password} onChange={(e) => setPassword(e.target.value)} type="password" className="form-control" />
            </div>
            {errors}
            <button className="btn btn-primary">Signin</button>
        </form>
    );
};

export default Signup;
