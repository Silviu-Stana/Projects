import { Eventing } from './Eventing';
import axios, { AxiosResponse } from 'axios';

//<M,P> - Model, Props
export class Collection<M, P> {
      models: M[] = [];
      events: Eventing = new Eventing();

      //Deserialize function takes each json object  of Props -> Model
      constructor(public rootUrl: string, public deserialize: (json: P) => M) {}

      get on() {
            return this.events.on;
      }

      get trigger() {
            return this.events.trigger;
      }

      fetch(): void {
            axios.get(this.rootUrl).then((response: AxiosResponse) => {
                  response.data.forEach((value: P) => {
                        this.models.push(this.deserialize(value));
                  });
            });

            this.trigger('change');
      }
}
