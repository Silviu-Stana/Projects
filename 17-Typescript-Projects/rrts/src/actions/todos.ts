import axios from 'axios';
import { Dispatch } from 'redux';
import { ActionTypes } from './types';

const url = 'https://jsonplaceholder.typicode.com/todos';

export interface Todo {
      id: number;
      title: string;
      completed: boolean;
}

export interface FetchTodoAction {
      type: ActionTypes.fetchTodos;
      payload: Todo[];
      [key: string]: any;
}

export interface DeleteTodoAction {
      type: ActionTypes.deleteTodo;
      payload: number;
}

//Action creator
export const fetchTodos = () => {
      return async (dispatch: Dispatch) => {
            const response = await axios.get<Todo[]>(url);

            dispatch<FetchTodoAction>({
                  type: ActionTypes.fetchTodos,
                  payload: response.data,
            });
      };
};

//Action creator
export const deleteTodo = (id: number): DeleteTodoAction => {
      return {
            type: ActionTypes.deleteTodo,
            payload: id,
      };
};
