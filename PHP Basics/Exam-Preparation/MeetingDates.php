<?php
date_default_timezone_set("Europe/Sofia");
$dateOne = strtotime($_GET['dateOne']);
$dateTwo = strtotime($_GET['dateTwo']);

if ($dateOne > $dateTwo) {
    $tempDate = $dateOne;
    $dateOne = $dateTwo;
    $dateTwo = $tempDate;
}

$currDate = $dateOne;
$thursdays = [];

while ($currDate <= $dateTwo) {
    if (isThursday($currDate)) {
        $thursdays[] = $currDate;
    }
    $currDate = strtotime("+1 day", $currDate);
}

function isThursday($currDate) {
    $day = date("N", $currDate);
    if ($day != 4) {
        return false;
    }
    return true;
}

$result = "<ol>";
if (count($thursdays) == 0) {
    $result = "<h2>No Thursdays</h2>";
} else {
    for ($i = 0; $i < count($thursdays); $i++) {
        $date = date("d-m-Y", $thursdays[$i]);
        $result .= "<li>$date</li>";
    }
    $result .= "</ol>";
}
echo $result;
?>
<!DOCTYPE html>
<html>
<head>
    <title>1. Meeting Days</title>
</head>
<body>
<form method="get">
    <label>
        First date:
        <input type="text" name="dateOne" />
    </label>
    <br />
    <label>
        Second date:
        <input type="text" name="dateTwo" />
    </label>
    <br />
    <input type="submit" value="Submit"/>
</form>
</body>
</html>