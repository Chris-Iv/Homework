<?php
$text = $_GET['text'];
$minFontSize = $_GET['minFontSize'];
$maxFontSize = $_GET['maxFontSize'];
$step = $_GET['step'];

$result = "";
$currSize = $minFontSize;
$change = true;

for ($i = 0; $i < strlen($text); $i++) {
    $result .= "<span style=";

    if (ctype_alpha($text[$i]) == true) {
        if ($change) {
            if ($currSize >= $minFontSize) {
                if ($currSize < $maxFontSize) {
                    $result .= "'font-size:$currSize;";
                    $currSize = $currSize + $step;
                } else if ($currSize >= $maxFontSize) {
                    $result .= "'font-size:$currSize;";
                    $currSize = $currSize - $step;
                    $change = false;
                }
            } else {
                $currSize = $currSize + $step;
            }
        } else {
            if ($currSize >= $minFontSize) {
                if ($currSize > $minFontSize) {
                    $result .= "'font-size:$currSize;";
                    $currSize = $currSize - $step;
                } else if ($currSize = $minFontSize) {
                    $result .= "'font-size:$currSize;";
                    $currSize = $currSize + $step;
                    $change = true;
                }
            } else {
                $currSize = $currSize + $step;
                $change = true;
            }
        }
    } else {
        $result .= "'font-size:$currSize;";
    }

    if (ord($text[$i]) % 2 == 0) {
        $result .= "text-decoration:line-through;'>";
    } else {
        $result .= "'>";
    }

    $result .= htmlspecialchars($text[$i]);
    $result .= "</span>";
}

echo $result;
?>