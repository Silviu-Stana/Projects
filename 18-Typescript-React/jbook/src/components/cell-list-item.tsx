import { Cell } from '../state';
import ActionBar from './action-bar';
import CodeCell from './code-cell';
import TextEditor from './text-editor';
import './cell-list-item.css';

interface CellListItemProps {
      cell: Cell;
}

const CellListItem: React.FC<CellListItemProps> = ({ cell }) => {
      let child: JSX.Element;
      if (cell.type === 'code')
            child = (
                  <>
                        <div className="action-bar-wrapper">
                              <ActionBar id={cell.id} />
                        </div>
                        <CodeCell cell={cell} />
                  </>
            );
      else
            child = (
                  <>
                        <div className="action-bar-wrapper">
                              <ActionBar id={cell.id} />
                        </div>
                        <TextEditor cell={cell} />
                  </>
            );

      return <div className="cell-list-item">{child}</div>;
};

export default CellListItem;
