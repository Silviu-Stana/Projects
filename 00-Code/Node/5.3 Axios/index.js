import express from "express";
import bodyParser from "body-parser";
import axios from "axios";

const app = express();
const port = 3000;

app.use(express.static("public"));
app.use(bodyParser.urlencoded({ extended: true }));

app.get("/", async (req, res) => {
  try {
    const response = await axios.get("https://bored-api.appbrewery.com/random");
    const result = response.data;
    console.log(result);
    res.render("index.ejs", { data: result });
  } catch (error) {
    console.error("Failed to make request:", error.message);
    res.render("index.ejs", {
      error: error.message,
    });
  }
});

app.post("/", async (req, res) => {
         console.log(req.body);
        
         try {
                const url = "https://bored-api.appbrewery.com/filter?type="+req.body.type+"&participants="+req.body.participants;
                const response = await axios.get(url);
        const random = Math.floor(Math.random()*response.data.length);
        const result=response.data[random];
         console.log(response.data[random]);
        res.render("index.ejs", {data: result});
        }
        catch(error){
                if (error.response && error.response.status === 404) {
                        res.render("index.ejs", { notFound: "No activities found for the given filter."});
                    } else {
                        // Handle other types of errors
                        res.render("index.ejs", { notFound: "An error occurred while fetching activities. Please try again later."});
                    }
        }
});

app.listen(port, () => {
  console.log(`Server running on port: ${port}`);
});
