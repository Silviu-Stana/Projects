import { Fragment } from 'react';
import { useTypedSelector } from '../hooks/use-typed-selectors';
import AddCell from './add-cell';
import CellListItem from './cell-list-item';

const CellList: React.FC = () => {
      const cells = useTypedSelector(({ cells: { order, data } }) => {
            return order.map((id) => {
                  return data[id];
            });
      });

      const renderedCells = cells.map((cell) => (
            <Fragment key={cell.id}>
                  <CellListItem cell={cell} />
                  <AddCell previousCellId={cell.id} />
            </Fragment>
      ));

      return (
            <div>
                  <AddCell forceVisible={cells.length === 0} previousCellId={null} />
                  {renderedCells}
            </div>
      );
};

export default CellList;
