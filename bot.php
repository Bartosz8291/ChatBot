<?php

$question = $_GET['question'];
$answer = '';

if ($question == 'hello') {
    $answer = 'Hi there!';
} elseif ($question == 'how are you?') {
    $answer = 'I\'m just a bot, but thanks for asking!';
} else {
    $answer = 'I\'m sorry, I didn\'t understand the question.';
}

echo json_encode(['answer' => $answer]);

?>
