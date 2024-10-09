import express from "express";

const app = express();
const port=3000;

const today = new Date();
const weekday = today.getDay();



app.get("/", (req, res)=>{
        console.log(weekday);
        // if(weekday===0 || weekday===6) res.send("<h1>Hey! It's a weekend! Have fun!</h1>");
        // else res.send("<h1>Hey! It's a weekday! It's time to work hard!</h1>");
        if(weekday===0 || weekday===6) res.render("index.ejs", {
                dayType: "a weekend",
                advice: "it's time to have fun"});
        else res.render("index.ejs", {
                dayType: "a weekday",
                advice: "it's time to work hard"});
})

app.listen(port, ()=>{
        console.log("Server launched on port 3000");
})