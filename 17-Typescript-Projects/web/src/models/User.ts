//START COMMAND:
//json-server --watch db.json
import { Attributes } from './Attributes';
import { Eventing } from './Eventing';
import { Sync } from './Sync';

export interface UserProps {
      id?: number;
      name?: string;
      age?: number;
}

const rootUrl = 'http://localhost:3000/users';

export class User {
      public events: Eventing = new Eventing();
      public sync: Sync<UserProps> = new Sync<UserProps>(rootUrl);
      public attributes: Attributes<UserProps>;

      constructor(attrib: UserProps) {
            this.attributes = new Attributes<UserProps>(attrib);
      }

      //NOT calling a function here. Just returning a reference to a function, makes it easier to access
      get on() {
            return this.events.on;
      }

      get trigger() {
            return this.events.trigger;
      }

      get get() {
            return this.attributes.get;
      }
}
