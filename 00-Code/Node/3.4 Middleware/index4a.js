import express from "express";
import bodyParser from "body-parser";
import {fileURLToPath} from "url";
import { dirname } from "path";

const app = express();
const port = 3000;
const _url = dirname(fileURLToPath(import.meta.url));

app.use(bodyParser.urlencoded({ extended: false }));

app.get("/", (req, res)=>{
   res.sendFile(_url + "/public/index.html");     
});

app.post("/submit", (req, res)=>{
        res.send(req.body.street+req.body.pet);
})

app.listen(port, () => {
  console.log(`Listening on port ${port}`);
});
