import express from "express";
import bodyParser from "body-parser";
import pg from "pg";

const db = new pg.Client({
        user: 'postgres',
        password: 'sealpassword',
        host: 'localhost',
        port: '5432',
        database: 'world'
});

db.connect();
const app = express();
const port = 3000;

var countries=[];
var visited=[];

app.use(bodyParser.urlencoded({ extended: true }));
app.use(express.static("public"));



app.get("/", async (req, res) => {
        const queryCountries = await db.query('SELECT country_code, country_name FROM countries');
        countries = queryCountries.rows;    
        
        const queryVisited = await db.query('SELECT country_code FROM visited_countries');
        
        visited=[];
        
        queryVisited.rows.forEach((country) => {
                visited.push(country.country_code);
        });
                         
        res.render('index.ejs', {countries: visited, total: visited.length});     
});

app.post("/add", async (req, res) => {
        let index = countries.findIndex((country)=> country.country_name===req.body.country);
        
        const querySimilarEnoughWord = await db.query("SELECT country_name FROM countries WHERE country_name LIKE ' %' || ($1) || '%'", [req.body.country]);
        let similarCountryNameExists = await querySimilarEnoughWord.rows.length;
        
        //If found similar name, search for index again.
        if(similarCountryNameExists)
        {
                var similarCountryName = querySimilarEnoughWord.rows[0].country_name;
                index = countries.findIndex((country)=> country.country_name===similarCountryName);
        }
        //console.log(similarCountryName);
        
        if(index>-1)
        {
                let addCountryCode = countries[index].country_code;
                let alreadyFound = visited.findIndex((c)=> c===addCountryCode);
        
                        if(alreadyFound === -1)
                        {
                                const updateVisited = await db.query(`INSERT INTO visited_countries (country_code) 
                                                                                             VALUES ($1)`, [addCountryCode]);
                                
                                res.redirect('/');
                        }
                        else
                        {
                                res.render('index.ejs', {countries: visited, total: visited.length, error: 'Already added.'});
                        }
   
        }
        else
        {
                res.render('index.ejs', {countries: visited, total: visited.length, error: 'Does not exist.'});
        }
      });


app.listen(port, () => {
  console.log(`Server running on http://localhost:${port}`);
});
