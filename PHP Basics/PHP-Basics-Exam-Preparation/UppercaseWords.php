<?php
$text = $_GET['text'];

$newText = "";
$temp = "";

for ($i = 0; $i < strlen($text); $i++) {
    $ch = $text[$i];
    if (ctype_alpha($ch)) {
        $temp .= $ch;
    } else {
        $newText .= processWord($temp);
        $temp = "";
        $newText .= $ch;
    }
}
$newText .= processWord($temp);

echo "<p>" . htmlspecialchars($newText) . "</p>";

function processWord($word) {
    if (ctype_upper($word)) {
        $revWord = strrev($word);
        if ($word == $revWord) {
            $doubledWord = "";
            for ($i = 0; $i < strlen($word); $i++) {
                $doubledWord .= $word[$i] . $word[$i];
            }
            return $doubledWord;
        } else {
            return $revWord;
        }
    }
    return $word;
}
?>