var userScore = 0;
var compScore = 0;
const userScoreSpan = document.getElementById("user-score");
const compScoreSpan = document.getElementById("computer-score");
const begin = document.getElementById("beginButton");
const button = document.getElementById(this.id);
var elements = document.getElementsByClassName('button'); // get all elements
var explosions = [10];
var ind;


function checkWin() {
    for (i = 0; i < 25; i++) {
        if (compScore < 10 && userScore == 26) {
            begin.innerHTML = "you won!!!";
            break;
        }
        if (compScore == 10 && userScore < 26) {
            begin.innerHTML = "you completely exploded!!!";
            break;
        }
    }
}


function game() {

}




function getRandomArray() {
    for (i = 0; i < 9; i++) {
        var num = Math.floor(Math.random() * (36)) + 1;
        if (explosions.includes(num)) {
            i--;
            continue;
        } else {
            explosions.push(num);
        }
    }
}


/* every place that was chosen is imediately marked with hidden explosions(10 places),
and if not chosen put hidden applause .go to game*/




getRandomArray();

function game() {
    for (let index = 1; index <= 36; index++) {
        var m = index.toString();
        // document.getElementById(m).addEventListener("click", paint(index, m));
        document.getElementById(m).addEventListener("click", paint(index, m));
    }
}
game();

function paint(index, m) {
    if (explosions.includes(index)) {
        document.getElementById(m).style.background = "#ff0000";
    }
}
//document.getElementById("1").style.background = "#ff0000";
//  console.log(landmines);
// id = parseInt(this.id);
/*if ((exists(id, landmines))) {
    $(".button").on("click", funtion())
    $("#" + this.id).css('background-color', 'red');
}*/