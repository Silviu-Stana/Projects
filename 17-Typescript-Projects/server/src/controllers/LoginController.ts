import { NextFunction, Request, Response, Router } from 'express';
import { get } from './decorators/routes';
import { controller } from './decorators/controller';

@controller('/auth')
export class LoginController {
      @get('/login')
      getLogin(req: Request, res: Response): void {
            res.send(`
                       <form method="post">
                          <div>
                                <label>Email</label>
                                <input name="email"></input>
                          </div>
                          <div>
                              <label>Password</label>
                              <input name="password" type="password"></input>
                          </div>
                          <button>Submit</button>
                       </form>`);
      }
}
