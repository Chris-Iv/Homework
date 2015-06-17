<?php
date_default_timezone_set("Europe/Sofia");
$dateOne = strtotime($_GET['dateOne']);
$dateTwo = strtotime($_GET['dateTwo']);
$holidays = preg_split("/\s+/", $_GET['holidays'], -1, PREG_SPLIT_NO_EMPTY);

foreach ($holidays as $key => $date) {
    $holidays[$key] = strtotime($date);
}

$currentDate = $dateOne;
$workdays = [];

function isWorkday($strToTime, $holidays) {
    $dayOfWeek = date("N", $strToTime);
    if ($dayOfWeek > 5 || in_array($strToTime, $holidays)) {
        return false;
    }
    return true;
}

while ($currentDate <= $dateTwo) {
    if (isWorkday($currentDate, $holidays)) {
        $workdays[] = $currentDate;
    }
    $currentDate = strtotime("+1 day", $currentDate);
}

$result = "<ol>";
if (count($workdays) == 0) {
    $result = "<h2>No workdays</h2>";
} else {
    for ($i = 0; $i < count($workdays); $i++) {
        $date = date("d-m-Y", $workdays[$i]);
        $result .= "<li>$date</li>";
    }
    $result .= "</ol>";
}
echo $result;
?>