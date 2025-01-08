import React from 'react';
import { createRoot } from 'react-dom/client';
import EventComponent from './events/EventComponent';

const App = () => {
      return (
            <div>
                  <EventComponent />
            </div>
      );
};

const container = document.querySelector('#root');
const root = createRoot(container!);
root.render(<App />);
