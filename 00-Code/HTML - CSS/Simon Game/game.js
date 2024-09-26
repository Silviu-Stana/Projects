var randomChosenColor;
var gameStarted = false;
var gameIsOver = false;
var level=0;
var userClickedPattern = [];
var gamePattern = [];

function delay(ms) {
        return new Promise(resolve => setTimeout(resolve, ms));
}

async function nextSequence(){
        $("h1").html("Level " + level);
        
        var buttonColors = ["red", "blue", "green", "yellow"];
        var random =  Math.floor(Math.random()*4);
        randomChosenColor = buttonColors[random];
        
        
        gamePattern.push(randomChosenColor);
        console.log(gamePattern);
        
        for(var i=0; i<=level; i++)
        {
                animatePress("#"+gamePattern[i]);
                playSound(gamePattern[i]);
                
                await delay(500);
                
        }
        
        level++;    
}

$(".btn").click(function(){
        if(!gameIsOver)
        {
                var userChosenColor = this.id;
                userClickedPattern.push(userChosenColor);
                
                console.log(userClickedPattern);
                
                checkAnswer();
                
                playSound(this.id);
                
                animatePress(this);    
        }
});

function animatePress(currentColour){
        $(currentColour).fadeOut(100);
        $(currentColour).fadeIn(100);
        
        $(currentColour).addClass("pressed");
        setTimeout(function(){
                $(currentColour).removeClass("pressed");
        },150);
}

$(document).keypress(function(){
        if(gameStarted == false) {
                nextSequence();
                gameStarted=true;
                gameIsOver=false;
        }
});

function checkAnswer(){
        for(var i=0; i<userClickedPattern.length; i++)
                if(gamePattern[i] != userClickedPattern[i])gameOver();
                
        if(gamePattern.length===userClickedPattern.length && !gameIsOver)
        {
                setTimeout(function(){
                        userClickedPattern = [];
                        nextSequence();
                },1000);
        }
}

function gameOver(){
        playSound("wrong");
        gameIsOver=true;
        gameStarted=false;
        
        //Animate Red (CSS)
        $("body").addClass("game-over");
        setTimeout(function(){
                $("body").removeClass("game-over");
        },200);
        
        $("h1").text("Game Over, Press Any Key to Restart");
        
        userClickedPattern=[];
        gamePattern=[];
        level=0;
}

function playSound(name){
        switch (name) {
                case "green": new Audio("sounds/green.mp3").play(); break;
                case "red": new Audio("sounds/red.mp3").play(); break;
                case "yellow": new Audio("sounds/yellow.mp3").play(); break;
                case "blue": new Audio("sounds/blue.mp3").play(); break;
                case "wrong": new Audio("sounds/wrong.mp3").play(); break;
                default: break;
        }
}