/*
GAME RULES:

- The game has 2 players, playing in rounds
- In each turn, a player rolls a dice as many times as he whishes. Each result get added to his ROUND score
- BUT, if the player rolls a 1, all his ROUND score gets lost. After that, it's the next player's turn
- The player can choose to 'Hold', which means that his ROUND score gets added to his GLBAL score. After that, it's the next player's turn
- The first player to reach 100 points on GLOBAL score wins the game
summery: after the user rolls 1 or presses hold it's next player turn.
*/
var scores, roundScore, activePlayer, gamePlaying;
gamePlaying = true;
globalScores = [0, 0];
activePlayer = 0;
roundScore = 0;
var btnRoll = document.querySelector(".btn-roll");
var dice = document.querySelector(".dice");
dice.style.display = 'none';
btnRoll.addEventListener("click", function() {
    if (gamePlaying) {
        var num = Math.floor(Math.random() * 6 + 1);
        dice.style.display = 'block';
        dice.src = "dice-" + num + ".png";
        if (num != 1) {
            roundScore = roundScore + num;
            document.querySelector("#current-" + activePlayer).innerHTML = roundScore;
        } else {
            nextPlayer();
        }
    }
});
document.querySelector(".btn-hold").addEventListener('click', function() {
    globalScores[activePlayer] += roundScore;
    document.querySelector("#score-" + activePlayer).innerHTML = globalScores[activePlayer];
    if (globalScores[activePlayer] >= 20) {
        document.querySelector("#name-" + activePlayer).innerHTML = "Winner!";
        dice.style.display = 'none';
        document.querySelector(".player-" + activePlayer + "-panel").classList.remove("active");
        document.querySelector(".player-" + activePlayer + "-panel").classList.add("winner");
        gamePlaying = false;
    } else { nextPlayer() };
})

document.querySelector(".btn-new").addEventListener('click', function() {
    window.location.reload(false);
})


function nextPlayer() {
    roundScore = 0;
    document.querySelector("#current-" + activePlayer).innerHTML = roundScore;
    activePlayer === 0 ? activePlayer = 1 : activePlayer = 0;
    document.querySelector(".player-0-panel").classList.toggle("active");
    document.querySelector(".player-1-panel").classList.toggle("active");
}