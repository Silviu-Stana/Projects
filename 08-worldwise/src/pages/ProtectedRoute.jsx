import { useNavigate } from 'react-router-dom';
import { useAuth } from '../contexts/FakeAuthContext';
import { useEffect } from 'react';

function ProtectedRoute({ children }) {
        const { isLoggedIn } = useAuth();
        const navigate = useNavigate();

        useEffect(
                function () {
                        if (isLoggedIn === false) navigate('/');
                },
                [isLoggedIn, navigate]
        );

        return isLoggedIn ? children : null;
}

export default ProtectedRoute;
