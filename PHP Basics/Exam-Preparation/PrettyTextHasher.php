<?php
if (isset($_GET['text']) && isset($_GET['hashValue']) && isset($_GET['fontSize']) && isset($_GET['fontStyle'])) {
    $text = $_GET['text'];
    $hashValue = $_GET['hashValue'];
    $fontSize = $_GET['fontSize'];
    $fontStyle = $_GET['fontStyle'];
    $result = "<p style=\"font-size:$fontSize;";
    if ($fontStyle == "normal" || $fontStyle == "italic") {
        $result .= "font-style:$fontStyle;\">";
    } else if ($fontStyle == "bold") {
        $result .= "font-weight:$fontStyle;\">";
    }
    for ($i = 0; $i < strlen($text); $i++) {
        $char = $text[$i];
        if ($i % 2 == 0) {
            $newChar = chr(ord($char) + $hashValue);
        } else {
            $newChar = chr(ord($char) - $hashValue);
        }
        $result .= $newChar;
    }
    $result .= "</p>";
    echo $result;
}
?>