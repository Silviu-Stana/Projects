import { FetchTodoAction, DeleteTodoAction } from './todos';

export enum ActionTypes {
      fetchTodos = 'FETCH_TODOS',
      deleteTodo = 'DELETE_TODO',
}

export type Action = FetchTodoAction | DeleteTodoAction;
