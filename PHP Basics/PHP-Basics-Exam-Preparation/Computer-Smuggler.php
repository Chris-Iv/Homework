<?php
$parts = explode(", ", $_GET['list']);

$counter["CPU"] = 0;
$counter["ROM"] = 0;
$counter["RAM"] = 0;
$counter["VIA"] = 0;

$prices["CPU"] = 85;
$prices["ROM"] = 45;
$prices["RAM"] = 35;
$prices["VIA"] = 45;

for ($i = 0; $i < count($parts); $i++) {
    foreach ($counter as $part => $count) {
        if ($part == $parts[$i]) {
            $counter[$part]++;
            break;
        }
    }
}

$fullPravets = min($counter);
$expences = 0;
$partsLeft = 0;
$partsProfit = 0;

foreach ($counter as $part => $count) {
    if ($count >= 5) {
        $expences += 0.5 * ($count * $prices[$part]);
    } else {
        $expences += ($count * $prices[$part]);
    }

    $partsRemaining = $count - $fullPravets;
    $partsProfit += 0.5 * ($partsRemaining * $prices[$part]);
    $partsLeft += $partsRemaining;
}

$balance = ($partsProfit + ($fullPravets * 420)) - $expences;

echo "<ul><li>$fullPravets computers assembled</li><li>$partsLeft parts left</li></ul>";
if ($balance > 0) {
    echo "<p>Nakov gained $balance leva</p>";
} else {
    echo "<p>Nakov lost $balance leva</p>";
}
?>