import express from "express";
import bodyParser from "body-parser";
import pg from "pg";

const app = express();
const port = 3000;

const db = new pg.Client({
  user: "postgres",
  host: "localhost",
  database: "world",
  password: "sealpassword",
  port: 5432,
});
db.connect();

app.use(bodyParser.urlencoded({ extended: true }));
app.use(express.static("public"));

let currentUserId = 1;

let users = [
  //{ id: 1, name: "Angela", color: "teal" },
  //{ id: 2, name: "Jack", color: "powderblue" },
];

async function checkVisisted() {
  const result = await db.query("SELECT country_code FROM visited_countries WHERE user_id=$1", [currentUserId]);
  const fetchUsers = await db.query("SELECT * FROM users ORDER BY id ASC");
  
  users = [];
  
  fetchUsers.rows.forEach((user)=>{
          users.push(user);
  })
  
  let countries = [];
  result.rows.forEach((country) => {
    countries.push(country.country_code);
  });
  return countries;
}

app.get("/", async (req, res) => {
  const countries = await checkVisisted();
  
  console.log(users);
  
  let index = users.findIndex((findUser)=> findUser.id===currentUserId);
  
  console.log(index);
  
  let currentColor = users[index].color;
  
  res.render("index.ejs", {
    countries: countries,
    total: countries.length,
    users: users,
    color: currentColor,
  });
});


app.post("/add", async (req, res) => {
  const input = req.body["country"];

  try {
    const result = await db.query(
      "SELECT country_code FROM countries WHERE LOWER(country_name) LIKE '%' || $1 || '%';",
      [input.toLowerCase()]
    );

    const data = result.rows[0];
    console.log(data);
    const countryCode = data.country_code;
    try {
      await db.query(
        "INSERT INTO visited_countries (country_code, user_id) VALUES ($1, $2)",
        [countryCode, currentUserId]
      );
      res.redirect("/");
    } catch (err) {
      console.log(err);
    }
  } catch (err) {
    console.log(err);
  }
});
app.post("/user", async (req, res) => {
        
        //If clicked 'Add Family Member' button
        if(req.body.add==='new') res.render("new.ejs");
        
        //Else clicked a button to select a 'User'
        else
        {
                
                currentUserId = req.body.user;
                currentUserId = parseInt(req.body.user, 10);
                res.redirect("/");        
        }
 
});

app.post("/new", async (req, res) => {
         
        const insertedUser = await db.query('INSERT INTO users(name, color) VALUES ($1, $2) RETURNING *', [req.body.name, req.body.color]);
        currentUserId= insertedUser.rows[0].id;       
  res.redirect("/");  
});

app.listen(port, () => {
  console.log(`Server running on http://localhost:${port}`);
});
