<?php
function SumTwoNumbers($firstNumber, $secondNumber){
    $sum = round($firstNumber + $secondNumber, 2);
    echo("\$firstNumber + \$secondNumber = $firstNumber + $secondNumber = $sum \n");
}
SumTwoNumbers(2, 5);
SumTwoNumbers(1.567808, 0.356);
SumTwoNumbers(1234.5678, 333);
?>