// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    // jQuery methods go here...
    $("#toolbar").show();
    $("#restart").hide();

});
function feed()
{
    
    var request = new XMLHttpRequest();
    request.onreadystatechange = function () {
        if (request.readyState === 4) {

            if (request.status === 200) {

                let data = JSON.parse(request.response);
                console.log("data is ",data);
                document.getElementById("fullness").innerHTML = data.fullness;
                document.getElementById("happiness").innerHTML = data.happiness;
                document.getElementById("meals").innerHTML = data.meals;
                document.getElementById("energy").innerHTML = data.energy;
                document.getElementById("message").innerHTML = data.message;
                document.getElementById("cat").src = data.image;
                if (data.gameover == "true") {
                    document.getElementById("toolbar").style.display = "none";//hide 
                    document.getElementById("restart").style.display = "";//show
                }
                // console.log('response', request.response);
                // console.log('count', data['count']);
                // console.log('innertext', count.innerText);
            } else {

                return fail(request.status);
            }
        } else {
            console.log("someting wrong!")
        }
    }
    request.open("GET", "/feed", true);
    request.send();
}

function play()
{
    var request = new XMLHttpRequest();
    request.onreadystatechange = function () {
        if (request.readyState === 4) {

            if (request.status === 200) {

                let data = JSON.parse(request.response);
                console.log("data is ", data);
                document.getElementById("fullness").innerHTML = data.fullness;
                document.getElementById("happiness").innerHTML = data.happiness;
                document.getElementById("meals").innerHTML = data.meals;
                document.getElementById("energy").innerHTML = data.energy;
                document.getElementById("message").innerHTML = data.message;
                document.getElementById("cat").src = data.image;
                if(data.gameover == "true")
                {
                    document.getElementById("toolbar").style.display = "none";//隐藏 
                    document.getElementById("restart").style.display = "";//显示
                }
                // console.log('response', request.response);
                // console.log('count', data['count']);
                // console.log('innertext', count.innerText);
            } else {

                return fail(request.status);
            }
        } else {
            console.log("someting wrong!")
        }
    }
    request.open("GET", "/play", true);
    request.send();

}

function work()
{
    var request = new XMLHttpRequest();
    request.onreadystatechange = function () {
        if (request.readyState === 4) {

            if (request.status === 200) {

                let data = JSON.parse(request.response);
                console.log("data is ", data);
                document.getElementById("fullness").innerHTML = data.fullness;
                document.getElementById("happiness").innerHTML = data.happiness;
                document.getElementById("meals").innerHTML = data.meals;
                document.getElementById("energy").innerHTML = data.energy;
                document.getElementById("message").innerHTML = data.message;
                document.getElementById("cat").src = data.image;
                if (data.gameover == "true") {
                    document.getElementById("toolbar").style.display = "none";//hide 
                    document.getElementById("restart").style.display = "";//show
                }
                // console.log('response', request.response);
                // console.log('count', data['count']);
                // console.log('innertext', count.innerText);
            } else {

                return fail(request.status);
            }
        } else {
            console.log("someting wrong!")
        }
    }
    request.open("GET", "/work", true);
    request.send();

}

function sleep()
{
    var request = new XMLHttpRequest();
    request.onreadystatechange = function () {
        if (request.readyState === 4) {

            if (request.status === 200) {

                let data = JSON.parse(request.response);
                console.log("data is ", data);
                document.getElementById("fullness").innerHTML = data.fullness;
                document.getElementById("happiness").innerHTML = data.happiness;
                document.getElementById("meals").innerHTML = data.meals;
                document.getElementById("energy").innerHTML = data.energy;
                document.getElementById("message").innerHTML = data.message;
                document.getElementById("cat").src = data.image;
                if (data.gameover == "true") {
                    document.getElementById("toolbar").style.display = "none";//隐藏 
                    document.getElementById("restart").style.display = "";//显示
                }
                // console.log('response', request.response);
                // console.log('count', data['count']);
                // console.log('innertext', count.innerText);
            } else {

                return fail(request.status);
            }
        } else {
            console.log("someting wrong!")
        }
    }
    request.open("GET", "/sleep", true);
    request.send();

}