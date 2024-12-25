import axios, { AxiosPromise } from 'axios';

interface HasId {
      id?: number;
}

export class ApiSync<T extends HasId> {
      constructor(public rootUrl: string) {}

      fetch(id: number): AxiosPromise {
            return axios.get(`${this.rootUrl}/${id}`);
      }

      save(data: T): AxiosPromise {
            const { id } = data;

            const newId = Math.floor(Math.random() * 10_000_000);
            console.log(newId);

            if (id) {
                  return axios.put(`${this.rootUrl}/${id}`, data);
            } else {
                  return axios.post(this.rootUrl, { ...data, id: newId });
            }
      }
}
