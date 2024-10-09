
// $("h1").css("font-size", "3rem");
//$("h1").css("font-family", "Helvetica");

$("button").click(function(){
    $("h1").css("color", "purple");
});

//button click change to random color
$("button").click(function(){
    var randomColor = Math.floor(Math.random()*16777215).toString(16);
    $("h1").css("color", "#" + randomColor);
});

$("button").css("color", "green");
$("button").css("font-weight", "bold");


$("button").each(function(index) {
        var colors = ["red", "blue", "purple", "orange", "green"];
        $(this).text("Click me").css("color", colors[index]);
});


$("h1").addClass("big-title margin-50");