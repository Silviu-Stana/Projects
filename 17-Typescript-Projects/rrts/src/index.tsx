import React from 'react';
import { createRoot } from 'react-dom/client';
import { Provider } from 'react-redux';
import { thunk } from 'redux-thunk'; // Corrected import statement
import { App } from './components/App';
import { reducers } from './reducers';
import { configureStore } from '@reduxjs/toolkit';

const store = configureStore({
      reducer: reducers,
      middleware: (getDefaultMiddleware) => getDefaultMiddleware().concat(thunk),
});

const root = createRoot(document.querySelector('#root')!);
root.render(
      <Provider store={store}>
            <App />
      </Provider>
);
