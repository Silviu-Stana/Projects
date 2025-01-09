import React from 'react';
import { createRoot } from 'react-dom/client';
import UserSearch from './refs/UserSearch';

const App = () => {
      return (
            <div>
                  <UserSearch />
            </div>
      );
};

const container = document.querySelector('#root');
const root = createRoot(container!);
root.render(<App />);
