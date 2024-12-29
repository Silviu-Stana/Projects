import { NextFunction, Request, Response } from 'express';
import { get, controller, bodyValidator, post } from './decorators';

@controller('/auth')
class LoginController {
      //We can use that PropertyDescriptor to limit where what functions can apply @get to:
      //Example below is invalid because it does not take a (Request,Response) as arguments.
      // @get('/')
      // add(a: number, b: number): number { return a + b; }

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

      @post('/login')
      @bodyValidator('email', 'password')
      postLogin(req: Request, res: Response) {
            const { email, password } = req.body;

            if (email === 'hi@hi.com' && password === 'password') {
                  req.session = { loggedIn: true };
                  res.redirect('/');
            } else {
                  res.send('invalid email / password');
            }
      }

      @get('/logout')
      getLogout(req: Request, res: Response) {
            req.session = undefined;
            res.redirect('/');
      }
}
