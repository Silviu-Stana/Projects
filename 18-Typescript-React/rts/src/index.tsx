import React from 'react';
import { createRoot } from 'react-dom/client';
import Parent from './props/Parent';

const App = () => {
      return <Parent />;
};

const container = document.querySelector('#root');
const root = createRoot(container!);
root.render(<App />);
