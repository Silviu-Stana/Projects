import React, { JSX } from 'react';
import { createRoot } from 'react-dom/client';

interface AppProps {
      color?: string;
}

const App = (props: AppProps): JSX.Element => {
      return <div>{props.color}</div>;
};

const root = createRoot(document.querySelector('#root')!);
root.render(<App color="red" />);
