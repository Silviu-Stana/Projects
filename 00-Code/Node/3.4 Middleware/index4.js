import express from "express";
import { dirname } from "path";
import { fileURLToPath } from "url";
import bodyParser from "body-parser";

const app = express();
const port = 3000;
const htmlFilePath = dirname(fileURLToPath(import.meta.url));

app.use(bodyParser.urlencoded({extended: true}));


app.get("/", (req, res) => {
        res.sendFile(htmlFilePath + "/public/index.html");
})

app.get("/submit", (req, res) => {
        res.send(street + petName);
})

app.post("/submit", (req, res) => {
        res.send(req.body.street+req.body.pet+"🤑");
})

app.listen(port, () => {
  console.log(`Listening on port ${port}`);
});
