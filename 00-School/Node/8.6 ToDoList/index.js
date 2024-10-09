import express from "express";
import bodyParser from "body-parser";
import pg from "pg";

const db = new pg.Client({
        user: 'postgres',
        password: 'sealpassword',
        host: 'localhost',
        port: '5432',
        database: 'permalist'       
});

db.connect();

const app = express();
const port = 3000;

app.use(bodyParser.urlencoded({ extended: true }));
app.use(express.static("public"));

let items = [
 // { id: 1, title: "Buy milsssk" },
 // { id: 2, title: "Finish homework" },
];

app.get("/", async (req, res) => {
  const results = await db.query('SELECT * FROM items ORDER BY id ASC;');
  const data = results.rows;
  console.log(data);
  
  items = data;
  
  res.render("index.ejs", {
          listTitle: "Today",
          listItems: items,
        });
});

app.post("/add", async (req, res) => {
  const item = req.body.newItem;
  
  const updateTitle = await db.query('INSERT INTO items(title) VALUES ($1);', [item]);
  res.redirect("/");
});

app.post("/edit", async (req, res) => {
        let index = items.findIndex((item)=> item.id===req.body.updatedItemId);
        let updatedID = parseInt(req.body.updatedItemId);
        let updatedTitle = req.body.updatedItemTitle;
        
        const updateTitle = await db.query('UPDATE items SET title=$1 WHERE id=$2', [updatedTitle, updatedID]);
        res.redirect("/");
});

app.post("/delete", async (req, res) => {
        let itemToDelete = parseInt(req.body.deleteItemId);
        
        const deleteItem = await db.query('DELETE FROM items WHERE id=$1', [itemToDelete]);
        res.redirect("/");
});

app.listen(port, () => {
  console.log(`Server running on port ${port}`);
});
