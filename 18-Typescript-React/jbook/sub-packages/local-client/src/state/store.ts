import { createStore, applyMiddleware } from 'redux';
import thunk from 'redux-thunk';
import reducers from './reducers';
import { persistMiddleware } from './middlewares/persist-middleware';

export const store = createStore(reducers, {}, applyMiddleware(thunk, persistMiddleware));

//HOW TO GET AN ID (for testing)
// const id = store.getState().cells.order[0];

console.log(store.getState());
