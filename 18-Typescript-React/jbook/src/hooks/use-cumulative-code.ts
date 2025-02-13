import { useTypedSelector } from './use-typed-selector';

export const useCumulativeCode = (cellId: string) => {
      return useTypedSelector((state) => {
            const { data, order } = state.cells;
            const orderedCells = order.map((id) => data[id]);

            const showFunc = `
                  import _React from 'react';
                  import _ReactDOM from 'react-dom/client';
                  
                  var show = (value) => {
                        const rootElement = document.querySelector('#root');
                        if (!rootElement) return;
                        
                        if (typeof value === 'object') {
                              if (value.$$typeof && value.props) {
                                    const root = _ReactDOM.createRoot(rootElement);  // React 18+
                                    root.render(value);
                              } else {
                                    rootElement.innerHTML = JSON.stringify(value);
                              }
                        } else {
                              rootElement.innerHTML = value;
                        }
                  };
                  `;

            const showFuncNoop = 'var show = () => {}';

            const cumulativeCode = [];
            for (let c of orderedCells) {
                  if (c.type === 'code') {
                        if (c.id === cellId) cumulativeCode.push(showFunc);
                        else cumulativeCode.push(showFuncNoop);

                        cumulativeCode.push(c.content);
                  }
                  if (c.id === cellId) {
                        break;
                  }
            }
            return cumulativeCode;
      }).join('\n');
};
