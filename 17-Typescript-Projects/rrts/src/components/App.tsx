import React, { JSX } from 'react';
import { connect } from 'react-redux';
import { fetchTodos, deleteTodo, Todo } from '../actions';
import { StoreState } from '../reducers';

interface AppProps {
      todos: Todo[];
      fetchTodos: Function;
      deleteTodo: typeof deleteTodo;
}

interface AppState {
      fetching: boolean;
}

class _App extends React.Component<AppProps, AppState> {
      constructor(props: AppProps) {
            super(props);
            this.state = { fetching: false };
      }

      componentDidUpdate(prevProps: AppProps): void {
            if (prevProps.todos.length === 0 && this.props.todos.length > 0) {
                  this.setState({ fetching: false });
            }
      }

      onButtonClick = (): void => {
            this.props.fetchTodos();
            this.setState({ fetching: true });
      };

      onTodoClick = (id: number): void => {
            this.props.deleteTodo(id);
      };

      renderList(): JSX.Element[] {
            return this.props.todos.map((todo: Todo) => {
                  return (
                        <div onClick={() => this.onTodoClick(todo.id)} key={todo.id}>
                              {todo.title}
                        </div>
                  );
            });
      }

      render() {
            return (
                  <div>
                        <button onClick={this.onButtonClick}>Fetch</button>
                        {this.renderList()}
                        {this.state.fetching ? 'LOADING' : null}
                  </div>
            );
      }
}

const mapStateToProps = ({ todos }: StoreState): { todos: Todo[] } => {
      return { todos };
};

export const App = connect(mapStateToProps, { fetchTodos, deleteTodo })(_App);
