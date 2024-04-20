function sendMessage() {
    var question = document.getElementById('user-input').value;
    document.getElementById('chat-history').innerHTML += '<p>User: ' + question + '</p>';

    fetch('bot.php?question=' + question)
    .then(response => response.json())
    .then(data => {
        document.getElementById('chat-history').innerHTML += '<p>Bot: ' + data.answer + '</p>';
    });
}
