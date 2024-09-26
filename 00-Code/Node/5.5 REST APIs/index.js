import express from "express";
import axios from "axios";
import bodyParser from "body-parser";

const app = express();
const port = 3000;
const API_URL = "https://secrets-api.appbrewery.com";

// https://axios-http.com/docs/post_example
// https://secrets-api.appbrewery.com/

const yourBearerToken = "2775814e-6f76-4550-89a5-3ba3b41da248";
const config = {
  headers: { Authorization: `Bearer ${yourBearerToken}`,
  'Content-Type': 'application/x-www-form-urlencoded'
             },
};

app.use(bodyParser.urlencoded({ extended: true }));

app.get("/", (req, res) => {
  res.render("index.ejs", { content: "Waiting for data..." });
});

app.post("/get-secret", async (req, res) => {
  const searchId = req.body.id;
  try {
    const result = await axios.get(API_URL + "/secrets/" + searchId, config);
    res.render("index.ejs", { content: JSON.stringify(result.data) });
  } catch (error) {
    res.render("index.ejs", { content: JSON.stringify(error.response.data) });
  }
});

//I am ashaded! I love programming too much!
app.post("/post-secret", async (req, res) => {
  // POST the data from req.body to the secrets api servers.
  const result = await axios.post(API_URL + '/secrets',
        {
        secret: req.body.secret,
        score: req.body.score
        },
        config);
  
  res.render('index.ejs', {content: 'New Data: ' + JSON.stringify(result.data)} );
});

app.post("/put-secret", async (req, res) => {
  const searchId = req.body.id;
  // PUT the data from req.body to the secrets api servers.
        if(!req.body.secret || !req.body.score)
        {
                res.render('index.ejs', {content: 'You need fill out both the score and secret, to PUT.'} );
                return;
        }
  
        try{
        const result = await axios.put(API_URL + '/secrets/' + searchId,
        {secret: req.body.secret,
        score: req.body.score },   config);
  
        res.render('index.ejs', {content: JSON.stringify(result.data)} );
         }
        catch (error) {
                console.error("Error updating secret:", error);
                res.status(500).json({ error: "Failed to update secret" });
              }
});

app.post("/patch-secret", async (req, res) => {
  const searchId = req.body.id;
  
  if(!req.body.score && !req.body.secret)
  {
        res.render('index.ejs', {content: 'You need to update at least 1 field. The score or the secret.'});
        return;
  }
  
  try{
        const result = await axios.patch(API_URL+'/secrets/'+searchId,
                {
             "secret": req.body.secret,
             "score": req.body.score
                },   config);

res.render('index.ejs', {content: JSON.str(result.data)});    
  }
  catch(error){
          console.error('Error: ' + error);
          res.status(500).json({ error: "Failed to update secret" });
  }

  
});

app.post("/delete-secret", async (req, res) => {
  const searchId = req.body.id;
  
  if(!req.body.id){
        res.render('index.ejs', {content: 'Could not find that secret ID to delete. '});
        return;    
  }
  
  try{
  const result = await axios.delete(API_URL+'/secrets/'+searchId, config);
  
  res.render('index.ejs', {content: 'Sucessfully deleted Secret number ' + searchId});
  }
  catch(error){
          console.error("Error: " + error);
          res.render('index.ejs', {content: 'Non existent secret ID:  ' + searchId + "Cannot delete."});
  }
  
});

app.listen(port, () => {
  console.log(`Server is running on port ${port}`);
});
