import { Fragment, useEffect } from 'react';
import { useTypedSelector } from '../hooks/use-typed-selector';
import AddCell from './add-cell';
import CellListItem from './cell-list-item';
import './cell-list.css';
import { fetchCells, saveCells } from '../state/action-creators';

const CellList: React.FC = () => {
      const cells = useTypedSelector(({ cells: { order, data } }) => {
            return order.map((id) => {
                  return data[id];
            });
      });

      useEffect(() => {
            fetchCells();
      }, []);

      useEffect(() => {
            saveCells();
      }, []);

      const renderedCells = cells.map((cell) => (
            <Fragment key={cell.id}>
                  <CellListItem cell={cell} />
                  <AddCell previousCellId={cell.id} />
            </Fragment>
      ));

      return (
            <div className="cell-list">
                  <AddCell forceVisible={cells.length === 0} previousCellId={null} />
                  {renderedCells}
            </div>
      );
};

export default CellList;
