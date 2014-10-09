<?php
function NonRepeatingDigits($N){
    $n = 999;
    if ($N < 999) {
        $n = $N;
    }
    $arr = array();
    for ($i = 102; $i <= $n; $i++) {
        $firstDigit = (int)($i % 10);
        $secondDigit = (int)(($i / 10) % 10);
        $thirdDigit = (int)($i / 100);
        if ($firstDigit !== $secondDigit && $firstDigit !== $thirdDigit && $secondDigit !== $thirdDigit) {
            array_push($arr, $i);
        }
    }
    if (count($arr) > 0) {
        echo implode(', ', $arr);
    } else {
        echo('no');
    }
    echo("\n");
}
NonRepeatingDigits(1234);
NonRepeatingDigits(145);
NonRepeatingDigits(15);
NonRepeatingDigits(247);
?>