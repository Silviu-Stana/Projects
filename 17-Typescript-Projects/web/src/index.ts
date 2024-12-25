import { User } from './models/User';

const user = User.buildUser({ id: 381616 });
user.on('change', () => {
      console.log(user);
});

user.fetch();
