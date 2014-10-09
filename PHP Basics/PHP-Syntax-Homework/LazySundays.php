<?php
$year = date("Y");
$month = date("F");
$days = date("t");
for ($i = 1; $i <= $days; $i++) {
    $date = strtotime("$i $month $year");
    if (date("l", $date) == "Sunday") {
        echo(date("jS F, Y", $date) . "\n");
    }
}
?>