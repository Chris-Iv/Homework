<?php
$text = $_GET['text'];
$lineLen = $_GET['lineLength'];

$textLen = strlen($text);
$rows = intval($textLen / $lineLen) + ($textLen % $lineLen == 0 ? 0 : 1);
$matrix = [];
$currChar = 0;
for ($row = 0; $row < $rows; $row++) {
    $matrix[] = [];
    for ($col = 0; $col < $lineLen; $col++, $currChar++) {
        if ($currChar < $textLen) {
            $matrix[$row][$col] = $text[$currChar];
        } else {
            $matrix[$row][$col] = " ";
        }
    }
}

$lastRow = count($matrix) - 1;
for ($i = $lastRow; $i > 0; $i--) {
    for ($col = 0; $col < $lineLen; $col++) {
        for ($row = $lastRow; $row > 0; $row--) {
            if ($matrix[$row][$col] == " ") {
                $matrix[$row][$col] = $matrix[$row - 1][$col];
                $matrix[$row - 1][$col] = " ";
            }
        }
    }
}

$result = "<table>";
for ($row = 0; $row < count($matrix); $row++) {
    $result .= "<tr>";
    for ($col = 0; $col < count($matrix[$row]); $col++) {
        $result .= "<td>" . htmlspecialchars($matrix[$row][$col]) . "</td>";
    }
    $result .= "</tr>";
}
$result .= "<table>";
echo $result;
?>