<?php
date_default_timezone_set('Europe/Sofia');
$currDate = strtotime($_GET['currentDate']);
$text = $_GET['messages'];

$arr = explode("\n", $text);
$messages = [];
$latestTime = 0;

foreach ($arr as $str) {
    $messageInfo = explode(" / ", $str);
    $messageText = $messageInfo[0];
    $messageDate = strtotime($messageInfo[1]);
    $messages[$messageDate] = $messageText;
    if ($messageDate > $latestTime) {
        $latestTime = $messageDate;
    }
}

ksort($messages);
$result = "";

foreach ($messages as $key => $value) {
    $result .= "<div>" . htmlspecialchars($value) . "</div>\n";
}

$timestamp = getTime($latestTime, $currDate);
$result .= "<p>Last active: <time>$timestamp</time></p>";

echo $result;

function getTime($latestTime, $currDate) {
    $time = $currDate - $latestTime;
    $currDay = date("z", $currDate);
    $lastDay = date("z", $latestTime);
    $lastDate = date("d-m-Y", $latestTime);
    if ($lastDay == $currDay) {
        if ($time < 60) {
            return "a few moments ago";
        } else if ($time >= 60 && $time < 3600) {
            $minutes = floor($time / 60);
            return "$minutes minute(s) ago";
        } else if ($time >= 3600) {
            $hours = floor($time / 3600);
            return "$hours hour(s) ago";
        }
    } else if (($lastDay + 1) == $currDay) {
        return "yesterday";
    } else {
        return "$lastDate";
    }
}
?>