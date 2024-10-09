import express from "express";
import axios from "axios";

const app = express();
const port = 3000;
const API_URL = "https://secrets-api.appbrewery.com/";

//TODO 1: Fill in your values for the 3 types of auth.
const yourUsername = "sealdev";
const yourPassword = "sealpassword";
const yourAPIKey = "6d286a4f-b610-449d-b3cd-3f6d3f2327b8";
const yourBearerToken = "2775814e-6f76-4550-89a5-3ba3b41da248";

app.get("/", (req, res) => {
  res.render("index.ejs", { content: "API Response." });
});

app.get("/noAuth", async (req, res) => {
        //JSON.stringify turns the JS object from axios into a JSON string.
        const response=await axios.get("https://secrets-api.appbrewery.com/random");
        const responseString = JSON.stringify(response.data);
        res.render("index.ejs", {content: responseString});
});

app.get("/basicAuth", async (req, res) => {
        
        const userAuth = await axios.get('https://secrets-api.appbrewery.com/all?page=2', {
                auth: {
                        username: yourUsername,
                        password: yourPassword
                }
        });
        const responseString = JSON.stringify(userAuth.data);

    res.render("index.ejs", {content: responseString} );
});

app.get("/apiKey", async (req, res) => {
  const response = await axios.get("https://secrets-api.appbrewery.com/filter?score=5&apiKey="+yourAPIKey);
  const responseString = JSON.stringify(response.data);
  
  res.render("index.ejs",{ content: responseString} )
});

app.get("/bearerToken", async (req, res) => {
  
  const URL = "https://secrets-api.appbrewery.com/secrets/42"
  // https://stackoverflow.com/a/52645402
  const response = await axios.get(URL, {
          headers: { Authorization: `Bearer ${yourBearerToken}` },
        });
        
  const responseString = JSON.stringify(response.data);
  
  res.render("index.ejs", {content: responseString});
  
  
});

app.listen(port, () => {
  console.log(`Server is running on port ${port}`);
});
