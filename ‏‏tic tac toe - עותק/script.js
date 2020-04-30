var choiseOne = document.getElementById("choiseOne");
var choiseTwo = document.getElementById("choiseTwo");
var choiseThree = document.getElementById("choiseThree");
var choiseFour = document.getElementById("choiseFour");
var choiseFive = document.getElementById("choiseFive");
var choiseSix = document.getElementById("choiseSix");
var choiseSeven = document.getElementById("choiseSeven");
var choiseEight = document.getElementById("choiseEight");
var choiseNine = document.getElementById("choiseNine");
var result = document.getElementById("result");
var compUsed = [];
var userUsed = [];
var ran;
var counter = 0;

function game() {
    document.querySelector("#choiseOne").addEventListener("click", function() {
        choiseOne.innerHTML = "X";
        userUsed.push(1);
        computerChoise();
        printWinner();
    });
    document.querySelector("#choiseTwo").addEventListener("click", function() {
        //   counter++;
        choiseTwo.innerHTML = "X";
        //  if (counter % 3 == 0) { printWinner(); }
        userUsed.push(2);
        computerChoise();
        printWinner();
    });
    document.querySelector("#choiseThree").addEventListener("click", function() {
        // counter++;
        choiseThree.innerHTML = "X";
        // if (counter % 3 == 0) { printWinner(); }
        userUsed.push(3);
        computerChoise();
        printWinner();
    });
    document.querySelector("#choiseFour").addEventListener("click", function() {
        counter++;
        choiseFour.innerHTML = "X";
        if (counter % 3 == 0) {
            printWinner();
        }
        userUsed.push(4);
        computerChoise();
        printWinner();
    });
    document.querySelector("#choiseFive").addEventListener("click", function() {
        choiseFive.innerHTML = "X";
        userUsed.push(5);
        computerChoise();
        printWinner();
    });
    document.querySelector("#choiseSix").addEventListener("click", function() {
        choiseSix.innerHTML = "X";
        userUsed.push(6);
        computerChoise();
        printWinner();
    });
    document.querySelector("#choiseSeven").addEventListener("click", function() {
        choiseSeven.innerHTML = "X";
        userUsed.push(7);
        computerChoise();
        printWinner();
    });
    document.querySelector("#choiseEight").addEventListener("click", function() {
        choiseEight.innerHTML = "X";
        userUsed.push(8);
        computerChoise();
        printWinner();
    });
    document.querySelector("#choiseNine").addEventListener("click", function() {
        choiseNine.innerHTML = "X";
        userUsed.push(9);
        computerChoise();
        printWinner();
    });
}

function calcRandomNum() {
    var randomNum = Math.floor(Math.random() * 9) + 1; //1 to 9
    return randomNum;
}

function computerChoise() {
    ran = calcRandomNum();
    while (compUsed.includes(ran) || userUsed.includes(ran)) {
        ran = calcRandomNum();
    }
    var string = convertNumToString(ran);
    var choise = document.getElementById(string);
    choise.innerHTML = "O";
    compUsed.push(ran);
}

function convertNumToString(n) {
    switch (n) {
        case 1:
            return "choiseOne";
        case 2:
            return "choiseTwo";
        case 3:
            return "choiseThree";
        case 4:
            return "choiseFour";
        case 5:
            return "choiseFive";
        case 6:
            return "choiseSix";
        case 7:
            return "choiseSeven";
        case 8:
            return "choiseEight";
        case 9:
            return "choiseNine";
        default:
            break;
    }
}

function Win(array) {
    return (
        (array.includes(1) && array.includes(2) && array.includes(3)) ||
        (array.includes(4) && array.includes(5) && array.includes(6)) ||
        (array.includes(7) && array.includes(8) && array.includes(9)) ||
        (array.includes(1) && array.includes(5) && array.includes(9)) ||
        (array.includes(3) && array.includes(5) && array.includes(7)) ||
        (array.includes(1) && array.includes(4) && array.includes(7)) ||
        (array.includes(2) && array.includes(5) && array.includes(8)) ||
        (array.includes(3) && array.includes(6) && array.includes(9))
    );
}

function printWinner() {
    if (Win(userUsed)) {
        result.innerHTML = "you win!";
        var cm = document.querySelector(".compMove");
        //cm.src = "s1.jpg";
        cm.innerHTML = "Yay winner!Tap to try again!";
        cm.style.background = "#99ff99";
        document.getElementById("result").style.background = "#99ff99";
        //  cm.style.background = "#";
        //var img = document.createElement("img");
        //  img.src = "best.jpg";
        //var src = document.getElementById("compMove");
        //src.appendChild(img);

        return;
    }
    if (Win(compUsed)) {
        result.innerHTML = "computer wins!";
        document.querySelector(".compMove").innerHTML =
            "You lost!Tap to Try again!";
        document.getElementById("result").style.background = "#ff0000";
        document.querySelector(".compMove").style.background = "#ff0000";
        return;
    }
    document.querySelector(".compMove").innerHTML = "keep playing!";
}

game();
var reload = document.querySelector("#compMove");
/*if (reload.textContent == "Yay!try again!") {
    reload.classList.style.display = "block";
    reload.src = "s1.jpg";
} else {
    reload.src = "s2.jpg";
}*/
reload.addEventListener("click", function() {
    window.location.reload(false);
});
/*var p = prompt("would you like to guess who'll win?");
if(p=='yes'){
    //good guess! at the end;
}*/