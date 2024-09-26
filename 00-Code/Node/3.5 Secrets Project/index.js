//password: ILoveProgramming
import express from "express"
import bodyParser from "body-parser";
import { fileURLToPath } from "url";
import { dirname } from "path";

const app = express();
const port = "3000";
const _url = dirname(fileURLToPath(import.meta.url));

app.use(bodyParser.urlencoded({extended: true}));

app.get("/", (req, res)=>{
        res.sendFile(_url + "/public/index.html");
})

app.post("/check", (req, res)=>{
        if(req.body.password==="ILoveProgramming") res.sendFile(_url + "/public/secret.html");
        else res.sendFile(_url + "/public/index.html");
})

app.listen(port, ()=>{
        console.log(`Server running on port ${port}`);
})