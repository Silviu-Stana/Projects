import express from 'express';
import { currentUser } from '../middlewares/current-user';

const router = express.Router();

router.get('/api/users/currentuser', currentUser, (req, res) => {
    //If currentUser is "undefined", send back "null"
    res.send({ currentUser: req.currentUser || null });
});

export { router as currentUserRouter };
