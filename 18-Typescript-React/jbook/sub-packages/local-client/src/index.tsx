import 'bulmaswatch/superhero/bulmaswatch.min.css';
import '@fortawesome/fontawesome-free/css/all.min.css';
import { Provider } from 'react-redux';
import { store } from './state';
import CellList from './components/cell-list';
import { createRoot } from 'react-dom/client';

const App = () => {
      return (
            <Provider store={store}>
                  <div>
                        <CellList />
                  </div>
            </Provider>
      );
};

const container = document.querySelector('#root');
const root = createRoot(container!);
root.render(<App />);
