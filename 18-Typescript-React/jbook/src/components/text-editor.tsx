import MDEditor from '@uiw/react-md-editor';
import { useState, useEffect, useRef } from 'react';
import './text-editor.css';

const TextEditor: React.FC = () => {
      const [editing, setEditing] = useState(false);
      const ref = useRef<HTMLDivElement | null>(null);
      const [value, setValue] = useState('# Header');

      useEffect(() => {
            const listener = (event: MouseEvent) => {
                  if (ref.current && event.target && ref.current.contains(event.target as Node)) return;
                  setEditing(false);
            };
            document.addEventListener('click', listener, { capture: true });

            return () => {
                  document.removeEventListener('click', listener, { capture: true });
            };
      }, []);

      if (editing) {
            return (
                  <div className="text-editor" ref={ref}>
                        <MDEditor value={value} onChange={(v) => setValue(v || '')} />
                  </div>
            );
      }

      return (
            <div className="text-editor card" onClick={() => setEditing(true)}>
                  <div className="card-content"></div>
                  <MDEditor.Markdown source={value} />
            </div>
      );
};

export default TextEditor;
