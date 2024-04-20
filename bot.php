<?php

$question = $_GET['question'];
$answer = '';

if ($question == 'cześć') {
    $answer = 'Witaj!';
} elseif ($question == 'jak się masz?') {
    $answer = 'Jestem tylko botem, ale dziękuję za zapytanie!';
} else {
    $answer = 'Przepraszam, nie zrozumiałem pytania.';
}

echo json_encode(['answer' => $answer]);

?>
