<?php
$list = $_GET['list'];
$maxSize = $_GET['maxSize'];
$sentences = preg_split("/\\r\\n|\\r|\\n/", $list, -1, PREG_SPLIT_NO_EMPTY);
$result = "<ul>";

for ($i = 0; $i < count($sentences); $i++) {
    $sentences[$i] = trim($sentences[$i]);
}

foreach ($sentences as $sentence) {
    if (strlen($sentence) > $maxSize) {
        $result .= "<li>" . htmlspecialchars(substr($sentence, 0, $maxSize)) . "..." . "</li>";
    } else {
        $result .= "<li>" . htmlspecialchars($sentence) . "</li>";
    }
}

$result .= "</ul>";
echo $result;
?>