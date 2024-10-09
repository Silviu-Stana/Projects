import express from "express"
import bodyParser from "body-parser"

const app = express();
const port = 3000;
var blogTitles = [];
var blogPosts = [];
const currentlyViewingPost=
{
        index: -1,
        title: '',
        body: ''
};


app.use(express.static("public"));
app.use(bodyParser.urlencoded({extended: true}));


app.get("/", (req, res) => {
        res.render("index.ejs", { titles: blogTitles, posts: blogPosts });
    });

app.post("/post", (req, res)=>{
        res.render("post.ejs");
})

app.get("/edit", (req, res)=>{
        res.render("editPost.ejs", {content: currentlyViewingPost});
})

app.post("/submit-post", (req, res)=>{
        const description = req.body.description.replace(/\n/g, "<br><br>"); // Replace new lines with <br>
        
        blogTitles.push(req.body["title2"]);
        blogPosts.push(description);
        
        res.redirect("/");
        
})

app.post("/edit-post", (req, res)=>{
        const description = req.body.description.replace(/\n/g, "<br><br>"); // Replace new lines with <br>
        
        blogTitles[currentlyViewingPost.index] = req.body["title2"];
        blogPosts[currentlyViewingPost.index] = description;
        
        res.redirect("/");
        
})

app.post("/delete", (req, res)=>{
        const index = currentlyViewingPost.index;
        
        blogTitles.splice(index, 1); // 2nd parameter means delete one post only
        blogPosts.splice(index, 1);
        
        res.redirect("/");
        
})


app.get("/posts/:postId", (req, res) => {
        const postId = req.params.postId;
        
        // Find post based on index or title
        const postIndex = blogTitles.findIndex(title => title === postId); 
        
        if (postIndex === -1) {
                return res.status(404).send("Post not found");
        }
        
        const title = blogTitles[postIndex];
        const body = blogPosts[postIndex];
        
        currentlyViewingPost.index = postIndex;
        currentlyViewingPost.title = title;
        currentlyViewingPost.body = body;
    
        res.render("viewPost.ejs", { title: title, description: body });
    });




app.listen(port, ()=>{
        console.log(`Started server on port ${port}`);
})