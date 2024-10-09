import express from "express"
import axios from "axios"

const app = express();
const port = 3000;
const catImgURL = 'https://api.thecatapi.com/v1/images'

//Show one of these random quotes when loading up a cat!
const lines = [
        'I know you want another one :)',
        'Cats are just purrfect, aren’t they?',
        'Who can resist those whiskers?',
        'One cat is never enough!',
        'Get ready for some serious cuteness!',
        'Another cat? Yes, please!',
        'You know it’s always a good time for cats!',
        'Fur real, you need more cats!',
        'Paws what you’re doing and get another kitty!',
        'Can you ever have too many cats? I don’t think so!',
        'Your next furry friend is just a click away!',
        'Feeling claw-some today? Get another cat!',
        'Cats make everything better!',
        'You’re one step closer to more kitty love!',
        'Here’s your next cat! You’re welcome :)',
        'There’s always room for one more cat!',
        'Ready for more purrs and snuggles?',
        'Cats: because dogs just don’t purr!',
        'Every kitty has its own unique purr-sonality!',
        'More cats = more happiness!',
        'We see a lot of fur in your future!',
        'Can you hear the purrs from here?',
        'Time to meet your next feline friend!',
        'The world needs more cats, don’t you agree?',
        'Prepare yourself for an overload of cuteness!',
        'Once you meet one cat, you’ll want them all!',
        'Every cat is a masterpiece waiting to be admired!',
        'Your next best friend is right here!',
        'Can you ever get enough of those fluffy tails?',
        'The best things in life are fluffy!',
        'Paws and think: one more cat can’t hurt!',
        'Who can resist a pair of bright, curious eyes?',
        'Meet the cat that’s going to steal your heart!',
        'Ready for another pawsome experience?',
        'One cat, two cat, more cats galore!',
        'Cats: they’re just little fluffy bois!',
        'Let’s get you another furball to cuddle!',
        'Time for more kitty cuteness, don’t you think?',
        'Every day is better with a cat by your side!',
        'Want more purrs? You’re in the right place!',
        'Life’s too short for just one cat!',
        'Let’s turn your home into a cat haven!',
        'Warning: Cuteness overload incoming!',
        'Are you ready for another fluffy friend?',
        'Every cat brings its own kind of magic!',
        'Cats: the ultimate form of therapy.'
];

app.use(express.static("public"));


app.get("/", async (req, res) => {
        res.render("index.ejs");
    });

    app.post("/cat", async (req, res) => {
        
        try{
                const catPicture = await axios.get(catImgURL + "/search");
                //console.log(catFact.data[0]);
                    
                let randomLine = Math.floor(Math.random()*lines.length);
                res.render("cat.ejs", {picture: catPicture.data[0], catLine: lines[randomLine]});
        }
        catch(error){
                console.error(error);
        }

    });


app.listen(port, ()=>{
        console.log(`Started server on port ${port}`);
})