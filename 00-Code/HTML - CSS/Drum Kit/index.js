//Detect Click
for(var i=0; i< document.querySelectorAll("button").length; i++)
document.querySelectorAll("button")[i].addEventListener("click", function(){
        handleKey(this.innerHTML);
        buttonAnimation(this.innerHTML);
})


function handleKey(charText){
        switch (charText) {
                case "w": new Audio("sounds/tom-1.mp3").play(); break;
                case "a": new Audio("sounds/tom-2.mp3").play(); break;
                case "s": new Audio("sounds/tom-3.mp3").play(); break;
                case "d": new Audio("sounds/tom-4.mp3").play(); break;
                case "j": new Audio("sounds/snare.mp3").play(); break;
                case "k": new Audio("sounds/crash.mp3").play(); break;
                case "l": new Audio("sounds/kick-bass.mp3").play(); break;
        
                default: console.log(this.innerHTML); break;
        }
}

//Detect Key Press
document.addEventListener("keydown", function(event){
        handleKey(event.key);
        buttonAnimation(event.key);
})



function buttonAnimation(currentkey){
        var activeButton = document.querySelector("."+currentkey);
        activeButton.classList.add("pressed");
        
        var delayInMilliseconds = 100;
        
        setTimeout(function(){
                activeButton.classList.remove("pressed");
        }, delayInMilliseconds)
}