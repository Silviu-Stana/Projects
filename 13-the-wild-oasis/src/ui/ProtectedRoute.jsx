import styled from 'styled-components';
import { useUser } from '../features/authentication/useUser';
import Spinner from './Spinner';
import { useNavigate } from 'react-router-dom';
import { useEffect } from 'react';

const FullPage = styled.div`
      height: 100vh;
      background-color: var() (--color-grey-50);
      display: flex;
      align-items: center;
      justify-content: center;
`;

function ProtectedRoute({ children }) {
      const navigate = useNavigate();

      //1 load authenticated user
      const { isLoading, isAuthenticated } = useUser();

      //2 if no auth user, redirect to /login page
      useEffect(
            function () {
                  if (!isAuthenticated && !isLoading) navigate('/login');
            },
            [isAuthenticated, navigate, isLoading]
      );

      //3 show spinner
      if (isLoading)
            return (
                  <FullPage>
                        <Spinner />
                  </FullPage>
            );

      //4 if there is user, render app
      if (isAuthenticated) return children;
}

export default ProtectedRoute;
